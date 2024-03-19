import { PaginationControl } from "react-bootstrap-pagination-control";
import { useCallback, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import Card from "./card";
import { LIST_CATE } from "../../constants";

export default function WeddingVenues() {
    const state = useSelector((state) => state);
    const viewportCount = 2;
    const [repos, setRepos] = useState([]);
    const [count, setCount] = useState(0);
    const [page, setPage] = useState(1);
    const [suggestions, setSuggetions] = useState([]);
    useEffect(() => {
        setSuggetions(state.uiState.suggest);
    }, [state.uiState.suggest]);

    useEffect(() => {
        setCount(state.uiState.suggest.length)
        setRepos(state.uiState.suggest)
    }, [page])

    const onChangePage = useCallback((next) => {
        setPage(next);
    }, []);

    return <>
        <section className="section-padding pt-4">
            <div className="auto-container">
                <div className="form-search form-search-col-5 row mb-4">
                    <div className="pe-1 ps-1 mb-2">
                        <select defaultValue="0" className="form-select" aria-label="Default select example">
                            <option value="0">
                                No. of Guests
                            </option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </select>
                    </div>
                    <div className="pe-1 ps-1 mb-2">
                        <select defaultValue="0" className="form-select" aria-label="Default select example">
                            <option value="0">
                                Venue Type
                            </option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </select>
                    </div>
                    <div className="pe-1 ps-1 mb-2">
                        <select defaultValue="0" className="form-select" aria-label="Default select example">
                            <option value="0">
                                Space Preference
                            </option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </select>
                    </div>
                    <div className="pe-1 ps-1 mb-2">
                        <select defaultValue="0" className="form-select" aria-label="Default select example">
                            <option value="0">
                                Rating
                            </option>
                            <option value="1">One</option>
                            <option value="2">Two</option>
                            <option value="3">Three</option>
                        </select>
                    </div>
                    <div className="pe-1 ps-1 mb-2">
                        <button type="button" className="btn btn-info w-100">
                            Search
                        </button>
                    </div>
                </div>
                {/* Wedding venues */}
                <div className="section_heading text-center">
                    <h3 className="section_heading_title_big">Wedding Venues</h3>
                </div>
                <div className="d-flex justify-content-end pb-2 fw-bold"><a href="#">View All (10)</a> </div>
                <div className="row pagination-custom">
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>

                    <PaginationControl
                        page={page}
                        between={3}
                        limit={1}
                        // total={Math.ceil(count / viewportCount)}
                        total={Math.ceil(40 / 12)}
                        ellipsis={4}
                        changePage={onChangePage}
                    />
                </div>

                {/* Popular venues */}
                <div className="section_heading text-center mt-5">
                    <h3 className="section_heading_title_big">Popular Venues</h3>
                </div>
                <div className="d-flex justify-content-end pb-2 fw-bold"><a href="#">View All (10)</a> </div>
                <div className="row mb-5 pagination-custom">
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <div className="col-lg-3 col-md-6 mb-3 ps-2 pe-2">
                        <Card category={LIST_CATE.SERVICES} id={345}/>
                    </div>
                    <PaginationControl
                        page={page}
                        between={3}
                        limit={1}
                        // total={Math.ceil(count / viewportCount)}
                        total={Math.ceil(20 / 4)}
                        ellipsis={4}
                        changePage={onChangePage}
                    />
                </div>
            </div>
        </section>
    </>
}