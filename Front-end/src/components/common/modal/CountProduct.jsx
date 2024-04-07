import { useState } from "react";

export function CountProduct(props) {
  const {
    closeModal,
    titleModal,
    price,
    name,
    description,
    image,
    handleAddSubProduct,
    type,
    id,
    isEdit,
    defaultValue,
  } = props;
  const [quantity, setQuantity] = useState(isEdit ? defaultValue : 1);
  function handleOnClick(type, id, quantity) {
    handleAddSubProduct(
      type,
      id,
      quantity,
      name,
      price,
      image,
      description,
      isEdit
    );
    closeModal(false);
  }

  return (
    <>
      <div className="modal-container-full-screen">
        <div className="count-product-container" id="countProductModal">
          <div
            className="login-overlay"
            onClick={() => closeModal(false)}
          ></div>
          <div className="login-content">
            <div className="modal-header">
              <h4 className="modal-title">{titleModal}</h4>
              <button
                type="button"
                className="close close-btn-modal"
                data-dismiss="modal"
                onClick={() => closeModal(false)}
              >
                &times;
              </button>
            </div>
            <div className="modal-body">
              <form>
                <div className="pb-3 modal-count-product-content">
                  <div className="img-product-container px-0">
                    <img src={image} alt="img-product" />
                    <div className="product-price">
                      {price.toLocaleString()}đ
                    </div>
                  </div>
                  <div className="px-0 ps-sm-3">
                    <h5 className="mb-2">{name}</h5>
                    <p>{description}</p>
                    <div>
                      <b>Price:</b> <span>{price.toLocaleString()}đ</span>
                    </div>
                    <div>
                      <div className="fw-bold">Quantity:</div>
                      <input
                        type="number"
                        className="form-control w-100 mb-4"
                        min={0}
                        value={quantity}
                        onChange={(e) => setQuantity(e.target.value)}
                      />
                    </div>
                  </div>
                </div>
                <div className="d-flex gap-1 count-product-btn-group">
                  <button
                    className="btn btn-outline-primary w-100"
                    onClick={() => closeModal(false)}
                  >
                    Cancel
                  </button>
                  <button
                    className="btn btn-primary w-100"
                    onClick={() => handleOnClick(type, id, quantity)}
                  >
                    Save
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
