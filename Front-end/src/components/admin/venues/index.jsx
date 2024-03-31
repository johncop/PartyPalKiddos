import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";

export const VenuePage = () => {
  const [data, setData] = useState([]);
  const [districts, setDictrics] = useState({
    title: "Districts",
    type: "text",
    placeholder: "Type to select",
    requried: true,
    items: [],
    key: "district.id",
    disabled: true,
  });
  const [render, setRender] = useState(false);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/venues`)
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
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/districts`)
      .then((response) => {
        setDictrics({
          ...districts,
          items: [
            ...response.data.data.map((item) => {
              return {
                value: item.description,
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
  const btnDataAdd = [
    {
      title: "Name",
      type: "text",
      placeholder: "",
      requried: true,
      items: [],
      key: "name",
      disabled: false,
    },
    {
      title: "Description",
      type: "text",
      placeholder: "",
      requried: true,
      items: [],
      key: "description",
      disabled: false,
    },
    {
      title: "Address",
      type: "text",
      placeholder: "",
      requried: true,
      items: [],
      key: "address",
      disabled: false,
    },
    {
      title: "Capacity",
      type: "number",
      placeholder: "",
      requried: true,
      items: [],
      key: "capacity",
      disabled: false,
    },
    {
      title: "Price",
      type: "number",
      placeholder: "",
      requried: true,
      items: [],
      key: "price",
      disabled: false,
    },
    {
      title: "Open Hours",
      type: "time",
      placeholder: "",
      requried: true,
      items: [],
      key: "openHour",
      disabled: false,
    },
    {
      title: "Close Hours",
      type: "time",
      placeholder: "",
      requried: true,
      items: [],
      key: "closeHour",
      disabled: false,
    },
    districts,
    {
      title: "Poster Images",
      type: "file",
      placeholder: "",
      requried: false,
      items: [],
      key: "imageUrls",
      disabled: false,
      getImageUrls: (value) => value.venueImages[0]?.imageUrl,
    },
  ];

  function handleSubmit(e) {
    e.preventDefault();
    handleUpload("images/venue", e.target[9].files[0], (res) => {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}/venues`, {
          name: e.target[1].value,
          description: e.target[2].value,
          address: e.target[3].value,
          capacity: e.target[4].value,
          price: e.target[5].value,
          openHour: e.target[6].value,
          closeHour: e.target[7].value,
          disctrictId: e.target[8].value,
          imageUrls: [res],
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

  function handleEdit(e, id) {
    e.preventDefault();
    axios
      .put(`${process.env.REACT_APP_API_BASE_URL}/venues/${id}`, {
        id: id,
        name: e.target[1].value,
        description: e.target[2].value,
        address: e.target[3].value,
        capacity: e.target[4].value,
        price: e.target[5].value,
        openHour: e.target[6].value,
        closeHour: e.target[7].value,
        disctrictId: e.target[8].value,
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
        <h4 className="mt-4">Venue</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Venue</li>
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
