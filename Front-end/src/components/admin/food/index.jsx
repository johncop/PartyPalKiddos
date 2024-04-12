import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";
import { useSelector } from "react-redux";

export const FoodPage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);
  const [foodCategory, setFoodCategory] = useState({
    title: "Food Category",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    items: [],
    key: "foodCategory.id",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/food-categories`)
      .then((response) => {
        setFoodCategory({
          ...foodCategory,
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
      .get(`${process.env.REACT_APP_API_BASE_URL}/foods`)
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
      title: "Price",
      type: "number",
      placeholder: "",
      requried: "true",
      items: [],
      key: "price",
      disabled: false,
    },
    foodCategory,
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
    handleUpload("images/food", e.target[5].files[0], (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/foods`, {
          name: e.target[1].value,
          description: e.target[2].value,
          price: e.target[3].value,
          foodCategoryId: e.target[4].value,
          imageUrl: res,
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
    handleUpload("images/food", e.target[5].files[0], (res) => {
      axios
        .put(`${process.env.REACT_APP_API_BASE_URL}/foods/${item.id}`, {
          id: item.id,
          name: e.target[1].value,
          description: e.target[2].value,
          price: e.target[3].value,
          foodCategoryId: e.target[4].value,
          imageUrl: res || item.imageUrl,
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
      .delete(`${process.env.REACT_APP_API_BASE_URL}/foods/${id}`)
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
        <h4 className="mt-4">Food</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Food</li>
        </ol>
        <TableAdmin
          state={state}
          columns={["id", "category", "name", "description", "price"]}
          columnKeys={[
            "id",
            "foodCategory.name",
            "name",
            "description",
            "price",
          ]}
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
