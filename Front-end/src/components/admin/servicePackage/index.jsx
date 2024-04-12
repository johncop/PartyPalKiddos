import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";
import { useSelector } from "react-redux";

export const ServicePackagePage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  const [selectedServices, setSelectedServices] = useState([]);
  const [render, setRender] = useState(false);
  const [services, setServices] = useState({
    title: "Services",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectedServices(
        evt.map((service) => {
          return service.value;
        })
      );
    },
    items: [],
    key: "services",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/services`)
      .then((response) => {
        setServices({
          ...services,
          items: [
            ...response.data.data.map((item) => {
              return {
                value: item.name,
                id: item.id,
              };
            }),
          ],
        });
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, []);
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/service-packages`)
      .then((response) => {
        setData(response.data.data);
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, [render]);

  const btnDataAdd = [
    {
      title: "Name",
      placeholder: "",
      type: "text",
      requried: "true",
      items: [],
      key: "name",
      disabled: false,
    },
    {
      title: "Description",
      placeholder: "",
      type: "text",
      requried: "true",
      items: [],
      key: "description",
      disabled: false,
    },
    {
      title: "Price",
      placeholder: "",
      type: "number",
      requried: "true",
      items: [],
      key: "price",
      disabled: false,
    },
    {
      title: "Status",
      placeholder: "",
      type: "checkbox",
      requried: "true",
      items: [],
      key: "status",
      disabled: false,
    },
    services,
    {
      title: "Image URL",
      type: "file",
      placeholder: "",
      requried: "true",
      items: [],
      key: "imageUrl",
      disabled: false,
      getImageUrls: (value) => value?.images[0]?.imageUrl,
    },
  ];

  function handleSubmit(e) {
    e.preventDefault();
    handleUpload("images/service", e.target[6].files[0], (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/service-packages`, {
          name: e.target[1].value,
          description: e.target[2].value,
          price: e.target[3].value,
          status: e.target[4].checked ? 1 : 0,
          images: [res],
          services: selectedServices,
        })
        .then((response) => {
          toast.info("Create Success", {
            position: "bottom-center",
            autoClose: 2000,
          });
          setRender(!render);
          return response;
        })
        .catch((error) => {
          toast.error(error.message, {
            position: "bottom-center",
            autoClose: 2000,
          });
          return error;
        });
    });
  }
  function handleEdit(e, item) {
    e.preventDefault();
    handleUpload("images/service", e.target[6].files[0], (res) => {
      axios
        .put(
          `${process.env.REACT_APP_API_BASE_URL}/service-packages/${item.id}`,
          {
            id: item.id,
            name: e.target[1].value,
            description: e.target[2].value,
            price: Number(e.target[3].value),
            status: e.target[4].checked ? 1 : 0,
            images: [res || item.images[0]?.imageUrl],
            services:
              selectedServices.length > 0
                ? selectedServices
                : item.services.map((it) => it.id),
          }
        )
        .then((response) => {
          toast.info("Update Success", {
            position: "bottom-center",
            autoClose: 2000,
          });
          setRender(!render);
          return response;
        })
        .catch((error) => {
          toast.error(error.message, {
            position: "bottom-center",
            autoClose: 2000,
          });
          return error;
        });
    });
  }

  function handleDelete(id) {
    axios
      .delete(`${process.env.REACT_APP_API_BASE_URL}/service-packages/${id}`)
      .then((response) => {
        toast.info("Delete Success", {
          position: "bottom-center",
          autoClose: 2000,
        });
        setRender(!render);
        return response;
      })
      .catch((error) => {
        toast.error(error.message, {
          position: "bottom-center",
          autoClose: 2000,
        });
        return error;
      });
  }

  return (
    <>
      <div className="container-fluid px-4">
        <h4 className="mt-4">Service Package</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Service Package</li>
        </ol>
        <TableAdmin
          columns={["id", "name", "description", "price"]}
          data={data}
          state={state}
          btnDataAdd={btnDataAdd}
          handleSubmit={handleSubmit}
          handleEdit={handleEdit}
          handleRemove={handleDelete}
        />
      </div>
    </>
  );
};
