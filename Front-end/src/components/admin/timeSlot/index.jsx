import { useState } from "react";
import Select from "react-select";

export const AddTimeSlotButton = ({ handleSubmit, defaultvalue }) => {
  const [showModal, setShowModal] = useState(false);
  const [status, setStatus] = useState(false);
  const [days, setDays] = useState([]);
  const [startTime, setStartTime] = useState(null);
  const [endTime, setEndTime] = useState(null);
  function handleChange(value) {
    setDays(value);
  }
  const handleOnClick = () => {
    handleSubmit({ startTime, endTime, status, days });

    handleCloseModal();
  };
  const handleCloseModal = () => {
    setShowModal(false);
  };

  function resetData() {
    setShowModal(true);
    setStatus(false);
    setStartTime(null);
    setEndTime(null);
    setDays([]);
  }

  return (
    <>
      <div
        className="btn btn-primary btn-sm ms-2"
        onClick={() => resetData()}
        style={{ width: "100%" }}
      >
        Add Time Slot
      </div>
      {defaultvalue.map((timeSlot) => {
        return (
          <div class="btn btn-secondary" disabled>
            {timeSlot.days}
          </div>
        );
      })}

      {/* Moadl add new */}
      {showModal && (
        <>
          <div
            className={`modal fade ${showModal ? "show" : ""}`}
            style={{ display: showModal ? "block" : "none" }}
            tabIndex="-1"
            role="dialog"
            aria-labelledby="exampleModalLabel"
            aria-hidden={!showModal}
          >
            <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
              <div className="modal-content">
                <div className="modal-header">
                  <h5 className="modal-title" id="exampleModalLabelTimeSlot">
                    Add new
                  </h5>
                  <div
                    type="button"
                    className="btn-close"
                    onClick={handleCloseModal}
                    aria-label="Close"
                  ></div>
                </div>
                <div className="modal-body">
                  <label
                    htmlFor={"exampleDataListStartTime"}
                    className="form-label mb-0"
                  >
                    Start Time
                  </label>
                  <input
                    type={"time"}
                    className="form-control"
                    id={"exampleDataListStartTime"}
                    required={true}
                    value={startTime}
                    onChange={(e) => setStartTime(e.target.value)}
                    style={{ width: "100%" }}
                  ></input>
                  <label
                    htmlFor={"exampleDataListEndTime"}
                    className="form-label mb-0"
                  >
                    End Time
                  </label>
                  <input
                    type={"time"}
                    value={endTime}
                    className="form-control"
                    id={"exampleDataListEndTime"}
                    required={true}
                    onChange={(e) => setEndTime(e.target.value)}
                    style={{ width: "100%" }}
                  ></input>
                  <div>
                    <label className="form-check-label">Day of Week</label>
                    <Select
                      maxMenuHeight={200}
                      onChange={handleChange}
                      options={[
                        { value: "Monday", label: "Monday" },
                        { value: "Tuesday", label: "Tuesday" },
                        { value: "Wednesday", label: "Wednesday" },
                        { value: "Thursday", label: "Thursday" },
                        { value: "Friday", label: "Friday" },
                        { value: "Saturday", label: "Saturday" },
                        { value: "Sunday", label: "Sunday" },
                      ]}
                      defaultValue={[]}
                      isMulti={true}
                    />
                  </div>
                  <div className="form-check form-switch">
                    <input
                      className="form-check-input"
                      type="checkbox"
                      id={"flexSwitchCheckChecked"}
                      checked={status}
                      onChange={(e) => setStatus(e.target.checked)}
                    />
                    <label
                      className="form-check-label"
                      htmlFor={"flexSwitchCheckChecked"}
                    >
                      Status
                    </label>
                  </div>
                </div>
                <div className="modal-footer">
                  <div
                    type="button"
                    className="btn btn-secondary"
                    onClick={handleCloseModal}
                  >
                    Close
                  </div>
                  <div className="btn btn-primary" onClick={handleOnClick}>
                    Save changes
                  </div>
                </div>
              </div>
            </div>
          </div>

          {showModal && <div className="modal-backdrop fade show"></div>}
        </>
      )}
    </>
  );
};
