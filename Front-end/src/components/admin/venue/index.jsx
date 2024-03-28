import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

export const VenuePage = () => {
  const [data, setData] = useState([]);
  const [districts, setDictrics] = useState({
    title: "Districts",
    type: "text",
    placeholder: "type to select",
    requried: "true",
    items: [],
  });

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/venues`)
      .then((response) => {
        console.log(response);
        if (response.data.data) {
          setData(response.data.data);
        }
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, []);
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/districts`)
      .then((response) => {
        setDictrics({
          title: "Districts",
          type: "text",
          placeholder: "type to select",
          requried: "true",
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
      requried: "true",
      items: [],
    },
    {
      title: "Description",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
    },
    {
      title: "Address",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
    },
    {
      title: "Capacity",
      type: "number",
      placeholder: "",
      requried: "true",
      items: [],
    },
    {
      title: "Price",
      type: "number",
      placeholder: "",
      requried: "true",
      items: [],
    },
    {
      title: "Open Hours",
      type: "time",
      placeholder: "",
      requried: "true",
      items: [],
    },
    {
      title: "Close Hours",
      type: "time",
      placeholder: "",
      requried: "true",
      items: [],
    },
    districts,
  ];

  function handleSubmit(e) {
    e.preventDefault();
    axios
      .post(`${process.env.REACT_APP_API_BASE_URL}/venues`, {
        name: e.target[1].value,
        description: e.target[2].value,
        address: e.target[3].value,
        capacity: e.target[4].value,
        price: e.target[5].value,
        openHour: {
          ticks: e.target[6].value,
        },
        closeHour: {
          ticks: e.target[7].value,
        },
        disctrictId: e.target[8].value,
      })
      .then((response) => {
        toast.info("Create Success", {
          position: "bottom-center",
          autoClose: 2000,
        });
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
        />
      </div>
    </>
  );
};
