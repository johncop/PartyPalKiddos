import { useSelector } from "react-redux";
import { useEffect, useState } from "react";

export default function BannerHomePage(props) {
  const { showText } = props;
  const state = useSelector((state) => state);
  const [categories, setCategories] = useState([]);
  const [locations, setLocations] = useState([]);
  const [selectedCate, setSelectedCate] = useState(null);
  const [selectedLocation, setSelectedLocation] = useState(null);

  useEffect(() => {
    setCategories(state.uiState.categories);
  }, [state.uiState.categories]);
  useEffect(() => {
    setLocations(state.uiState.locations);
  }, [state.uiState.locations]);

  function handleSearch() {
    window.location.href = `./search?service=${selectedCate || ""}&location=${
      selectedLocation || ""
    }`;
  }

  function formSearch() {
    return (
      <div className="form-search row w-100">
        <div className="col-md-4 pe-1 ps-1 my-1">
          <select
            defaultValue="0"
            className="form-select"
            aria-label="Default select example"
            onChange={(e) => setSelectedCate(e.target.value)}
          >
            <option value="0">Select Category</option>
            {categories.map((item) => (
              <option key={"category-selection" + item.id} value={item.id}>
                {item.name}
              </option>
            ))}
          </select>
        </div>
        <div className="col-md-4 pe-1 ps-1 my-1">
          <select
            defaultValue="0"
            className="form-select"
            aria-label="Default select example"
            onChange={(e) => setSelectedLocation(e.target.value)}
          >
            <option value="0">Select Location</option>
            {locations.map((item) => (
              <option key={"location-selection" + item.id} value={item.id}>
                {item.description}
              </option>
            ))}
          </select>
        </div>
        <div className="col-md-4 pe-1 ps-1 my-1">
          <button
            type="button"
            className="btn btn-info w-100"
            onClick={handleSearch}
          >
            Search
          </button>
        </div>
      </div>
    );
  }

  return (
    <>
      {showText ? (
        <div className="container-fluid banner-container banner-filter-container d-flex justify-content-center align-items-end p-3">
          <div className="position-absolute start-0 bottom-0 top-0 end-0">
            <img
              src={"/assets/images/banner1.jpg"}
              alt=""
              className="w-100 h-100 d-block"
            />
          </div>
          <div className="banner-content d-flex flex-column gap-3 justify-content-center align-items-center position-absolute z-index-99">
            <h2 className="fw-bold mb-sm-3 text-center text-white animation-type-text">
              Your Birthday, Your Way
            </h2>
            {formSearch()}
          </div>
        </div>
      ) : (
        <div className="container-fluid banner-container banner-filter-container d-flex justify-content-center align-items-end p-3">
          <div className="position-absolute start-0 bottom-0 top-0 end-0">
            <img
              src={"/assets/images/banner1.jpg"}
              alt=""
              className="w-100 h-100 d-block"
            />
          </div>
          <div className="banner-content d-flex flex-column gap-3 justify-content-center align-items-center position-absolute z-index-99">
            {formSearch()}
            <a href="/home">
              <button className="btn btn-primary px-5">
                <i className="icon-2"></i>
              </button>
            </a>
          </div>
        </div>
      )}
    </>
  );
}
