import SuggestionServiceItem from "./suggestionServiceItem";
import { useSelector } from "react-redux";
import { useCallback, useEffect, useState } from "react";
import { PaginationControl } from "react-bootstrap-pagination-control";
import { LIST_CATE } from "../../constants";

export default function LastestPakages() {
  const state = useSelector((state) => state);
  const [page, setPage] = useState(1);
  const [lastestPackages, setLastestPackages] = useState([]);
  useEffect(() => {
    setLastestPackages(state.uiState.lastestPackages);
  }, [state.uiState.lastestPackages]);

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
            {lastestPackages.map((item, index) => {
              if ((page - 1) * 12 <= index && index < page * 12) {
                return (
                  <div
                    className="col-lg-3 col-md-6"
                    key={"suggestion-" + index}
                  >
                    <SuggestionServiceItem
                      imageUrl={item.images[0]?.imageUrl}
                      title={item.name}
                      description={item.description}
                      category={LIST_CATE.PARTY_PACKAGES}
                      price={item.price}
                      id={item.id}
                    />
                  </div>
                );
              }
            })}
            <PaginationControl
              page={page}
              between={3}
              limit={1}
              total={Math.ceil(lastestPackages.length / 12)}
              ellipsis={4}
              changePage={onChangePage}
            />
          </div>
        </div>
      </section>
    </>
  );
}
