export default function SearchPopup({ isPopup, handlePopup }) {
  return (
    <>
      <div
        id="search-popup"
        className={`search-popup ${isPopup ? "popup-visible" : ""}`}
      >
        <div className="popup-inner">
          <div className="upper-box clearfix">
            <div className="close-search pull-right" onClick={handlePopup}>
              <span className="far fa-times"></span>
            </div>
          </div>
          <div className="overlay-layer"></div>
          <div className="auto-container">
            <div className="search-form">
              <form method="post" action="/index">
                <div className="form-group">
                  <fieldset>
                    <input
                      type="search"
                      className="form-control"
                      name="search-input"
                      placeholder="Search Here"
                      required
                    />
                    <input
                      type="submit"
                      value="Search Now!"
                      className="theme-btn"
                    />
                  </fieldset>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
