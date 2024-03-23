'use client'
import { Autoplay, Navigation, Pagination } from "swiper/modules"
import { Swiper, SwiperSlide } from "swiper/react"

const swiperOptions = {
  modules: [Autoplay, Pagination, Navigation],
  slidesPerView: 2,
  spaceBetween: 30,
  autoplay: {
    delay: 2500,
    disableOnInteraction: false,
  },
  loop: true,

  // Navigation
  navigation: {
    nextEl: '.h1n',
    prevEl: '.h1p',
  },

  // Pagination
  pagination: {
    el: '.swiper-pagination',
    clickable: true,
  },

  breakpoints: {
    320: {
      slidesPerView: 1,
      spaceBetween: 30,
    },
    750: {
      slidesPerView: 1,
      spaceBetween: 30,
    },
    767: {
      slidesPerView: 2,
      spaceBetween: 30,
    },
    991: {
      slidesPerView: 2,
      spaceBetween: 30,
    },
    1199: {
      slidesPerView: 2,
      spaceBetween: 30,
    },
    1350: {
      slidesPerView: 2,
      spaceBetween: 30,
    },
  }
}
export default function TestimonialSlider4(props) {
  const { reviewers } = props;
  return (
    <>
      <Swiper {...swiperOptions} className="theme_carousel owl-theme">
        {
          reviewers.map((item, index) =>
            <SwiperSlide className="slide-item" key={item.name + index}>
              <div className="swiper-slide">
                <div className="testimonial-1-block">
                  <div className="testimonial-1-quote-icon"><i className="icon-18"></i></div>
                  <p className="testimonial-1-review-desc">{item.description}</p>
                  <h4 className="testimonial-1-name">{item.name}</h4>
                  <p className="testimonial-1-designation">Manager</p>
                  <div className="testimonial-1-author-thumb">
                    <img width={120} height={120} src={item.image} alt="" />
                  </div>
                </div>
              </div>
            </SwiperSlide>)
        }
      </Swiper>

    </>
  )
}
