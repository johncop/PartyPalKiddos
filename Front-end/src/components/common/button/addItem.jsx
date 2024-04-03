import { useState } from "react";

export const AddButton = ({ fields, handleSubmit }) => {
  const [image, setImage] = useState(null);

  function changeImage(e) {
    setImage(e.target.files[0]);
  }
  return (
    <>
      <button
        className="btn btn-primary btn-sm ms-2"
        data-bs-toggle="modal"
        data-bs-target="#exampleModal"
      >
        Add New
      </button>

      {/* Moadl add new */}
      <div
        className="modal fade"
        id="exampleModal"
        tabIndex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
          <form className="modal-content" onSubmit={(e) => handleSubmit(e)}>
            <div className="modal-header">
              <h5 className="modal-title" id="exampleModalLabel">
                Add new
              </h5>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div className="modal-body">
              {fields.map((field, index) =>
                field.type === "checkbox" ? (
                  <div class="form-check form-switch">
                    <input
                      class="form-check-input"
                      type="checkbox"
                      id={"flexSwitchCheckChecked" + index}
                    />
                    <label
                      class="form-check-label"
                      for={"flexSwitchCheckChecked" + index}
                    >
                      {field.title}
                    </label>
                  </div>
                ) : (
                  <div key={"field-add" + index}>
                    <label
                      htmlFor={"exampleDataList" + index}
                      className="form-label mb-0"
                    >
                      {field.title}
                    </label>
                    <input
                      type={field.type}
                      className="form-control"
                      list={"datalistOptions" + index}
                      id={"exampleDataList" + index}
                      placeholder={field.placeholder}
                      required={field.required}
                      style={{ width: "100%" }}
                      onChange={field.type === "file" ? changeImage : null}
                    ></input>
                    {field.type === "file" && (
                      <img
                        src={
                          image
                            ? URL.createObjectURL(image)
                            : "https://th.bing.com/th/id/OIP.N-IegjWZz_67sr8v2233mwHaFO?w=283&h=200&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        }
                        className="img-fluid"
                        alt=""
                      ></img>
                    )}
                    <datalist id={"datalistOptions" + index}>
                      {field.items.map((item, i) => (
                        <option key={"field-add-item" + i} value={item.id}>
                          {item.value}
                        </option>
                      ))}
                    </datalist>
                  </div>
                )
              )}
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
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
    </>
  );
};
