import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export function TBCart() {
  const state = useSelector((state) => state);

  const [isCheckAll, setIsCheckAll] = useState(false);
  const [carts, setCarts] = useState([]);
  useEffect(() => {
    setCarts(
      state.uiState.carts.map((item) => {
        return { ...item, isCheck: false };
      })
    );
  }, [state.uiState.carts]);
  useEffect(() => {
    setCarts(
      state.uiState.carts.map((item) => {
        return { ...item, isCheck: isCheckAll };
      })
    );
  }, [isCheckAll]);

  function handleDelete(id) {
    axios
    .delete(`${process.env.REACT_APP_API_BASE_URL}bookings/${id}`)
    .then((response) => {
      toast.info("Successful deletion", {
        position: "bottom-center",
        autoClose: 2000,
      });
    })
    .catch((error) => {
      toast.error("Delete failed due to some exception", {
        position: "bottom-center",
        autoClose: 2000,
      });
    });
  }

  return (
    <>
      <div className="table-responsive">
        <table className="table table-sm table-summary-product table-bordered mb-0">
          <thead>
            <tr>
              <th scope="col" className="text-center">
                #
              </th>
              <th scope="col" className="text-center" style={{ width: "60px" }}>
                <input
                  type="checkbox"
                  checked={isCheckAll}
                  onChange={() => setIsCheckAll(!isCheckAll)}
                />
              </th>
              <th scope="col">Name</th>
              <th scope="col">Total</th>
              <th scope="col" style={{ width: "50px" }} className="text-center">
                Action
              </th>
            </tr>
          </thead>
          <tbody>
            {carts.map((item, index) => (
              <tr className="align-middle">
                <th scope="row" className="text-center">
                  {index + 1}
                </th>
                <td className="text-danger fw-bold text-center">
                  <input
                    type="checkbox"
                    checked={item.isCheck}
                    onChange={(e) => {
                      setCarts(
                        carts.map((cart) => {
                          if (cart.id === item.id) {
                            return {
                              ...cart,
                              isCheck: e.target.checked,
                            };
                          } else {
                            return cart;
                          }
                        })
                      );
                    }}
                  />
                </td>
                <td>
                  <div className="name-product d-flex align-items-center gap-3">
                    <div style={{ width: "100px", height: "100px" }}>
                      <img
                        className="d-block"
                        src={item.venue.image.imageUrl}
                        alt=""
                      />
                    </div>
                    <a href={`cart/${item.id}`} className="fw-bold mouse-event">
                      {item.venue.name}
                    </a>
                  </div>
                </td>
                <td className="text-danger fw-bold">
                  {(
                    item.venue.price +
                    item.bookingDetail.servicePackages?.reduce(
                      (accum, it) => accum + it.price * it.quantity,
                      0
                    ) +
                    item.bookingDetail.foods?.reduce(
                      (accum, it) => accum + it.price * it.quantity,
                      0
                    ) +
                    item.bookingDetail.combos?.reduce(
                      (accum, it) => accum + it.price * it.quantity,
                      0
                    ) +
                    item.bookingDetail.services?.reduce(
                      (accum, it) => accum + it.price * it.quantity,
                      0
                    )
                  ).toLocaleString()}
                </td>
                <td className="text-center">
                  <i className="fa fa-trash" onClick={() => handleDelete(item.id)}></i>
                </td>
              </tr>
            ))}
            <tr>
              <th scope="row" colSpan={3}>
                Total
              </th>
              <td colSpan={2} className="text-danger fw-bold">
                {carts
                  .reduce(
                    (total, item) =>
                      total +
                      item.venue.price +
                      item.bookingDetail.servicePackages?.reduce(
                        (accum, it) => accum + it.price * it.quantity,
                        0
                      ) +
                      item.bookingDetail.foods?.reduce(
                        (accum, it) => accum + it.price * it.quantity,
                        0
                      ) +
                      item.bookingDetail.combos?.reduce(
                        (accum, it) => accum + it.price * it.quantity,
                        0
                      ) +
                      item.bookingDetail.services?.reduce(
                        (accum, it) => accum + it.price * it.quantity,
                        0
                      ),
                    0
                  )
                  .toLocaleString()}
                đ
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <ToastContainer />
    </>
  );
}
