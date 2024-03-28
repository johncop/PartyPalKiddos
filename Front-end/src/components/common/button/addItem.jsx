export const AddButton = ({ fields, handleSubmit }) => {
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
              {fields.map((field, index) => (
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
                  ></input>
                  <datalist id={"datalistOptions" + index}>
                    {field.items.map((item, i) => (
                      <option
                        key={"field-add-item" + i}
                        value={item.id}
                      >{item.value}</option>
                    ))}
                  </datalist>
                </div>
              ))}
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Close
              </button>
              <button
                type="submit"
                className="btn btn-primary"
              >
                Save changes
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
};
