export function Product(props) {
    const { setIsShowCount } = props
    function handleClick() {

    }
    return <>
        <div className="product-container">
            <div className="img-product-container">
                <img src="https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg" alt="img-product" />
                <div className="product-price">130.900đ</div>
            </div>
            <div className="product-content p-2">
                <div className="product-title text-center pb-2">Lorem, ipsum.{Math.random()}</div>
                <div className="product-add-cart" onClick={() => setIsShowCount(true)}>
                    Add
                </div>
            </div>
        </div>
    </>
}