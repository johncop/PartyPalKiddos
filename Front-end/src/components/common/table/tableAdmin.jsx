import { useEffect, useState } from "react";
import { AddButton } from "../button/addItem";
import { InputCommon } from "../input";
import { useDispatch } from "react-redux";
import { SET_STATUS_POPUP } from "../../../constants";
import DataTable from "react-data-table-component";

export const TableAdmin = ({
  state,
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
  const dispatch = useDispatch();
  const [showModal, setShowModal] = useState(null);
  if (!btnDataEdit) {
    btnDataEdit = btnDataAdd;
  }

  if (!columnKeys) {
    columnKeys = columns;
  }

  const [image, setImage] = useState(null);
  const [editData, setEditData] = useState({
    event: null,
    item: null,
  });
  // useEffect(() => {
  //   if (data.length > 0) {
  //     new DataTable("#datatablesSimple", { perPage: 15 });
  //     const elementsArray = document.querySelectorAll(".button-edit-item");
  //     elementsArray.forEach(function (elem) {
  //       elem.addEventListener("click", function (e) {
  //         const dataIndex = data.findIndex(
  //           (item) => item.id === Number(elem.getAttribute("data-id"))
  //         );
  //         modalEdit(data[dataIndex], dataIndex);
  //       });
  //     });
  //   }
  // }, [data]);
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
    setImage(e.target.files);
  }

  useEffect(() => {
    if (editData.event && editData.item) {
      handleEdit(editData.event, editData.item);
      setEditData({
        event: null,
        item: null,
      });
    }
  }, [editData]);
  useEffect(() => {
    if (state.uiState.popup.index !== -1) {
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
                  setEditData({
                    event: e,
                    item: state.uiState.popup.item,
                  });
                  dispatch({
                    type: SET_STATUS_POPUP,
                    popup: {
                      item: {},
                      index: -1,
                    },
                  });
                }}
              >
                <div className="modal-header">
                  <h5
                    className="modal-title"
                    id={"editModalLabel" + state.uiState.popup.item.id}
                  >
                    Edit
                  </h5>
                  <button
                    type="button"
                    className="btn-close"
                    data-bs-dismiss="modal"
                    aria-label="Close"
                    onClick={() => {
                      setImage(null);
                      dispatch({
                        type: SET_STATUS_POPUP,
                        popup: {
                          item: {},
                          index: -1,
                        },
                      });
                      if (addedField) {
                        addedField(state.uiState.popup.item, true);
                      }
                    }}
                  ></button>
                </div>
                <div className="modal-body">
                  {addedField && addedField(state.uiState.popup.item)}

                  {btnDataEdit.map((field, indexBtn) => {
                    if (field.multiple && field.type !== "file") {
                      field.onChange(
                        getValue(
                          field.type,
                          field.key,
                          state.uiState.popup.item,
                          field.multiple
                        )
                      );
                    }
                    return (
                      <InputCommon
                        key={"edit-new-field" + indexBtn}
                        type={field.type}
                        title={field.title}
                        changeImage={changeImage}
                        placeholder={field.placeholder}
                        required={field.required}
                        disabled={field.disabled}
                        image={image}
                        index={state.uiState.popup.index}
                        items={field.items}
                        handleChange={field.onChange}
                        id={"edit-field-item" + indexBtn}
                        multiple={field.multiple}
                        defaultValue={getValue(
                          field.type,
                          field.key,
                          state.uiState.popup.item,
                          field.multiple
                        )}
                        defaultImage={
                          field.type === "file"
                            ? field.getImageUrls(state.uiState.popup.item)
                            : null
                        }
                      />
                    );
                  })}
                </div>
                <div className="modal-footer">
                  <button
                    type="button"
                    className="btn btn-secondary"
                    data-bs-dismiss="modal"
                    onClick={() => {
                      setImage(null);
                      dispatch({
                        type: SET_STATUS_POPUP,
                        popup: {
                          item: {},
                          index: -1,
                        },
                      });
                      if (addedField) {
                        addedField(state.uiState.popup.item, true);
                      }
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
    } else {
      setShowModal(null);
    }
  }, [state.uiState.popup]);

  const modalEdit = (item, index) => {
    dispatch({
      type: SET_STATUS_POPUP,
      popup: {
        item: item,
        index: index,
      },
    });
  };

  const tableColumns = columns.map((col, index) => {
    return {
      name: col,
      selector: (dt) => getValue(null, columnKeys[index], dt, false),
      sortable: true,
    };
  });

  tableColumns.push({
    name: "Status",
    selector: (dt, index) => {
      return (
        <>
          <button
            className="button-edit-item"
            id={`button-edit-item-${dt.id}`}
            data-id={dt.id}
            onClick={() => modalEdit(dt, index)}
            style={{ backgroundColor: "transparent" }}
          >
            <i className="fa fa-edit me-1"></i>
          </button>
          <i
            className="fa fa-trash"
            onClick={() => {}}
            data-bs-toggle="modal"
            data-bs-target={"#modalRemoveItem" + dt.id}
          ></i>
        </>
      );
    },
  });

  return (
    <div className="card mb-4">
      <div className="card-header">
        <i className="fas fa-table me-1"></i>{" "}
        <AddButton fields={btnDataAdd} handleSubmit={handleSubmit} />
      </div>
      <div className="card-body">
        <DataTable
          columns={tableColumns}
          data={data}
          pagination={true}
          onRowsPerPage={10}
          dense
          fixedHeader={true}
          width={"100vh"}
        />
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
