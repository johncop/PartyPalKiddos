export default function CardRounded(props) {
    const { category, id } = props;
    return <>
        <div className="card-rounded-container text-dark text-center bg-body p-4 b_radius_10 shadow-sm">
            <a href={`/${category}/${id}`}>
                <div className="card-rouded-img-container">
                    <img className="card-rouded-img rounded-circle" src="https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg" alt="" />
                </div>
                <div className="card-rounded-cate text-uppercase text-center mt-2 mb-4">Category</div>
            </a>
        </div>
    </>
}