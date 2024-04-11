import { useState } from "react";
import { InputCommon } from "../input";

export const AddButton = ({ fields, handleSubmit }) => {
  const [image, setImage] = useState(null);
  const [showModal, setShowModal] = useState(false);
  function changeImage(e) {
    setImage(e.target.files[0]);
  }
  const handleOnSubmit = (e) => {
    handleSubmit(e);
    setShowModal(false);
  };
  const handleCloseModal = () => {
    setShowModal(false);
  };
  return (
    <>
      <button
        className="btn btn-primary btn-sm ms-2"
        onClick={() => setShowModal(true)}
      >
        Add New
      </button>

      {/* Moadl add new */}
      <div
        className={`modal fade ${showModal ? "show" : ""}`}
        style={{ display: showModal ? "block" : "none" }}
        tabIndex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden={!showModal}
      >
        <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
          <form className="modal-content" onSubmit={(e) => handleOnSubmit(e)}>
            <div className="modal-header">
              <h5 className="modal-title" id="exampleModalLabel">
                Add new
              </h5>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
                onClick={handleCloseModal}
              ></button>
            </div>
            <div className="modal-body">
              {fields.map((field, index) => (
                <InputCommon
                  key={"add-new-field" + index}
                  type={field.type}
                  title={field.title}
                  changeImage={changeImage}
                  placeholder={field.placeholder}
                  required={field.required}
                  image={image}
                  index={index}
                  items={field.items}
                  id={"add-field-item" + index}
                  multiple={field.multiple}
                  handleChange={field.onChange}
                  defaultValue={field.defaultValue}
                />
              ))}
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
                onClick={handleCloseModal}
              >
                Close
              </button>
              <button type="submit" className="btn btn-primary">
                Save changes
              </button>
            </div>
          </form>
        </div>
      </div>
      {showModal && <div className="modal-backdrop fade show"></div>}
    </>
  );
};
