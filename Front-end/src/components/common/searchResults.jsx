import SuggestionServiceItem from "./suggestionServiceItem";
import { useCallback, useEffect, useState } from "react";
import { PaginationControl } from "react-bootstrap-pagination-control";
import { LIST_CATE } from "../../constants";
import { useLocation } from "react-router-dom";
import axios from "axios";

export default function SearchResults() {
  const [page1, setPage1] = useState(1);
  const [page2, setPage2] = useState(1);
  const [searchResults, setSearchResults] = useState({
    venues: [],
    services: [],
  });
  const query = new URLSearchParams(useLocation().search);

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}venues/search`, {
        params: {
          ServiceCategoryId: query.get("service"),
          DistrictId: query.get("location"),
        },
      })
      .then((response) => {
        setSearchResults(response.data.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  const onChangePage1 = useCallback((next) => {
    setPage1(next);
  }, []);
  const onChangePage2 = useCallback((next) => {
    setPage2(next);
  }, []);

  return (
    <>
      <section className="section-padding">
        {searchResults.venues && searchResults.venues.length > 0 && (
          <div className="auto-container">
            <div className="section_heading text-center mb-4">
              <h2 className="section_heading_title_big animation-text-head-color-hoz">
                Venues
              </h2>
            </div>
            <div className="row pagination-custom">
              {searchResults.venues.map((suggestion, index) => (
                <div className="col-lg-3 col-md-6" key={"suggestion-" + index}>
                  <SuggestionServiceItem
                    imageUrl={suggestion.image}
                    title={suggestion.name}
                    description={suggestion.description}
                    category={LIST_CATE.VENUE}
                    price={suggestion.price || 0}
                    id={345}
                  />
                </div>
              ))}
              <PaginationControl
                page={page1}
                between={3}
                limit={1}
                total={Math.ceil(searchResults.venues.length / 12)}
                ellipsis={4}
                changePage={onChangePage1}
              />
            </div>
          </div>
        )}
        {searchResults.services && searchResults.services.length > 0 && (
          <div className="auto-container">
            <div className="section_heading text-center mb-4">
              <h2 className="section_heading_title_big animation-text-head-color-hoz">
                Services
              </h2>
            </div>
            <div className="row pagination-custom">
              {searchResults.services.map((suggestion, index) => (
                <div className="col-lg-3 col-md-6" key={"suggestion-" + index}>
                  <SuggestionServiceItem
                    imageUrl={suggestion.image}
                    title={suggestion.name}
                    description={suggestion.description}
                    category={LIST_CATE.SERVICES}
                    price={suggestion.price || 0}
                    id={345}
                  />
                </div>
              ))}
              <PaginationControl
                page={page2}
                between={3}
                limit={1}
                total={Math.ceil(searchResults.services.length / 12)}
                ellipsis={4}
                changePage={onChangePage2}
              />
            </div>
          </div>
        )}
      </section>
    </>
  );
}
