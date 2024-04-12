import Select from "react-select";

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
  defaultImage
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
  } else if (multiple) {
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
      ></input>
      {type === "file" && (
        <img
          src={
            image
              ? URL.createObjectURL(image)
              : defaultImage || "https://th.bing.com/th/id/OIP.N-IegjWZz_67sr8v2233mwHaFO?w=283&h=200&c=7&r=0&o=5&dpr=1.3&pid=1.7"
          }
          className="img-fluid"
          alt=""
        ></img>
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
