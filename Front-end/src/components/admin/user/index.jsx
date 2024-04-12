import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

export const UserPage = () => {
  const [data, setData] = useState([]);
  const [updatedRoles, setUpdatedRoles] = useState([]);
  const [render, setRender] = useState(false);
  const [roles, setRoles] = useState({
    title: "Roles",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    items: [],
    key: "roles.id",
    disabled: false,
    multiple: true,
    onChange: (evt) => {
      setUpdatedRoles(
        evt.map((combo) => {
          return combo.value;
        })
      );
    },
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}users/roles`)
      .then((response) => {
        setRoles({
          ...roles,
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
      .get(`${process.env.REACT_APP_API_BASE_URL}users`)
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
      title: "Display Name",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "displayName",
      disabled: true,
    },
    {
      title: "Email",
      type: "email",
      placeholder: "",
      requried: "true",
      items: [],
      key: "email",
      disabled: true,
    },
    {
      title: "Full Name",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "fullName",
      disabled: true,
    },
    {
      title: "UserName",
      type: "text",
      placeholder: "",
      requried: "true",
      items: [],
      key: "userName",
      disabled: true,
    },
    roles,
  ];
  function handleSubmit(e) {
    e.preventDefault();
    axios
      .post(`${process.env.REACT_APP_API_BASE_URL}users`, {
        name: e.target[1].value,
        description: e.target[2].value,
        price: e.target[3].value,
        foodCategoryId: e.target[4].value,
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
      .put(`${process.env.REACT_APP_API_BASE_URL}add-roles`, {
        userId: item.id,
        roleName: updatedRoles,
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
      .delete(`${process.env.REACT_APP_API_BASE_URL}users/delete/${id}`)
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
        <h4 className="mt-4">Users</h4>
        <ol className="breadcrumb mb-4">
          <li className="breadcrumb-item active">Users</li>
        </ol>
        <TableAdmin
          columns={["id", "full name", "email"]}
          columnKeys={["id", "fullName", "email"]}
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
