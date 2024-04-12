import { TableAdmin } from "../../common/table/tableAdmin";
import axios from "axios";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { handleUpload } from "../../../firebase";
import { AddTimeSlotButton } from "../timeSlot";
import { useSelector } from "react-redux";

export const VenuePage = () => {
  const state = useSelector((state) => state);
  const [data, setData] = useState([]);
  let [timeSlots, setTimeSlots] = useState([]);
  let [addedTimeSlots, setAddedTimeSlots] = useState([]);
  const [districts, setDictrics] = useState({
    title: "Districts",
    type: "text",
    placeholder: "Type to select",
    requried: true,
    items: [],
    key: "district.id",
    disabled: false,
  });
  const [render, setRender] = useState(false);
  const [selectFoods, setSelectFoods] = useState([]);
  const [foods, setFoods] = useState({
    title: "Foods",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectFoods(
        evt.map((food) => {
          return food.value;
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
  const [selectServices, setSelectServices] = useState([]);
  const [services, setServices] = useState({
    title: "Services",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectServices(
        evt.map((service) => {
          return service.value;
        })
      );
    },
    items: [],
    key: "services",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/services`)
      .then((response) => {
        setServices({
          ...services,
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
  const [selectServicePackages, setSelectServicePackages] = useState([]);
  const [servicePackages, setServicePackages] = useState({
    title: "Service Package",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectServicePackages(
        evt.map((servicePackage) => {
          return servicePackage.value;
        })
      );
    },
    items: [],
    key: "servicePackages",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/service-packages`)
      .then((response) => {
        setServicePackages({
          ...servicePackages,
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
  const [selectCombos, setSelectCombos] = useState([]);
  const [combos, setCombos] = useState({
    title: "Combos",
    type: "text",
    placeholder: "Type to select",
    requried: "true",
    multiple: true,
    onChange: (evt) => {
      setSelectCombos(
        evt.map((combo) => {
          return combo.value;
        })
      );
    },
    items: [],
    key: "combos",
    disabled: false,
  });
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/combos`)
      .then((response) => {
        setCombos({
          ...combos,
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
      getImageUrls: (value) =>
        value.venueImages[value.venueImages.length - 1]?.imageUrl,
    },
  ];
  const btnDataEdit = [
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
    foods,
    services,
    servicePackages,
    combos,
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

  function handleAddedField({ startTime, endTime, days, status }) {
    const temp = {
      startTime,
      endTime,
      weekday: days.map((item) => item.value).join("-"),
      status,
    };
    timeSlots.push(temp);
    setTimeSlots(timeSlots);

    addedTimeSlots.push(temp);
    setAddedTimeSlots(addedTimeSlots);
  }

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
  function handleEdit(e, item) {
    e.preventDefault();
    handleUpload("images/venue", e.target[13].files[0], (res) => {
      axios
        .put(`${process.env.REACT_APP_API_BASE_URL}/venues/${item.id}`, {
          id: item.id,
          name: e.target[1].value,
          description: e.target[2].value,
          address: e.target[3].value,
          capacity: Number(e.target[4].value),
          price: Number(e.target[5].value),
          openHour: e.target[6].value,
          closeHour: e.target[7].value,
          disctrictId: e.target[8].value,
          foods:
            selectFoods.length > 0
              ? selectFoods
              : item.foods.map((it) => it.id),
          services:
            selectServices.length > 0
              ? selectServices
              : item.services.map((it) => it.id),
          servicePackages:
            selectServicePackages.length > 0
              ? selectServicePackages
              : item.servicePackages.map((it) => it.id),
          combos:
            selectCombos.length > 0
              ? selectCombos
              : item.combos.map((it) => it.id),
          imageUrls: [res || item.venueImages[0]?.imageUrl],
        })
        .then((response) => {
          Promise.all(
            addedTimeSlots.map((tl) =>
              axios.post(`${process.env.REACT_APP_API_BASE_URL}/time-slots`, {
                startTime: tl.startTime,
                endTime: tl.endTime,
                weekday: tl.weekday,
                status: tl.status ? "free" : "booked",
                venueId: item.id,
              })
            )
          )
            .then((res) => {
              toast.info("Update Success", {
                position: "bottom-center",
                autoClose: 2000,
              });
              setRender(!render);
              timeSlots = [];
              setTimeSlots(timeSlots);
              addedTimeSlots = [];
              setAddedTimeSlots([]);
            })
            .catch((err) => {
              timeSlots = [];
              setTimeSlots(timeSlots);
              addedTimeSlots = [];
              setAddedTimeSlots([]);
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
          btnDataEdit={btnDataEdit}
          handleSubmit={handleSubmit}
          handleEdit={handleEdit}
          handleRemove={handleDelete}
          state={state}
          addedField={(item, isClosed) => {
            if (isClosed) {
              timeSlots = [];
              setTimeSlots(timeSlots);
              addedTimeSlots = [];
              setAddedTimeSlots([]);
              return null;
            } else {
              if (timeSlots.length === 0) {
                timeSlots.push(...item.timeSlots);
                setTimeSlots(timeSlots);
              }
            }

            return (
              <AddTimeSlotButton
                defaultvalue={timeSlots}
                handleSubmit={handleAddedField}
              />
            );
          }}
        />
      </div>
    </>
  );
};
