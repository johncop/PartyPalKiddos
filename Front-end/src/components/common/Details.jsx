import { useParams } from "react-router-dom";
import { LIST_CATE, LIST_SHOW_BOOK } from "../../constants";
import axios from "axios";
import { useEffect, useState } from "react";
import { Product } from "./Product";
import { CountProduct } from "./modal/CountProduct";
import { toast } from "react-toastify";
import { Swiper, SwiperSlide } from "swiper/react";
import { EffectCreative, Navigation, Pagination } from "swiper/modules";
// Import Swiper styles
import "swiper/css";
import "swiper/css/effect-creative";
import "swiper/css/pagination";
import "swiper/css/navigation";
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";

export default function Details({ defaultValue }) {
  let { category, id } = useParams();
  const [data, setData] = useState({});
  const [numberOfKids, setNumberOfKids] = useState(0);
  const [selectedTimeSlot, setSelectedTimeSlot] = useState(0);
  const [date, setDate] = useState(new Date());
  const [timeSlots, setTimeSlots] = useState([]);
  const [numberOfAdults, setNumberOfAdults] = useState(0);
  const [venueId, setVenueId] = useState(0);
  const [subProducts, setSubProducts] = useState([]);
  const [combos, setCombos] = useState([]);
  const [foods, setFoods] = useState([]);
  const [services, setServices] = useState([]);
  const [servicePackages, setServicePackages] = useState([]);
  const [isAddProducts, setIsAddProducts] = useState(false);
  const [isShowCount, setIsShowCount] = useState(false);
  const [expand, setExpand] = useState(false);
  const [titleModal, setTitleModal] = useState("Add Product");
  const [dataModal, setDataModal] = useState({});

  useEffect(() => {
    if (category === LIST_CATE.PARTY_SERVICES && !data.id) {
      axios
        .get(process.env.REACT_APP_API_BASE_URL + "Service/services/" + id)
        .then((response) => {
          setData(response.data);
        })
        .catch((error) => {
          console.log(error.message);
        });
    } else if (category === LIST_CATE.VENUE) {
      axios
        .get(`${process.env.REACT_APP_API_BASE_URL}venues/${id}`)
        .then((response) => {
          const temp = response.data.data;
          setData({
            address: temp.address,
            name: temp.name,
            price: temp.price,
            description: temp.description,
            foods: temp.foods,
            services: temp.services,
            servicePackages: temp.servicePackages,
            combos: temp.combos,
            images: temp.venueImages,
          });
          setVenueId(id);
        })
        .catch((error) => {
          console.log(error.message);
        });
    } else if (category === LIST_CATE.PARTY_PACKAGES) {
      axios
        .get(`${process.env.REACT_APP_API_BASE_URL}service-packages/${id}`)
        .then((response) => {
          const temp = response.data.data;
          setData({
            address: temp.address,
            name: temp.name,
            description: temp.description,
          });
          setServicePackages([
            {
              id,
              quantity: 1,
            },
          ]);
        })
        .catch((error) => {
          console.log(error.message);
        });
    } else if (category === LIST_CATE.CART) {
      axios
        .get(`${process.env.REACT_APP_API_BASE_URL}bookings`)
        .then((response) => {
          const temp = response.data.data.find(
            (item) => item.id === Number(id)
          );
          setDate(new Date(temp.bookingDate));
          setCombos(temp.bookingDetail.combos);
          setFoods(temp.bookingDetail.foods);
          setServices(temp.bookingDetail.services);
          setServicePackages(temp.bookingDetail.servicePackages);
          setSubProducts([
            ...temp.bookingDetail.combos,
            ...temp.bookingDetail.foods,
            ...temp.bookingDetail.services,
            ...temp.bookingDetail.servicePackages,
          ]);
          setNumberOfAdults(temp.numberOfAdults);
          setNumberOfKids(temp.numberOfKids);
          setVenueId(temp.venue.id);
        })
        .catch((error) => {
          console.log(error.message);
        });
    }
  }, [category, id]);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}venues/${venueId}`)
      .then((response) => {
        const temp = response.data.data;
        setData({
          address: temp.address,
          name: temp.name,
          price: temp.price,
          description: temp.description,
          foods: temp.foods,
          services: temp.services,
          servicePackages: temp.servicePackages,
          combos: temp.combos,
          images: temp.venueImages,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, [venueId]);

  useEffect(() => {
    axios
      .get(
        `${
          process.env.REACT_APP_API_BASE_URL
        }time-slots/${id}/${date.toISOString()}`
      )
      .then((response) => {
        setTimeSlots(response.data.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, [date]);

  function handleSelectTimeZone(e) {
    setDate(new Date(e.timeStamp));
  }

  function handleDeleteProduct(item) {
    setSubProducts(
      subProducts.filter(
        (product) => !(product.id === item.id && product.type === item.type)
      )
    );

    if (item.type === "packages") {
      setServicePackages(
        servicePackages.filter((product) => product.id !== item.id)
      );
    } else if (item.type === "services") {
      setServices(services.filter((product) => product.id !== item.id));
    } else if (item.type === "combos") {
      setCombos(combos.filter((product) => product.id !== item.id));
    } else if (item.type === "foods") {
      setFoods(foods.filter((product) => product.id !== item.id));
    }
  }

  function handleClick(e) {
    e.preventDefault();
    if (numberOfAdults < 0 || numberOfKids < 0) {
      toast.error("The number of adults and kids must be greater than 0", {
        position: "bottom-center",
        autoClose: 2000,
      });

      return;
    }
    if (category === LIST_CATE.VENUE) {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}bookings`, {
          bookingDate: date.toISOString(),
          numberOfKids: numberOfKids,
          numberOfAdults: numberOfAdults,
          bookingStatus: "string",
          venueId: venueId,
          combos: combos,
          foods: foods,
          services: services,
          servicePackages: servicePackages,
          bookingTimeSlots: [Number(selectedTimeSlot)],
        })
        .then((response) => {
          // window.location.href = "/cart";
          return response;
        })
        .catch((error) => {
          toast.error(error.message, {
            position: "bottom-center",
            autoClose: 2000,
          });
          return error;
        });
    } else if (category === LIST_CATE.CART) {
      axios
        .put(`${process.env.REACT_APP_API_BASE_URL}bookings/${id}`, {
          id: id,
          bookingDate: date.toISOString(),
          numberOfKids: numberOfKids,
          numberOfAdults: numberOfAdults,
          bookingStatus: "string",
          venueId: venueId,
          combos: combos.map((item) => {
            return { id: item.id, quantity: item.quantity };
          }),
          foods: foods.map((item) => {
            return { id: item.id, quantity: item.quantity };
          }),
          services: services.map((item) => {
            return { id: item.id, quantity: item.quantity };
          }),
          servicePackages: servicePackages.map((item) => {
            return { id: item.id, quantity: item.quantity };
          }),
          bookingTimeSlots: [Number(selectedTimeSlot)],
        })
        .then((response) => {
          window.location.href = "/cart";
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
  }

  function closeModal() {
    setIsShowCount(false);
  }

  function handleEditCountProduct(product) {
    setIsShowCount(true);
    setTitleModal("Edit " + product.type);
    setDataModal({
      type: product.type,
      id: product.id,
      name: product.name,
      description: product.description,
      price: product.price,
      image: product.image,
      isEdit: true,
      quantity: product.quantity,
    });
  }

  function handleAddProduct(type, item) {
    setIsShowCount(true);
    if (type === "packages") {
      setTitleModal("Add Packages");
      setDataModal({
        type: type,
        id: item.id,
        name: item.name,
        description: item.description,
        price: item.price,
        image: item.images && item.images[0]?.imageUrl,
        isEdit: false,
      });
    } else if ("services") {
      setTitleModal("Add Services");
      setDataModal({
        type: type,
        id: item.id,
        name: item.name,
        description: item.description,
        price: item.price,
        image: item.image,
        isEdit: false,
      });
    } else if ("combos") {
      setTitleModal("Add Combos");
      setDataModal({
        type: type,
        id: item.id,
        name: item.name,
        description: item.description,
        price: item.price,
        image: item.image,
        isEdit: false,
      });
    } else if ("foods") {
      setTitleModal("Add Foods");
      setDataModal({
        type: type,
        id: item.id,
        name: item.name,
        description: item.description,
        price: item.price,
        image: item.imageUrl,
        isEdit: false,
      });
    }
  }

  function handleAddSubProduct(
    type,
    id,
    quantity,
    name,
    price,
    image,
    description,
    isEdit
  ) {
    let temp = { id: Number(id), quantity: Number(quantity) };
    if (type === "packages") {
      const checkValue = servicePackages.find((item) => item.id === temp.id);
      if (checkValue) {
        if (isEdit) {
          checkValue.quantity = temp.quantity;
        } else {
          checkValue.quantity = checkValue.quantity + temp.quantity;
        }

        const subPrd = subProducts.find(
          (item) => item.id === temp.id && item.type === "packages"
        );
        subPrd.quantity = checkValue.quantity;
      } else {
        servicePackages.push(temp);
        subProducts.push({
          id,
          quantity,
          price,
          name,
          type,
          image,
          description,
        });
      }
      setServicePackages(servicePackages);
    } else if (type === "services") {
      const checkValue = services.find((item) => item.id === temp.id);
      if (checkValue) {
        if (isEdit) {
          checkValue.quantity = temp.quantity;
        } else {
          checkValue.quantity = checkValue.quantity + temp.quantity;
        }

        const subPrd = subProducts.find(
          (item) => item.id === temp.id && item.type === "services"
        );
        subPrd.quantity = checkValue.quantity;
      } else {
        services.push(temp);
        subProducts.push({
          id,
          quantity,
          price,
          name,
          type,
          image,
          description,
        });
      }
      setServices(services);
    } else if (type === "combos") {
      const checkValue = combos.find((item) => item.id === temp.id);
      if (checkValue) {
        if (isEdit) {
          checkValue.quantity = temp.quantity;
        } else {
          checkValue.quantity = checkValue.quantity + temp.quantity;
        }

        const subPrd = subProducts.find(
          (item) => item.id === temp.id && item.type === "combos"
        );
        subPrd.quantity = checkValue.quantity;
      } else {
        combos.push(temp);
        subProducts.push({
          id,
          quantity,
          price,
          name,
          type,
          image,
          description,
        });
      }
      setCombos(combos);
    } else if (type === "foods") {
      const checkValue = foods.find((item) => item.id === temp.id);
      if (checkValue) {
        if (isEdit) {
          checkValue.quantity = temp.quantity;
        } else {
          checkValue.quantity = checkValue.quantity + temp.quantity;
        }

        const subPrd = subProducts.find(
          (item) => item.id === temp.id && item.type === "foods"
        );
        subPrd.quantity = checkValue.quantity;
      } else {
        foods.push(temp);
        subProducts.push({
          id,
          quantity,
          price,
          name,
          type,
          image,
          description,
        });
      }
      setFoods(foods);
    }

    setSubProducts(subProducts);
  }
  return (
    <>
      {isShowCount && (
        <CountProduct
          id={dataModal.id}
          type={dataModal.type}
          name={dataModal.name}
          description={dataModal.description}
          image={dataModal.image}
          price={dataModal.price}
          isEdit={dataModal.isEdit}
          defaultValue={dataModal.quantity}
          closeModal={closeModal}
          titleModal={titleModal}
          handleAddSubProduct={handleAddSubProduct}
        />
      )}
      <section className="section-padding gray-bg">
        <div className="auto-container">
          <div className="row">
            <div className="col-lg-5">
              <div className="about-1-image-wrap mb_30 p_relative">
                <div
                  className="about-1-shape-1"
                  data-parallax='{"y": -50}'
                ></div>
                <div className="about-1-image-1 hvr-img-zoom-1">
                  <Swiper
                    effect={"creative"}
                    pagination={{
                      type: "progressbar",
                    }}
                    loop={true}
                    creativeEffect={{
                      prev: {
                        shadow: true,
                        origin: "left center",
                        translate: ["-5%", 0, -200],
                        rotate: [0, 100, 0],
                      },
                      next: {
                        origin: "right center",
                        translate: ["5%", 0, -200],
                        rotate: [0, -100, 0],
                      },
                    }}
                    navigation={true}
                    modules={[EffectCreative, Pagination, Navigation]}
                    className="mySwiper"
                  >
                    {data.images?.map((image, index) => (
                      <SwiperSlide key={"img-pd" + index}>
                        <img
                          src={image.imageUrl}
                          style={{ maxHeight: "400px" }}
                          alt=""
                        />
                      </SwiperSlide>
                    ))}
                  </Swiper>
                </div>
                {LIST_SHOW_BOOK.includes(category) && (
                  <div className="about-1-btn mb_30 mt-3 text-center">
                    <a href="#" onClick={handleClick} className="btn-1">
                      Book<span></span>
                    </a>
                  </div>
                )}
              </div>
            </div>
            <div className="col-lg-7 ps-lg-5">
              <div className="section_heading mb_20">
                <span className="section_heading_title_small">
                  {data.address}
                </span>
                <h3 className="section_heading_title_big">
                  {data.name}
                  {data.serviceName}
                </h3>
              </div>
              <p className="aboout-1-desc mb_30 position-relative z-index-99">
                {data.description}
              </p>
              <hr />
              <div className="d-flex p-0 align-items-center gap-3 mb-1">
                <p className="mb-0">Select Event Date:</p>
                <input
                  type="date"
                  defaultValue={date.toISOString().substr(0, 10)}
                  style={{ width: 150 }}
                  className="form-control"
                  min="<?php echo date('2024-m-d'); ?>"
                  onChange={handleSelectTimeZone}
                ></input>
              </div>
              <p>
                Time Zone: <b>MST</b>
              </p>
              <div
                className="btn-group mb-4 d-flex gap-2 flex-wrap"
                role="group"
                aria-label="Basic radio toggle button group"
                onChange={(e) => {
                  setSelectedTimeSlot(e.target.defaultValue);
                }}
              >
                {timeSlots.map((tl) => (
                  <div key={"time-slot-" + tl.id}>
                    <input
                      type="radio"
                      className="btn-check"
                      name="btnradio"
                      id={"btnradio" + tl.id}
                      autoComplete="off"
                      value={tl.id}
                      defaultChecked={Number(selectedTimeSlot) === tl.id}
                    ></input>
                    <label
                      className="btn btn-outline-primary"
                      style={{ width: 100 }}
                      htmlFor={"btnradio" + tl.id}
                    >
                      {tl.startTime}
                    </label>
                  </div>
                ))}
              </div>

              <div className="row mb-4">
                <div
                  className="fw-600 fs-5"
                  style={{ color: "var(--theme-color)" }}
                >
                  Select Tickets:
                </div>
                <span># of adults (Max. Room Seating = 16)</span>
                <div
                  className="input-group input-group-sm"
                  style={{ width: 200 }}
                >
                  <input
                    type="number"
                    className="form-control w-100"
                    aria-label="Sizing example input"
                    value={numberOfAdults}
                    onChange={(event) => setNumberOfAdults(event.target.value)}
                    min={0}
                    aria-describedby="inputGroup-sizing-sm"
                  ></input>
                </div>
                <span>How many kids will be attending?</span>
                <div
                  className="input-group input-group-sm"
                  style={{ width: 200 }}
                >
                  <input
                    type="number"
                    className="form-control"
                    aria-label="Sizing example input"
                    value={numberOfKids}
                    onChange={(event) => setNumberOfKids(event.target.value)}
                    aria-describedby="inputGroup-sizing-sm"
                    min={0}
                  ></input>
                </div>
              </div>
              <button
                className="btn btn-primary form-control"
                onClick={() => setIsAddProducts(!isAddProducts)}
              >
                {isAddProducts ? "Hide Products" : "Add Products"}
              </button>
            </div>
          </div>
          {isAddProducts && (
            <div className="row mt-5 bg-white border-5 p-2">
              <div className={expand ? "col-lg-0" : "col-lg-8"}>
                <Tabs>
                  <TabList>
                    <div style={{ fontSize: "24px", fontWeight: "bold" }}>
                      <Tab>Service Packages</Tab>
                      <Tab>Services</Tab>
                      <Tab>Combos</Tab>
                      <Tab>Foods</Tab>
                    </div>
                  </TabList>
                  <TabPanel>
                    <div className="row">
                      {data?.servicePackages?.map((item, index) => (
                        <div
                          className="p-2 col-md-3 col-sm-4"
                          key={"detail-service-package-item" + index}
                        >
                          <Product
                            name={item.name}
                            price={item.price}
                            item={item}
                            image={item.images[0]?.imageUrl}
                            type="packages"
                            handleClick={handleAddProduct}
                          />
                        </div>
                      ))}
                    </div>
                  </TabPanel>
                  <TabPanel>
                    <div className="row">
                      {data?.services?.map((item, index) => (
                        <div
                          className="p-2 col-md-3 col-sm-4"
                          key={"detail-services-item" + index}
                        >
                          <Product
                            name={item.name}
                            price={item.price}
                            item={item}
                            image={item.image}
                            type="services"
                            handleClick={handleAddProduct}
                          />
                        </div>
                      ))}
                    </div>
                  </TabPanel>
                  <TabPanel>
                    <div className="row">
                      {data?.combos?.map((item, index) => (
                        <div
                          className="p-2 col-md-3 col-sm-4"
                          key={"detail-combos-item" + index}
                        >
                          <Product
                            name={item.name}
                            price={item.price}
                            item={item}
                            image={item.image}
                            type="combos"
                            handleClick={handleAddProduct}
                          />
                        </div>
                      ))}
                    </div>
                  </TabPanel>
                  <TabPanel>
                    <div className="row">
                      {data?.foods?.map((item, index) => (
                        <div
                          className="p-2 col-md-3 col-sm-4"
                          key={"detail-food-item" + index}
                        >
                          <Product
                            name={item.name}
                            price={item.price}
                            item={item}
                            image={item.imageUrl}
                            type="foods"
                            handleClick={handleAddProduct}
                          />
                        </div>
                      ))}
                    </div>
                  </TabPanel>
                </Tabs>
              </div>
              <div
                className={
                  (expand ? "col-lg-12" : "col-lg-4") +
                  " info-payment-container px-0"
                }
              >
                <div className="pb-3 pt-2 fs-2 d-flex justify-content-between">
                  <span>Summary</span>{" "}
                  <i
                    className="fa fa-expand cursor-pointer"
                    onClick={() => setExpand(!expand)}
                  ></i>
                </div>
                <div className="info-payment-content p-3">
                  <div>
                    <b>Event:</b>
                    <p className="mb-1">{data?.name}</p>
                  </div>
                  <div>
                    <b>Packages:</b>
                    {servicePackages?.map((item, index) => {
                      <p
                        className="mb-1"
                        key={"added-service-packages" + index}
                      >
                        {item.name}
                      </p>;
                    })}
                  </div>
                  <div>
                    <b>Services:</b>
                    {services?.map((item, index) => {
                      <p className="mb-1" key={"added-service" + index}>
                        {item.name}
                      </p>;
                    })}
                  </div>
                  <div>
                    <b>Location:</b>
                    <p className="mb-1">{data.address}</p>
                  </div>
                  <div>
                    <b>Time:</b>
                    <p className="mb-1">Lorem, ipsum dolor.</p>
                  </div>
                  <div>
                    <div className="d-flex gap-2">
                      <b>Adults: </b>
                      <p className="mb-1">{numberOfAdults}</p>
                    </div>
                  </div>
                  <div>
                    <div className="d-flex gap-2">
                      <b>Kids: </b>
                      <p className="mb-1">{numberOfKids}</p>
                    </div>
                  </div>
                  <hr />
                  <h5>List Products</h5>
                  <div>
                    <table className="table table-sm table-summary-product">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Name</th>
                          <th scope="col">SL</th>
                          <th scope="col">Price</th>
                          <th scope="col">Total</th>
                          <th scope="col" className="text-center">
                            Action
                          </th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td>{data.name}</td>
                          <td>1</td>
                          <td>{data.price?.toLocaleString() || 0}đ</td>
                          <td>{data.price?.toLocaleString() || 0}đ</td>
                          <td className="text-center">
                            {" "}
                            <i className="fa fa-edit me-1" disabled></i>
                            <i className="fa fa-trash" disabled></i>
                          </td>
                        </tr>
                        {subProducts?.map((item, index) => (
                          <tr key={"sub-product" + index}>
                            <th scope="row">{index + 2}</th>
                            <td>{item.name}</td>
                            <td>{item.quantity}</td>
                            <td>{item.price?.toLocaleString()}đ</td>
                            <td>
                              {(item.price * item.quantity).toLocaleString()}đ
                            </td>
                            <td className="text-center" width={50} height={20}>
                              <button
                                onClick={() => handleEditCountProduct(item)}
                              >
                                <i className="fa fa-edit me-1"></i>
                              </button>
                              <button onClick={() => handleDeleteProduct(item)}>
                                <i className="fa fa-trash"></i>
                              </button>
                            </td>
                          </tr>
                        ))}
                        <tr>
                          <th scope="row" colSpan={4}>
                            Total
                          </th>
                          <td colSpan={2} className="fw-bold text-danger">
                            {(
                              subProducts?.reduce(
                                (accum, item) =>
                                  accum + item.price * item.quantity,
                                0
                              ) + (data.price ? data.price : 0)
                            )?.toLocaleString()}
                            đ
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
                {isAddProducts === true &&
                  LIST_SHOW_BOOK.includes(category) && (
                    <div className="about-1-btn mb_30 mt-3 text-center">
                      <a href="#" onClick={handleClick} className="btn-1 px-5">
                        Book<span></span>
                      </a>
                    </div>
                  )}
              </div>
            </div>
          )}
        </div>
      </section>
    </>
  );
}
