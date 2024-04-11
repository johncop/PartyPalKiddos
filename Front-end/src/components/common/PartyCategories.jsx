import { useEffect, useState, createRef } from "react";
import { useSelector } from "react-redux";
import { CategoryItems } from "./CategoryItem";

export default function PartyCategories() {
  const state = useSelector((state) => state);

  const [packageCategories, setPackageCategories] = useState([]);
  useEffect(() => {
    setPackageCategories(state.uiState.packageCategories);
  }, [state.uiState.packageCategories]);
  const refs = packageCategories.reduce((acc, value) => {
    acc[value.id] = createRef();
    return acc;
  }, {});

  const handleClick = (id) =>
    refs[id].current.scrollIntoView({
      behavior: "smooth",
      block: "start",
    });
  return (
    <>
      <section className="section-padding dark-bg">
        <div
          className="p_absolute l_0 b_0 r_0 t_0"
          style={{
            background:
              "url(/assets/images/shape/pattern-3.png) no-repeat center bottom",
          }}
        ></div>
        <div className="auto-container">
          <div className="team-1-wrapper">
            <div className="section_heading text-center mb_50">
              <span className="section_heading_title_small">Discover</span>
              <h2 className="section_heading_title_big mb_20 alt">
                Party Categories
              </h2>
            </div>
            <div className="row">
              {packageCategories.map((item) => (
                <a
                  onClick={() => handleClick(item.id)}
                  key={"package-category" + item.id}
                  href={"#" + item.name}
                  className="col-lg-3 col-md-6"
                >
                  <div className="icon_box-1 alt">
                    <div className="icon_box-1-icon">
                      <i className="icon-24"></i>
                    </div>
                    <p className="fw_500">{item.name}</p>
                  </div>
                </a>
              ))}
            </div>
          </div>
        </div>
      </section>
      {packageCategories.map((item) => (
        <div key={"package-category-item" + item.id} ref={refs[item.id]}>
          <CategoryItems id={item.id} title={item.name} />
        </div>
      ))}
    </>
  );
}
