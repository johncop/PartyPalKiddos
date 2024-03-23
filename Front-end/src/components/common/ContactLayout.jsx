import FormContact from "./FormContact";

export default function ContactLayout() {
    return <>
        <section className="section-padding">
            <div className="auto-container">
                <h3 className="mb-4 fs-1 animation-text-head-color-hoz">Say Hello!</h3>
                <div className="row text-dark">
                    <div className="col-lg-6 col-md-12 mb-5">
                        <FormContact />
                    </div>
                    <div className="col-lg-6 col-md-12">
                        <div className="d-flex flex-column mb-2">
                            <h5>Vendor</h5>
                            <p>If you are a registered vendor or a business looking to promote your brand on our portal, please send in your queries at vendors@comany.com
                            </p>
                        </div>
                        <div className="d-flex flex-column mb-2">
                            <h5>Marketing Collaborations</h5>
                            <p>For brand collaborations - sponsored content, social media activations etc., please write into partnerships@comany.com

                            </p>
                        </div>
                        <div className="d-flex flex-column mb-2">
                            <h5>Wedding Submissions
                            </h5>
                            <p>Company Name features wedding across cultures, styles and budgets. To submit your wedding, kindly email us 15-20 photos at submissions@comany.com

                            </p>
                        </div>
                        <div className="d-flex flex-column mb-2">
                            <h5>Careers
                            </h5>
                            <p>We are a team of passionate young minds looking to reinvent the wedding space. Please check our careers page for current openings and email us at hr@comany.com

                            </p>
                        </div>
                        <div className="d-flex flex-column mb-2">
                            <h5>Customers
                            </h5>
                            <p>We love to hear from our precious users. For any feedback or queries simply write in to info@comany.com
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </>
}