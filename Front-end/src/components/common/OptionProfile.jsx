
import axios from "axios";

export default function OptionProfile({logout}) {
    axios
    .get(`${process.env.REACT_APP_API_BASE_URL}users`)
    .then((response) => {
      console.log(response);
      return response
    })
    .catch((error) => {
      console.log(error);
      return error
    });

    return <>
        <div className="dropdown position-relative" style={{ zIndex: 9999 }}>
            <button className="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButtonProfile" data-bs-toggle="dropdown" aria-expanded="false">
                {"Nguyễn Văn A"}
            </button>
            <ul className="dropdown-menu dropdown-option-profile" aria-labelledby="dropdownMenuButtonProfile">
                <li><a className="dropdown-item" href="/profile/333">Profile</a></li>
                <li><div className="dropdown-item cursor-pointer" onClick={() => logout()}>Log out</div></li>
            </ul>
        </div>
    </>
}