import { useSelector } from "react-redux";
import Category from "./category";
import { useCallback, useEffect, useState } from "react";
import { PaginationControl } from "react-bootstrap-pagination-control";
import { LIST_CATE } from "../../constants";

export default function ListCategory() {
  const state = useSelector((state) => state);
  const viewportCount = 2;
  // repos: List data
  const [repos, setRepos] = useState([]);
  const [count, setCount] = useState(0);
  const [page, setPage] = useState(1);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    setRepos(state.uiState.suggest);
  }, [state.uiState.suggest]);

  useEffect(() => {
    setCount(state.uiState.suggest.length);
  }, [page]);

  useEffect(() => {
    setCategories(state.uiState.categories);
  }, [state.uiState.categories]);

  const onChangePage = useCallback((next) => {
    setPage(next);
  }, []);
  return (
    <>
      <section className="section-padding">
        <div className="gray-bg p_absolute l_0 b_0 r_0 h-100"></div>
        <div className="auto-container">
          <div className="section_heading text-center">
            <span className="section_heading_title_small">
              Exclusive Offers
            </span>
            <h2 className="section_heading_title_big animation-text-head-color-hoz">Browse By Category</h2>
          </div>
          <div className="d-flex justify-content-end pb-2 fw-bold">
            <a href="#" className="zIndex-1">View All (10)</a>{" "}
          </div>
          <div className="row pagination-custom" >
            {categories.map((category) => (
              <div
                key={"category-" + category.value}
                className="col-lg-3 col-md-6 mb-3 ps-2 pe-2"
              >
                <Category name={category.name} category={LIST_CATE.CATEGORY} id={345}/>
              </div>
            ))}
            <PaginationControl
              page={page}
              between={3}
              limit={1}
              total={Math.ceil(count / viewportCount)}
              ellipsis={4}
              changePage={onChangePage}
            />
          </div>
        </div>
      </section>
    </>
  );
}
