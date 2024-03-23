import { useParams } from "react-router-dom"

export default function OptionProfile() {
    const params = useParams();
    const { id } = params;
    const $ = document.querySelector.bind(document);
    function handleLogout() {

    }
    return <>
        <div className="dropdown position-relative" style={{ zIndex: 9999 }}>
            <button className="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButtonProfile" data-bs-toggle="dropdown" aria-expanded="false">
                {"Nguyễn Văn A"}
            </button>
            <ul className="dropdown-menu dropdown-option-profile" aria-labelledby="dropdownMenuButtonProfile">
                <li><a className="dropdown-item" href="/profile/333">Profile</a></li>
                <li><div className="dropdown-item cursor-pointer" onClick={() => handleLogout()}>Log out</div></li>
            </ul>
        </div>
    </>
}