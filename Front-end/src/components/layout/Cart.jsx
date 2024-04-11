import { useEffect } from "react";
import { TBCart } from "../common/table/TBCart";
import axios from "axios";
import { UPDATE_CART_ACTION } from "../../constants";
import { useDispatch } from "react-redux";

export function Cart() {
  const dispatch = useDispatch();

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}bookings`)
      .then((response) => {
        dispatch({
          type: UPDATE_CART_ACTION,
          carts: response.data.data,
        });
        return response;
      })
      .catch((error) => {
        return error;
      });
  });
  return (
    <>
      <section className="section-padding py-4">
        <div className="auto-container">
          <div className="cart-container">
            <h4 className="py-2">Shopping Cart</h4>
            <hr />
            <div className="bg-white">
              <TBCart />
            </div>
            <div className="text-center mt-4 py-4 d-flex gap-2 justify-content-center">
              <button className="btn btn-outline-primary px-5">CLEAR</button>
              <button className="btn btn-primary px-5">CONFIRM</button>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
