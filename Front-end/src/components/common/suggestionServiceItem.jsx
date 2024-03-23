export default function SuggestionServiceItem(props) {
  const { imageUrl, category, id, title, description } = props;
  return (
    <>
      <div
        className="room-1-block wow fadeInUp mb-4"
        data-wow-delay=".2s"
        data-wow-duration=".8s"
      >
        <div className="room-1-image hvr-img-zoom-1">
          <img src={imageUrl} style={{ height: "200px" }} alt="" />
        </div>
        <div className="room-1-content px-3 pb-3">
          <h5 className="room-1-title pt-2">
            <a href={`/${category}/${id}`}>{title}</a>
          </h5>
          <p className="room-1-text">{description}</p>
          <div className="link-btn">
            <a href={`/${category}/${id}`} className="btn-1 btn-alt px-4 py-2">
              Read more<span></span>
            </a>
          </div>
        </div>
      </div>
    </>
  );
}
