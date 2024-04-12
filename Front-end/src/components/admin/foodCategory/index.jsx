import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useSelector } from "react-redux";

export const FoodCategoryPage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/food-categories`)
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
  ];

  function handleSubmit(e) {
    e.preventDefault();
    axios
      .post(`${process.env.REACT_APP_API_BASE_URL}/food-categories`, {
        name: e.target[1].value,
        description: e.target[2].value,
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

  function handleEdit(e, item) {
    e.preventDefault();
    axios
      .put(`${process.env.REACT_APP_API_BASE_URL}/food-categories/${item.id}`, {
        id: item.id,
        name: e.target[1].value,
        description: e.target[2].value,
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
      .delete(`${process.env.REACT_APP_API_BASE_URL}/food-categories/${id}`)
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
        <h4 className="mt-4">Food Category</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Food Category</li>
        </ol>
        <TableAdmin
          columns={["id", "name", "description"]}
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
