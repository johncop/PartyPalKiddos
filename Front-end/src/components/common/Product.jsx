export function Product(props) {
  const { handleClick, price, name, image, type,  item } = props;
  return (
    <>
      <div className="product-container">
        <div className="img-product-container">
          <img src={image} alt="img-product" />
          <div className="product-price">{price.toLocaleString()}đ</div>
        </div>
        <div className="product-content p-2">
          <div className="product-title text-center pb-2 not-wrap-text">{name}</div>
          <div
            className="product-add-cart"
            onClick={() => handleClick(type, item)}
          >
            Add
          </div>
        </div>
      </div>
    </>
  );
}
