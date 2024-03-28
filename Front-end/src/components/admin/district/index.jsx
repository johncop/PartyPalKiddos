import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

export const DistrictPage = () => {
  const [data, setData] = useState([]);

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
  }, []);

  const btnDataAdd = [
    {
      title: "Description",
      placeholder: "",
      type: "text",
      requried: "true",
      items: [],
    },
  ];

  function handleSubmit(e) {
    e.preventDefault();
    axios
      .post(`${process.env.REACT_APP_API_BASE_URL}/districts`, {
        description: e.target[1].value,
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
        <h4 className="mt-4">District</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">District</li>
        </ol>
        <TableAdmin
          columns={["id", "description"]}
          data={data}
          btnDataAdd={btnDataAdd}
          handleSubmit={handleSubmit}
        />
      </div>
    </>
  );
};
