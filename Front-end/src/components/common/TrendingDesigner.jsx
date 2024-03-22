import { PaginationControl } from "react-bootstrap-pagination-control";
import { useCallback, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import Card from "./card";
import { LIST_CATE } from "../../constants";

export default function TrendingDesigner() {
    const state = useSelector((state) => state);
    const viewportCount = 2;
    const [repos, setRepos] = useState([]);
    const [count, setCount] = useState(20);
    const [page, setPage] = useState(1);
    useEffect(() => {
    }, [state.uiState.suggest]);

    useEffect(() => {
    }, [page])

    const onChangePage = useCallback((next) => {
        setPage(next);
    }, []);
    return <>
        <section className="section-padding">
            <div className="gray-bg p_absolute l_0 b_0 r_0 h-100"></div>
            <div className="auto-container">
                <div className="section_heading text-center">
                    <h3 className="section_heading_title_big">Trending Designers</h3>
                </div>
                <div className="d-flex justify-content-end pb-2 fw-bold position-relative z-1"><a href="#">View All (10)</a> </div>
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
}