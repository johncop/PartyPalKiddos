import SuggestionServiceItem from "./suggestionServiceItem";
import { useSelector } from "react-redux";
import { useCallback, useEffect, useState } from "react";
import { PaginationControl } from "react-bootstrap-pagination-control";
import { LIST_CATE } from "../../constants";

export default function SuggestionService() {
  const state = useSelector((state) => state);
  const [page, setPage] = useState(1);
  const [suggestions, setSuggetions] = useState([]);

  useEffect(() => {
    setSuggetions(state.uiState.suggest);
  }, [state.uiState.suggest]);

  const onChangePage = useCallback((next) => {
    setPage(next);
  }, []);

  return (
    <>
      <section className="section-padding">
        <div className="auto-container">
          <div className="section_heading text-center mb-4">
            <h2 className="section_heading_title_big animation-text-head-color-hoz">Suggestion Services</h2>
          </div>
          <div className="row pagination-custom">
            {suggestions.map((suggestion, index) => (
              <div className="col-lg-3 col-md-6" key={"suggestion-" + index}>
                <SuggestionServiceItem
                  imageUrl={suggestion.image}
                  title={suggestion.name}
                  description={suggestion.description}
                  category={LIST_CATE.SERVICES}
                  price={suggestion.price}
                  id={345}
                />
              </div>
            ))}
            <PaginationControl
              page={page}
              between={3}
              limit={1}
              total={Math.ceil(suggestions.length / 12)}
              ellipsis={4}
              changePage={onChangePage}
            />
          </div>
        </div>
      </section>
    </>
  );
}
