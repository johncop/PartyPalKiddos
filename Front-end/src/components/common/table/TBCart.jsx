import { useEffect, useState } from "react"

export function TBCart() {
    const [isCheckAll, setIsCheckAll] = useState(true)
    useEffect(() => {
    }, [isCheckAll])

    const listSer = [
        {
            imgSrc: "https://onelife.vn/_next/image?url=https%3A%2F%2Fstorage.googleapis.com%2Fsc_pcm_product%2Fprod%2F2023%2F4%2F28%2F4183-366315.jpg&w=3840&q=75",
            name: "Lorem ipsum dolor",
            price: "100.000đ",
            isCheck: true
        },
        {
            imgSrc: "https://m.media-amazon.com/images/I/51CqegeVmlL._AC_UF1000,1000_QL80_.jpg",
            name: "Lorem ipsum dolor",
            price: "100.000đ",
            isCheck: true
        },
        {
            imgSrc: "https://onelife.vn/_next/image?url=https%3A%2F%2Fstorage.googleapis.com%2Fsc_pcm_product%2Fprod%2F2023%2F4%2F28%2F4183-366315.jpg&w=3840&q=75",
            name: "Lorem ipsum dolor",
            price: "100.000đ",
            isCheck: true
        },
        {
            imgSrc: "https://m.media-amazon.com/images/I/51CqegeVmlL._AC_UF1000,1000_QL80_.jpg",
            name: "Lorem ipsum dolor",
            price: "100.000đ",
            isCheck: true
        }, {
            imgSrc: "https://onelife.vn/_next/image?url=https%3A%2F%2Fstorage.googleapis.com%2Fsc_pcm_product%2Fprod%2F2023%2F4%2F28%2F4183-366315.jpg&w=3840&q=75",
            name: "Lorem ipsum dolor",
            price: "100.000đ",
            isCheck: true
        }
    ]

    return <>
        <div class="table-responsive">
            <table className="table table-sm table-summary-product table-bordered mb-0">
                <thead>
                    <tr>
                        <th scope="col" className="text-center">#</th>
                        <th scope="col" className="text-center" style={{ width: "60px" }}>
                            <input type="checkbox" checked={isCheckAll} onChange={() => setIsCheckAll(!isCheckAll)} />
                        </th>
                        <th scope="col">Name</th>
                        <th scope="col">Total</th>
                        <th scope="col" style={{ width: "50px" }} className="text-center">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        listSer.map((item, index) => (
                            <tr className="align-middle">
                                <th scope="row" className="text-center">1</th>
                                <td className="text-danger fw-bold text-center"><input type="checkbox" checked={item.isCheck} /></td>
                                <td>
                                    <div className="name-product d-flex align-items-center gap-3">
                                        <div style={{ width: "100px", height: "100px" }}>
                                            <img className="d-block" src={item.imgSrc} alt="" />
                                        </div>
                                        <span className="fw-bold">{item.name}</span>
                                    </div>
                                </td>
                                <td className="text-danger fw-bold">{item.price}</td>
                                <td className="text-center"><i className="fa fa-trash" onClick={() => { }}></i></td>
                            </tr>
                        )

                        )
                    }
                    <tr>
                        <th scope="row" colSpan={3}>Total</th>
                        <td colSpan={2} className="text-danger fw-bold">100.000đ</td>
                    </tr>
                </tbody>
            </table>
        </div>

    </>
}