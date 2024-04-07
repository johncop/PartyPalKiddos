import { DataTable } from "simple-datatables";
import { useEffect, useState } from "react";
import { AddButton } from "../button/addItem";
import { InputCommon } from "../input";

export const TableAdmin = ({
  btnDataAdd,
  btnDataEdit,
  handleSubmit,
  columns,
  data,
  handleEdit,
  handleRemove,
}) => {
  if (!btnDataEdit) {
    btnDataEdit = btnDataAdd;
  }
  const [image, setImage] = useState(null);
  useEffect(() => {
    if (data.length > 0) {
      new DataTable("#datatablesSimple");
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
            {data.map((item, index) => (
              <tr key={"item-value-" + index}>
                {columns.map((column, index) => (
                  <td key={"colum-table-" + index}>{item[column]}</td>
                ))}
                <td className="text-center">
                  {" "}
                  <i
                    className="fa fa-edit me-1"
                    onClick={() => {}}
                    data-bs-toggle="modal"
                    data-bs-target={"#modalEditItem" + item.id}
                  ></i>
                  <i
                    className="fa fa-trash"
                    onClick={() => {}}
                    data-bs-toggle="modal"
                    data-bs-target={"#modalRemoveItem" + item.id}
                  ></i>
                </td>
              </tr>
            ))}
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

          {/* Moadl Edit */}
          <div
            className="modal fade"
            id={"modalEditItem" + item.id}
            tabIndex="-1"
            aria-labelledby={"editModalLabel" + item.id}
            aria-hidden="true"
            style={{ textAlign: "left", fontSize: "16px" }}
          >
            <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
              <form
                className="modal-content"
                onSubmit={(e) => handleEdit(e, item)}
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
                    onClick={() => setImage(null)}
                  ></button>
                </div>
                <div className="modal-body">
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
                    onClick={() => setImage(null)}
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
        </div>
      ))}
    </div>
  );
};
