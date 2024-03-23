import CounterUp from "./CounterUp";

export default function Funfacts() {
    return (
        <>

            <section className="section-padding text-center small-padding py-3" style={{ backgroundColor: "#fff" }}>
                <div className="auto-container">
                    <div className="row">
                        <div className="col-lg-3 col-md-6">
                            <div className="funfact-1-block text-center">
                                <div className="d-flex align-items-center justify-content-center">
                                    <h2 className="funfact-1-number odometer fs-1 mb-0" >
                                        <CounterUp end={150} /><span></span>
                                    </h2>
                                </div>
                                <p className="funfact-1-title mb-0">Birthday Vendors</p>
                            </div>
                        </div>
                        <div className="col-lg-3 col-md-6">
                            <div className="funfact-1-block">
                                <div className="d-flex align-items-center justify-content-center">
                                    <h2 className="funfact-1-number odometer  fs-1  mb-0">
                                        <CounterUp end={2} /><span></span>
                                    </h2>
                                </div>
                                <p className="funfact-1-title mb-0">Annual Birthdays</p>
                            </div>
                        </div>
                        <div className="col-lg-3 col-md-6">
                            <div className="funfact-1-block">
                                <div className="d-flex align-items-center justify-content-center">
                                    <h2 className="funfact-1-number odometer fs-1  mb-0">
                                        <CounterUp end={95} /><span></span>
                                    </h2>
                                </div>
                                <p className="funfact-1-title mb-0">Birthday Venues</p>
                            </div>
                        </div>
                        <div className="col-lg-3 col-md-6">
                            <div className="funfact-1-block">
                                <div className="d-flex align-items-center justify-content-center">
                                    <h2 className="funfact-1-number odometer fs-1  mb-0" data-count="30">
                                        <CounterUp end={30} /><span>M</span>
                                    </h2>
                                </div>
                                <p className="funfact-1-title mb-0">Monthly Followers</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </>
    )
}
