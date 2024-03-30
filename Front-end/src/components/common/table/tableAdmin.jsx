import { DataTable } from "simple-datatables";
import { useEffect } from "react";
import { AddButton } from "../button/addItem";

export const TableAdmin = ({
  btnDataAdd,
  handleSubmit,
  columns,
  data,
  handleEdit,
  handleRemove,
}) => {
  useEffect(() => {
    new DataTable("#datatablesSimple");
  }, [data]);

  function getValue(key, data) {
    let result = data;
    key.split(".").forEach((element) => {
      result = result[element];
    });
    return result;
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
                      onSubmit={(e) => handleEdit(e, item.id)}
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
                        ></button>
                      </div>
                      <div className="modal-body">
                        {btnDataAdd.map((field, indexBtn) => (
                          <div key={"field-eidt" + item.id + indexBtn}>
                            <label
                              htmlFor={"editDataList" + indexBtn}
                              className="form-label mb-0"
                              style={{
                                paddingTop: 2,
                              }}
                            >
                              {field.title}
                            </label>
                            <input
                              type={field.type}
                              disabled={field.disabled}
                              className="form-control"
                              list={"datalistOptions" + indexBtn}
                              id={"editDataList" + indexBtn}
                              placeholder={field.placeholder}
                              required={field.required}
                              defaultValue={getValue(field.key, item)}
                              style={{ width: "100%" }}
                            ></input>
                            <datalist id={"datalistOptions" + indexBtn}>
                              {field.items.map((item, i) => (
                                <option
                                  key={"field-edit-item" + item.id + i}
                                  value={item.id}
                                >
                                  {item.value}
                                </option>
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
                        <button type="submit" className="btn btn-primary">
                          Save changes
                        </button>
                      </div>
                    </form>
                  </div>
                </div>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
