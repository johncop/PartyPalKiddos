import Select from "react-select";
import { Swiper, SwiperSlide } from "swiper/react";
import { EffectCreative, Navigation, Pagination } from "swiper/modules";
// Import Swiper styles
import "swiper/css";
import "swiper/css/effect-creative";
import "swiper/css/pagination";
import "swiper/css/navigation";
export const InputCommon = ({
  type,
  index,
  title,
  changeImage,
  placeholder,
  required,
  disabled,
  image,
  items,
  id,
  multiple,
  handleChange,
  defaultValue,
  defaultImage,
}) => {
  if (type === "checkbox") {
    return (
      <div className="form-check form-switch">
        <input
          className="form-check-input"
          type="checkbox"
          disabled={disabled}
          id={"flexSwitchCheckChecked" + id + index}
        />
        <label
          className="form-check-label"
          htmlFor={"flexSwitchCheckChecked" + id + index}
        >
          {title}
        </label>
      </div>
    );
  } else if (multiple && type !== "file") {
    const options = items.map((item, index) => {
      return {
        value: item.id,
        label: item.value,
      };
    });
    return (
      <div>
        <label className="form-check-label">{title}</label>
        <Select
          defaultValue={defaultValue}
          onChange={handleChange}
          options={options}
          isMulti={multiple}
          isDisabled={disabled}
        />
      </div>
    );
  }

  const images = [];
  if (image) {
    for (let i = 0; i < image.length; i++) {
      images.push(URL.createObjectURL(image[i]));
    }
  }

  return (
    <div>
      <label
        htmlFor={"exampleDataList" + id + index}
        className="form-label mb-0"
      >
        {title}
      </label>
      <input
        type={type}
        className="form-control"
        list={"datalistOptions" + id + index}
        id={"exampleDataList" + id + index}
        placeholder={placeholder}
        required={required}
        style={{ width: "100%" }}
        onChange={type === "file" ? changeImage : null}
        defaultValue={defaultValue}
        disabled={disabled}
        multiple={multiple}
      ></input>
      {type === "file" && (
        <Swiper
          effect={"creative"}
          pagination={{
            type: "progressbar",
          }}
          loop={true}
          creativeEffect={{
            prev: {
              shadow: true,
              origin: "left center",
              translate: ["-5%", 0, -200],
              rotate: [0, 100, 0],
            },
            next: {
              origin: "right center",
              translate: ["5%", 0, -200],
              rotate: [0, -100, 0],
            },
          }}
          navigation={true}
          modules={[EffectCreative, Pagination, Navigation]}
          className="mySwiper"
        >
          {!image &&
            multiple &&
            defaultImage?.map((img, index) => (
              <SwiperSlide key={"img-pd" + index}>
                <img src={img.imageUrl} style={{ maxHeight: "400px" }} alt="" />
              </SwiperSlide>
            ))}
          {images?.map((img, index) => (
            <SwiperSlide key={"img-pd" + index}>
              <img src={img} style={{ maxHeight: "400px" }} alt="" />
            </SwiperSlide>
          ))}
          {!multiple && !image && (
            <SwiperSlide key={"img-pd" + 1}>
              {" "}
              <img src={defaultImage} style={{ maxHeight: "400px" }} alt="" />
            </SwiperSlide>
          )}
          {!multiple &&
            images?.map((img, index) => (
              <SwiperSlide key={"img-pd" + 2}>
                {" "}
                <img
                  key={"img-pd" + index}
                  src={img}
                  style={{ maxHeight: "400px" }}
                  alt=""
                />
              </SwiperSlide>
            ))}
        </Swiper>
      )}

      <datalist id={"datalistOptions" + id + index}>
        {items.map((item, i) => (
          <option key={"field-add-item" + id + i} value={item.id}>
            {item.value}
          </option>
        ))}
      </datalist>
    </div>
  );
};
