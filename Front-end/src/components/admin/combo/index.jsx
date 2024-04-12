import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";
import { useSelector } from "react-redux";

export const ComboPage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  const [selectValues, setSelectValue] = useState([]);
  const [render, setRender] = useState(false);
  const [foods, setFoods] = useState({
    title: "Foods",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectValue(
        evt.map((food) => {
          return {
            foodId: food.value,
            quantity: 1,
          };
        })
      );
    },
    items: [],
    key: "foods",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/foods`)
      .then((response) => {
        setFoods({
          ...foods,
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
  }, [render]);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/combos`)
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
    foods,
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
      getImageUrls: (value) => value?.image,
    },
  ];

  function handleSubmit(e) {
    e.preventDefault();
    handleUpload("images/food", e.target[6].files[0], (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/combos`, {
          name: e.target[1].value,
          description: e.target[2].value,
          price: e.target[3].value,
          comboFoods: selectValues,
          status: e.target[5].checked ? 1 : 0,
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
    handleUpload("images/food", e.target[6].files[0], (res) => {
      axios
        .put(`${process.env.REACT_APP_API_BASE_URL}/combos/${item.id}`, {
          id: item.id,
          name: e.target[1].value,
          description: e.target[2].value,
          price: e.target[3].value,
          comboFoods:
            selectValues.length === 0
              ? item.foods.map((food) => {
                  return {
                    foodId: food.id,
                    quantity: 1,
                  };
                })
              : selectValues,
          status: e.target[5].checked ? 1 : 0,
          imageUrl: res || item.image,
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
      .delete(`${process.env.REACT_APP_API_BASE_URL}/combos/${id}`)
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
        <h4 className="mt-4">Combo</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Combo</li>
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
