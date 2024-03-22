import { PaginationControl } from "react-bootstrap-pagination-control";
import Category from "./category";
import { useSelector } from "react-redux";
import { useCallback, useEffect, useState } from "react";
import { LIST_CATE } from "../../constants";

export default function PopularVenue() {
  const state = useSelector((state) => state);
  const viewportCount = 2;
  const [repos, setRepos] = useState([]);
  const [count, setCount] = useState(0);
  const [page, setPage] = useState(1);
  const [popular, setPopular] = useState([]);
  useEffect(() => {
    setPopular(state.uiState.popular);
  }, [state.uiState.popular]);

  useEffect(() => {
    setCount(state.uiState.popular.length);
    setRepos(state.uiState.popular);
  }, [page]);

  const onChangePage = useCallback((next) => {
    setPage(next);
  }, []);
  return (
    <>
      <section className="section-padding">
        <div className="gray-bg p_absolute l_0 b_0 r_0"></div>
        <div className="auto-container pagination-custom">
          <div className="section_heading text-center">
            <span className="section_heading_title_small">
              Exclusive Offers
            </span>
            <h2 className="section_heading_title_big animation-text-head-color-hoz">Popular Venue</h2>
          </div>
          <div className="d-flex justify-content-end pb-2 fw-bold">
            <a href="#">View All (100)</a>{" "}
          </div>
          <div className="row">
            {popular.map((item, index) => (
              <div
                key={"popular-" + index}
                className="col-lg-3 col-md-6 mb-3 ps-2 pe-2"
              >
                <Category
                  name={item.Title}
                  category={LIST_CATE.VENUE}
                  image={item.ImageUrl}
                  id={item.Id}
                />
              </div>
            ))}
          </div>
          <PaginationControl
            page={page}
            between={3}
            limit={1}
            total={Math.ceil(count / viewportCount)}
            ellipsis={4}
            changePage={onChangePage}
          />
        </div>
      </section>
    </>
  );
}
