export default function Card(props) {
  const { category, id, data } = props;

  return (
    <>
      <div className="card p-0 text-dark" style={{ minWidth: "18rem" }}>
        <a href={`/${category}/${id}`}>
          <div className="card-img-container">
            <img
              className="card-img-top"
              style={{ height: 200 }}
              src={data.image}
              alt={data.name}
            ></img>
          </div>
          <div className="card-body">
            <div className="card-title text-black mb-0 not-wrap-text">
              {data.district}, <b>{data.name}</b>{" "}
            </div>
            <div className="info-rating d-flex gap-2">
              <div className="rating-star">
                <i className="icon-6"></i>
                <i className="icon-6"></i>
                <i className="icon-6"></i>
                <i className="icon-6"></i>
                <i className="icon-7"></i>
              </div>
              <div className="rating-star-count">
                <span>4.5</span>
              </div>
              <div className="rating-count">(22)</div>
            </div>
            <div className="card-text">{data.price.toLocaleString()} VND</div>
          </div>
        </a>
      </div>
    </>
  );
}
