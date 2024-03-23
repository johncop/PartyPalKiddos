import { useSelector } from "react-redux";
import { useEffect, useState } from "react";
import TestimonialSlider4 from "../common/slider/TestimonialSlider4"

export default function Reviews() {
  const state = useSelector((state) => state);
  const [reviewers, setReviewers] = useState([]);
  useEffect(() => {
    setReviewers(state.uiState.reviewers);
  }, [state.uiState.reviewers]);
  return (
    <section className="section-padding dark-bg">
      <div className="p_absolute l_0 b_0 r_0 t_0" style={{ background: 'url(/assets/images/shape/pattern-3.png) no-repeat center bottom' }}></div>
      <div className="auto-container">
        <div className="section_heading text-center mb-4">
          <h2 className="section_heading_title_big text-white">Reviews</h2>
        </div>
        <div className="project-1-wrapper">
          <div className="content-box">
            <TestimonialSlider4 reviewers={reviewers} />
          </div>
        </div>
      </div>
    </section>
  );
}
