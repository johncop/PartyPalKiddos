export function CountProduct(props) {
    const { closeModal, titleModal } = props
    return <>
        <div className="modal-container-full-screen">
            <div className="count-product-container" id="countProductModal">
                <div className="login-overlay" onClick={() => closeModal(false)}></div>
                <div className="login-content">
                    <div className="modal-header">
                        <h4 className="modal-title">{titleModal}</h4>
                        <button type="button" className="close close-btn-modal" data-dismiss="modal" onClick={() => closeModal(false)}>&times;</button>
                    </div>
                    <div className="modal-body">
                        <form>
                            <div className="pb-3 modal-count-product-content">
                                <div className="img-product-container px-0">
                                    <img src="https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg" alt="img-product" />
                                    <div className="product-price">130.900đ</div>
                                </div>
                                <div className="px-0 ps-sm-3">
                                    <h5 className="mb-2">Lorem, ipsum.</h5>
                                    <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Eius, sapiente.</p>
                                    <div><b>Price:</b> <span>128.000đ</span></div>
                                    <div>
                                        <div className="fw-bold">Quantity:</div>
                                        <input type="number" className="form-control w-100 mb-4" min={0} defaultValue={1} />
                                    </div>
                                </div>
                            </div>
                            <div className="d-flex gap-1 count-product-btn-group">
                                <button className="btn btn-outline-primary w-100" onClick={() => closeModal(false)}>Cancel</button>
                                <button className="btn btn-primary w-100">Save</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </>
}