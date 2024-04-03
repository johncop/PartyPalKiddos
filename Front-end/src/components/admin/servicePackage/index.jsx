import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";

export const ServicePackagePage = () => {
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);

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
    handleUpload("images/service", e.target[4].files[0], (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/service-packages`, {
          name: e.target[1].value,
          price: e.target[2].value,
          status: e.target[3].checked ? 1 : 0,
          images: [res],
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
    handleUpload("images/service", e.target[4].files[0], (res) => {
      axios
        .put(
          `${process.env.REACT_APP_API_BASE_URL}/service-packages/${item.id}`,
          {
            id: item.id,
            name: e.target[1].value,
            price: e.target[2].value,
            status: e.target[3].checked ? 1 : 0,
            images: [res],
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
        <h4 className="mt-4">Service Category</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Service Category</li>
        </ol>
        <TableAdmin
          columns={["id", "name", "price"]}
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
