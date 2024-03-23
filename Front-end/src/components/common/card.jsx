export default function Card(props) {
    const { category, id } = props;
    return <>
        <div className="card p-0 text-dark" style={{ minWidth: "18rem" }}>
            <a href={`/${category}/${id}`}>
                <div className="card-img-container">
                    <img className="card-img-top" style={{ height: 200 }} src="https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg" alt="Card image cap"></img>
                </div>
                <div className="card-body">
                    <div className="card-title text-black mb-0">Z13 RESORT, <b>ABU DHABI</b> </div>
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
                    <div className="card-text">Upto 500 Guests</div>
                </div>
            </a>
        </div>
    </>
}