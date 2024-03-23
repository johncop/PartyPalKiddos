import { PaginationControl } from "react-bootstrap-pagination-control";
import { useCallback, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import CardRounded from "./CardRounded";
import Card from "./card";
import { LIST_CATE } from "../../constants";

export default function PartyCategories() {
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
        <section className="section-padding dark-bg">
            <div className="p_absolute l_0 b_0 r_0 t_0" style={{ background: 'url(/assets/images/shape/pattern-3.png) no-repeat center bottom' }}></div>
            <div className="auto-container">
                <div className="team-1-wrapper">
                    <div className="section_heading text-center mb_50">
                        <span className="section_heading_title_small">Discover</span>
                        <h2 className="section_heading_title_big mb_20 alt">Party Categories</h2>
                        <p className="color_gray_light">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Adipiscing integer ultrices suspendisse varius etiam est. <br /> Est, felis, tempus nec vitae orci sodales Metus, velit nec at diam in sed. Massa dui ipsum ornare sagittis dolor <br /> sagittis amet odio est. Sit semper et velit fusce.</p>
                    </div>
                    <div className="row">
                        <a href="#" className="col_xl_five col-lg-3 col-md-6">
                            <div className="icon_box-1 alt">
                                <div className="icon_box-1-icon"><i className="icon-8"></i></div>
                                <p className="fw_500">Fast wifi</p>
                            </div>
                        </a>
                        <a href="#" className="col_xl_five col-lg-3 col-md-6">
                            <div className="icon_box-1 alt">
                                <div className="icon_box-1-icon"><i className="icon-9"></i></div>
                                <p className="fw_500">Coffee</p>
                            </div>
                        </a>
                        <a href="#" className="col_xl_five col-lg-3 col-md-6">
                            <div className="icon_box-1 alt">
                                <div className="icon_box-1-icon"><i className="icon-10"></i></div>
                                <p className="fw_500">Bath</p>
                            </div>
                        </a>
                        <a href="#" className="col_xl_five col-lg-3 col-md-6">
                            <div className="icon_box-1 alt">
                                <div className="icon_box-1-icon"><i className="icon-11"></i></div>
                                <p className="fw_500">Parking Space​</p>
                            </div>
                        </a>
                        <a href="#" className="col_xl_five col-lg-3 col-md-6">
                            <div className="icon_box-1 alt">
                                <div className="icon_box-1-icon"><i className="icon-12"></i></div>
                                <p className="fw_500">Swimming pool</p>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </section>
    </>
}