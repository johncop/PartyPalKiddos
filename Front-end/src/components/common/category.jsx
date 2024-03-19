export default function Category(props) {
  const { name, id, image, category } = props;
  return (
    <div
      className="feature-2-block"
      data-wow-delay=".2s"
      data-wow-duration=".8s"
    >
      <a href={`/${category}/` + id}>
        <div className="feature-2-image hvr-img-zoom-1">
          <img
            src={image}
            style={{ height: "200px" }}
          />
        </div>
        <div className="feature-2-lower-content px-3">
          <h5 className="feature-2-title">{name}</h5>
        </div>
      </a>
    </div>
  );
}
