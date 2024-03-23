export default function FeaturedPackageItem(props) {
    return (
        <div className="room-1-block wow fadeInUp" data-wow-delay=".2s" data-wow-duration=".8s">
            <div className="room-1-image hvr-img-zoom-1">
                <img src={props.data.ImageUrl} style={{height:"200px"}} alt="" />
            </div>
                <p className="room-1-meta-info mx-3">Packages <span className="theme-color">{props.data.Title}</span></p>
        </div>
    )
}