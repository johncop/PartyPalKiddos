import SuggestionServiceItem from "./suggestionServiceItem";
import { useSelector } from "react-redux";
import { useCallback, useEffect, useState } from "react";
import { PaginationControl } from "react-bootstrap-pagination-control";
import { LIST_CATE } from "../../constants";

export default function LastestPakages() {
  const state = useSelector((state) => state);
  const viewportCount = 2;
  const [repos, setRepos] = useState([]);
  const [count, setCount] = useState(0);
  const [page, setPage] = useState(1);
  const [lastestPackages, setLastestPackages] = useState([]);
  useEffect(() => {
    setLastestPackages(state.uiState.lastestPackages);
  }, [state.uiState.lastestPackages]);

  useEffect(() => {
    setCount(state.uiState.lastestPackages.length);
    setRepos(state.uiState.lastestPackages);
  }, [page]);

  const onChangePage = useCallback((next) => {
    setPage(next);
  }, []);

  return (
    <>
      <section className="section-padding">
        <div className="auto-container">
          <div className="section_heading text-center mb-5">
            <h3 className="section_heading_title_big">Lastest Packages</h3>
          </div>
          <div className="row">
            {lastestPackages.map((item, index) => (
              <div className="col-lg-3 col-md-6" key={"suggestion-" + index}>
                <SuggestionServiceItem
                  imageUrl={item.image}
                  title={item.serviceName}
                  description={""}
                  category={LIST_CATE.PARTY_SERVICES}
                  id={item.id}
                />
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
