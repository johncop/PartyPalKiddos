import { MENU_PAGE } from "../../constants";

export default function Menu() {
    // const router = useRouter()
    return (
        <>
            <ul className="navigation clearfix">
                {
                    MENU_PAGE(false).map((item, index) =>
                        <li key={item.url + item.name + index}><a href={item.url}>{item.name}</a></li>
                    )
                }
            </ul>
        </>
    )
}
