import { useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { LIST_CATE } from "../../constants";

export default function BirthdayDateBanner() {
  const state = useSelector((state) => state);
  const [birthdayBanner, setBirthdayBanner] = useState([]);

  useEffect(() => {
    setBirthdayBanner(state.uiState.birthdayBanner);
  }, [state.uiState.birthdayBanner]);

  const id= 345;

  return (
    <>
      <section className="section-padding gray-bg">
        <div className="auto-container">
          <div className="row align-items-center">
            <div className="col-lg-6">
              <div className="about-1-image-wrap mb_30 p_relative">
                <div
                  className="about-1-shape-1"
                  data-parallax='{"y": -50}'
                ></div>
                <div className="about-1-image-1 hvr-img-zoom-1">
                  <img
                    src={birthdayBanner.image}
                    style={{ maxHeight: "400px" }}
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div className="col-lg-6 ps-lg-5">
              <div className="section_heading mb_20">
                <span className="section_heading_title_small">
                  {birthdayBanner.name}
                </span>
                <h2 className="section_heading_title_big">
                  {birthdayBanner.title}
                </h2>
              </div>
              <p className="aboout-1-desc mb_30">
                {birthdayBanner.description}
              </p>
              <div className="about-1-btn mb_30">
                <a href={`/${LIST_CATE.SERVICES}/booking/${id}`} className="btn-1 px-5">
                  Book<span></span>
                </a>
              </div>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
