import { useParams } from "react-router-dom";
import BannerAbout from "./bannerAbout";
import { LIST_CATE, LIST_SHOW_BOOK } from "../../constants";
import axios from "axios";
import { useState } from "react";
import { Product } from "./Product";
import { CountProduct } from "./modal/CountProduct";

export default function Details() {
  let { category, id } = useParams();
  const [data, setData] = useState({});
  const [isAddProducts, setIsAddProducts] = useState(false)
  const [isShowCount, setIsShowCount] = useState(false)
  const [expand, setExpand] = useState(false)
  const [titleModal, setTitleModal] = useState("Add Product")

  if (category === LIST_CATE.PARTY_SERVICES && !data.id) {
    axios
      .get(process.env.REACT_APP_API_BASE_URL + "Service/services/" + id)
      .then((response) => {
        setData(response.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }

  function handleSelectTimeZone(e) {

  }

  function handleDeleteProduct() {

  }

  function closeModal() {
    setIsShowCount(false);
  }

  function handleEditCountProduct() {
    setIsShowCount(true);
    setTitleModal("Edit Product")
  }

  return (
    <>
      {
        isShowCount && <CountProduct closeModal={closeModal} titleModal={titleModal} />
      }
      <BannerAbout />
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
                  <img
                    src="https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg"
                    style={{ maxHeight: "400px" }}
                    alt=""
                  />
                </div>
                {LIST_SHOW_BOOK.includes(category) && (
                  <div className="about-1-btn mb_30 mt-3 text-center">
                    <a href={`/${category}/booking/${id}`} className="btn-1">
                      Book<span></span>
                    </a>
                  </div>
                )}
              </div>
            </div>
            <div className="col-lg-7 ps-lg-5">
              <div className="section_heading mb_20">
                <span className="section_heading_title_small">
                  About PartyPal Kiddos
                </span>
                <h3 className="section_heading_title_big">
                  Lorem, ipsum dolor sit
                  {data.serviceName}
                </h3>
              </div>
              <p className="aboout-1-desc mb_30 position-relative z-index-99">
                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quo quod sed, error eos vitae natus unde deserunt eaque maiores enim tempora earum voluptatibus? Cupiditate dolor sed sint minus rerum nihil.
                {data.description}
              </p>
              <hr />
              <div className="d-flex p-0 align-items-center gap-3 mb-1">
                <p className="mb-0">Select Event Date:</p>
                <input type="date" style={{ width: 150 }} className="form-control" min="<?php echo date('2024-m-d'); ?>"></input>
              </div>
              <p>Time Zone: <b>MST</b></p>
              <div className="btn-group mb-4 d-flex gap-2 flex-wrap" role="group" aria-label="Basic radio toggle button group">
                <div>
                  <input type="radio" className="btn-check" name="btnradio" id="btnradio1" autoComplete="off"></input>
                  <label className="btn btn-outline-primary" style={{ width: 100 }} htmlFor="btnradio1">11:10pm</label>
                </div>
                <div>
                  <input type="radio" className="btn-check" name="btnradio" id="btnradio2" autoComplete="off"></input>
                  <label className="btn btn-outline-primary" style={{ width: 100 }} htmlFor="btnradio2">12:10pm</label>
                </div>
                <div>
                  <input type="radio" className="btn-check" name="btnradio" id="btnradio3" autoComplete="off"></input>
                  <label className="btn btn-outline-primary" style={{ width: 100 }} htmlFor="btnradio3">00:00am</label>
                </div>
                <div>
                  <input type="radio" className="btn-check" name="btnradio" id="btnradio4" autoComplete="off"></input>
                  <label className="btn btn-outline-primary" style={{ width: 100 }} htmlFor="btnradio4">01:00am</label>
                </div>
                <div>
                  <input type="radio" className="btn-check" name="btnradio" id="btnradio5" autoComplete="off"></input>
                  <label className="btn btn-outline-primary" style={{ width: 100 }} htmlFor="btnradio5">03:00am</label>
                </div>
              </div>

              <div className="row mb-4">
                <div className="fw-600 fs-5" style={{ color: "var(--theme-color)" }}>Select Tickets:</div>
                <span># of adults (Max. Room Seating = 16)</span>
                <div className="input-group input-group-sm" style={{ width: 200 }}>
                  <input type="number" className="form-control w-100" aria-label="Sizing example input" defaultValue={0} aria-describedby="inputGroup-sizing-sm"></input>
                </div>
                <span>How many kids will be attending?</span>
                <div className="input-group input-group-sm" style={{ width: 200 }}>
                  <input type="number" className="form-control" aria-label="Sizing example input" defaultValue={0} aria-describedby="inputGroup-sizing-sm"></input>
                </div>
              </div>
              <button className="btn btn-primary form-control" onClick={() => setIsAddProducts(!isAddProducts)}>{isAddProducts ? "Hide Products" : "Add Products"}</button>

            </div>
          </div>
          {
            isAddProducts &&
            <div className="row mt-5 bg-white border-5 p-2">
              <div className={expand ? "col-lg-0" : "col-lg-8"}>
                <div className="pb-3 pt-2 fs-2">Add Products</div>
                <div className="row">
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />
                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />

                  </div>
                  <div className="p-2 col-md-3 col-sm-4">
                    <Product setIsShowCount={setIsShowCount} />
                  </div>
                </div>
              </div>
              <div className={(expand ? "col-lg-12" : "col-lg-4") + " info-payment-container px-0"}>
                <div className="pb-3 pt-2 fs-2 d-flex justify-content-between"><span>Summary</span> <i className="fa fa-expand cursor-pointer" onClick={() => setExpand(!expand)}></i></div>
                <div className="info-payment-content p-3">
                  <div>
                    <b>Event:</b>
                    <p className="mb-1">Lorem, ipsum dolor.</p>
                  </div>
                  <div>
                    <b>Category:</b>
                    <p className="mb-1">Lorem, ipsum.</p>
                  </div>
                  <div>
                    <b>Package:</b>
                    <p className="mb-1">Lorem ipsum dolor sit amet.</p>
                  </div>
                  <div>
                    <b>Location:</b>
                    <p className="mb-1">Lorem ipsum dolor, sit amet consectetur adipisicing elit. Possimus nesciunt hic eos! Totam, impedit ipsum?</p>
                  </div>
                  <div>
                    <b>Time:</b>
                    <p className="mb-1">Lorem, ipsum dolor.</p>
                  </div>
                  <div>
                    <div className="d-flex gap-2"><b>Adults: </b><p className="mb-1">5</p></div>
                  </div>
                  <div>
                    <div className="d-flex gap-2"><b>Kids: </b><p className="mb-1">5</p></div>
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
                          <th scope="col" className="text-center">Action</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td>Lorem ipsum dolor</td>
                          <td>4</td>
                          <td>25.000đ</td>
                          <td>100.000đ</td>
                          <td className="text-center"> <i className="fa fa-edit me-1" onClick={() => handleEditCountProduct()}></i><i className="fa fa-trash" onClick={() => handleDeleteProduct()}></i></td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>Lorem.</td>
                          <td>4</td>
                          <td>25.000đ</td>
                          <td>100.000đ</td>
                          <td className="text-center"> <i className="fa fa-edit me-1" onClick={() => handleEditCountProduct()}></i><i className="fa fa-trash" onClick={() => handleDeleteProduct()}></i></td>
                        </tr>
                        <tr>
                          <th scope="row">3</th>
                          <td>Lorem.</td>
                          <td>4</td>
                          <td>25.000đ</td>
                          <td>100.000đ</td>
                          <td className="text-center"> <i className="fa fa-edit me-1" onClick={() => handleEditCountProduct()}></i><i className="fa fa-trash" onClick={() => handleDeleteProduct()}></i></td>
                        </tr>
                        <tr>
                          <th scope="row">4</th>
                          <td>Lorem.</td>
                          <td>4</td>
                          <td>25.000đ</td>
                          <td>100.000đ</td>
                          <td className="text-center"> <i className="fa fa-edit me-1" onClick={() => handleEditCountProduct()}></i><i className="fa fa-trash" onClick={() => handleDeleteProduct()}></i></td>
                        </tr>
                        <tr>
                          <th scope="row">5</th>
                          <td>Lorem.</td>
                          <td>4</td>
                          <td>25.000đ</td>
                          <td>100.000đ</td>
                          <td className="text-center"> <i className="fa fa-edit me-1" onClick={() => handleEditCountProduct()}></i><i className="fa fa-trash" onClick={() => handleDeleteProduct()}></i></td>
                        </tr>
                        <tr>
                          <th scope="row" colSpan={4}>Total</th>
                          <td colSpan={2} className="fw-bold text-danger">100.000đ</td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
                {isAddProducts === true && LIST_SHOW_BOOK.includes(category) && (
                  <div className="about-1-btn mb_30 mt-3 text-center">
                    <a href={`/cart`} className="btn-1 px-5">
                      Book<span></span>
                    </a>
                  </div>
                )}
              </div>
            </div>
          }

        </div>
      </section>

    </>
  );
}
