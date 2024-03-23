export default function BannerAbout({ }) {
    return (
        <>
            <div className="container-fluid banner-container banner-filter-container d-flex justify-content-center align-items-center p-5">
                <div className="position-absolute start-0 bottom-0 top-0 end-0">
                    <img src="https://reviverestore.org/wp-content/uploads/2018/11/ocean-banner.jpg"  height={400} alt="" className="w-100 h-100 d-block" />
                </div>
                <div className="banner-content d-flex flex-column gap-3 justify-content-center align-items-center position-absolute z-index-99">
                    <div className="content-outer">
                        <div className="content-box justify-content-center text-center">
                            <div className="inner">
                                <h4 className=" text-white">Birthday Party</h4>
                                <h1 className=" text-white">We are PartyPal<br /> Kiddos.</h1>
                                <br/>
                                <h4 className="fw-normal text-white">We bring</h4>
                                <h4 className="text-white">dream birthday</h4>
                                <h4 className="fw-normal text-white">to life!</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
