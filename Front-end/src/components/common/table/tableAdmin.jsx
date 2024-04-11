import { DataTable } from "simple-datatables";
import { useEffect, useState } from "react";
import { AddButton } from "../button/addItem";
import { InputCommon } from "../input";

export const TableAdmin = ({
  btnDataAdd,
  btnDataEdit,
  handleSubmit,
  columns,
  columnKeys,
  data,
  handleEdit,
  handleRemove,
  addedField,
}) => {
  const [showModal, setShowModal] = useState(null);
  if (!btnDataEdit) {
    btnDataEdit = btnDataAdd;
  }

  if (!columnKeys) {
    columnKeys = columns;
  }

  const [image, setImage] = useState(null);
  useEffect(() => {
    if (data.length > 0) {
      new DataTable("#datatablesSimple", { perPage: 15 });
      const elementsArray = document.querySelectorAll(".button-edit-item");
      elementsArray.forEach(function (elem) {
        elem.addEventListener("click", function (e) {
          const dataIndex = data.findIndex(
            (item) => item.id === Number(elem.getAttribute("data-id"))
          );
          modalEdit(data[dataIndex], dataIndex);
        });
      });
    }
  }, [data]);
  function getValue(type, key, data, multiple) {
    if (type === "file") {
      return null;
    } else if (multiple) {
      return data[key]?.map((value) => {
        return {
          value: value.id,
          label: value.name,
        };
      });
    }
    let result = data;
    key.split(".").forEach((element) => {
      if (result === null && result === undefined) {
        return;
      }
      result = result[element];
    });
    return result;
  }

  function changeImage(e) {
    setImage(e.target.files[0]);
  }

  function modalEdit(item, index) {
    setShowModal(
      <>
        <div
          className={`modal fade show`}
          style={{ display: "block" }}
          tabIndex="-1"
          role="dialog"
          aria-labelledby="exampleEditModalLabel"
          aria-hidden={!false}
        >
          <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <form
              className="modal-content"
              onSubmit={(e) => {
                handleEdit(e, item);
                setShowModal(null);
              }}
            >
              <div className="modal-header">
                <h5 className="modal-title" id={"editModalLabel" + item.id}>
                  Edit
                </h5>
                <button
                  type="button"
                  className="btn-close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
                  onClick={() => {
                    setImage(null);
                    setShowModal(null);
                  }}
                ></button>
              </div>
              <div className="modal-body">
                {addedField}

                {btnDataEdit.map((field, indexBtn) => (
                  <InputCommon
                    key={"edit-new-field" + indexBtn}
                    type={field.type}
                    title={field.title}
                    changeImage={changeImage}
                    placeholder={field.placeholder}
                    required={field.required}
                    image={image}
                    index={index}
                    items={field.items}
                    handleChange={field.onChange}
                    id={"edit-field-item" + indexBtn}
                    multiple={field.multiple}
                    defaultValue={getValue(
                      field.type,
                      field.key,
                      item,
                      field.multiple
                    )}
                    defaultImage={
                      field.type === "file" ? field.getImageUrls(item) : null
                    }
                  />
                ))}
              </div>
              <div className="modal-footer">
                <button
                  type="button"
                  className="btn btn-secondary"
                  data-bs-dismiss="modal"
                  onClick={() => {
                    setImage(null);
                    setShowModal(null);
                  }}
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
        <div className="modal-backdrop fade show"></div>
      </>
    );
  }

  return (
    <div className="card mb-4">
      <div className="card-header">
        <i className="fas fa-table me-1"></i>{" "}
        <AddButton fields={btnDataAdd} handleSubmit={handleSubmit} />
      </div>
      <div className="card-body">
        <table id="datatablesSimple">
          <thead>
            <tr>
              {columns.map((column, index) => (
                <th key={"colum-table-1-" + index}>{column}</th>
              ))}
              <th className="text-center">Actions</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => {
              return (
                <tr key={"item-value-" + index}>
                  {columnKeys.map((column, i) => (
                    <td key={"colum-table-" + index + "-" + i}>
                      {getValue(null, column, item, false)}
                    </td>
                  ))}
                  <td className="text-center">
                    <button
                      className="button-edit-item"
                      id={`button-edit-item-${item.id}`}
                      data-id={item.id}
                      style={{ backgroundColor: "transparent" }}
                    >
                      <i className="fa fa-edit me-1"></i>
                    </button>
                    <i
                      className="fa fa-trash"
                      onClick={() => {}}
                      data-bs-toggle="modal"
                      data-bs-target={"#modalRemoveItem" + item.id}
                    ></i>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>

      {data.map((item, index) => (
        <div key={"item-modal-" + index}>
          {/* Moadl Remove */}
          <div
            className="modal fade"
            id={"modalRemoveItem" + item.id}
            tabIndex="-1"
            aria-labelledby={"removeModalLabel" + item.id}
            aria-hidden="true"
          >
            <div className="modal-dialog">
              <div className="modal-content">
                <div className="modal-header">
                  <h5 className="modal-title" id={"removeModalLabel" + item.id}>
                    Remove Item
                  </h5>
                  <button
                    type="button"
                    className="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Close"
                  ></button>
                </div>
                <div className="modal-body">
                  Are you sure to remove this element from the list?
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
                    type="button"
                    data-bs-dismiss="modal"
                    className="btn btn-danger"
                    onClick={() => handleRemove(item.id)}
                  >
                    Remove
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      ))}
      {showModal}
    </div>
  );
};
