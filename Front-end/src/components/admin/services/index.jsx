import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

export const ServicesPage = () => {
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);
  const [serviceCategory, setServiceCategory] = useState({
    title: "Service Category",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    items: [],
    key: "serviceCategory.id",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/districts`)
      .then((response) => {
        setServiceCategory({
          ...serviceCategory,
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
      .get(`${process.env.REACT_APP_API_BASE_URL}/services`)
      .then((response) => {
        if (response.data.data) {
          setData(response.data.data);
        }
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, [render]);

  const btnDataAdd = [
    {
      title: "Name",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "name",
      disabled: false,
    },
    {
      title: "Description",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "description",
      disabled: false,
    },
    {
      title: "Image URL",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "imageUrl",
      disabled: false,
    },
    {
      title: "Price",
      type: "number",
      placeholder: "",
      requried: "true",
      items: [],
      key: "price",
      disabled: false,
    },
    serviceCategory,
  ];

  function handleSubmit(e) {
    e.preventDefault();
    axios
      .post(`${process.env.REACT_APP_API_BASE_URL}/services`, {
        name: e.target[1].value,
        description: e.target[2].value,
        imageUrl: e.target[3].value,
        price: e.target[5].value,
        serviceCategoryId: e.target[6].value,
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
  }

  function handleEdit(e, id) {
    e.preventDefault();
    axios
      .put(`${process.env.REACT_APP_API_BASE_URL}/services/${id}`, {
        id: id,
        name: e.target[1].value,
        description: e.target[2].value,
        imageUrl: e.target[3].value,
        price: e.target[5].value,
        serviceCategoryId: e.target[6].value,
      })
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
  }

  function handleDelete(id) {
    axios
      .delete(`${process.env.REACT_APP_API_BASE_URL}/venues/${id}`)
      .then((response) => {
        toast.info("Delete Success", {
          position: "bottom-center",
          autoClose: 2000,
        });
        setRender(!render);
        return response;
      })
      .catch((error) => {
        console.log(error);
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
        <h4 className="mt-4">Service</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Service</li>
        </ol>
        <TableAdmin
          columns={["name", "description", "address", "capacity", "price"]}
          data={data}
          btnDataAdd={btnDataAdd}
          handleSubmit={handleSubmit}
          handleEdit={handleEdit}
          handleRemove={handleDelete}
        />
      </div>
    </>
  );
};
