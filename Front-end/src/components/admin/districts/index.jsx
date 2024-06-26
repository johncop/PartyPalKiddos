import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";
import { useSelector } from "react-redux";

export const DistrictPage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/districts`)
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
      title: "Description",
      placeholder: "",
      type: "text",
      requried: "true",
      items: [],
      key: "description",
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
      getImageUrls: (value) => value?.imageUrl,
    },
  ];

  function handleSubmit(e) {
    e.preventDefault();
    handleUpload("images/district", e.target[2].files, (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/districts`, {
          description: e.target[1].value,
          imageUrl: res[0],
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
    handleUpload("images/district", e.target[2].files, (res) => {
      axios
        .put(`${process.env.REACT_APP_API_BASE_URL}/districts/${item.id}`, {
          description: e.target[1].value,
          imageUrl: res[0] || item.imageUrl,
          id: item.id,
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
    });
  }

  function handleDelete(id) {
    axios
      .delete(`${process.env.REACT_APP_API_BASE_URL}/districts/${id}`)
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
        <h4 className="mt-4">District</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">District</li>
        </ol>
        <TableAdmin
          columns={["id", "description"]}
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
