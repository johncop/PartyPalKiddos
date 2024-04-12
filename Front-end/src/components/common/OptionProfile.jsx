import axios from "axios";
import { useEffect, useState } from "react";

export default function OptionProfile({ logout }) {
  const [userInfo, setUserInfo] = useState({});

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}users/current`)
      .then((response) => {
        if (response.data.data.roles.includes("User")) {
          setUserInfo(response.data.data);
        } else {
          if (
            !window.location.pathname.includes("forbbiden") &&
            !window.location.pathname.includes("login") &&
            !window.location.pathname.includes("sign-up")
          ) {
            window.location.href = "/forbbiden";
          }
        }
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, []);

  return (
    <>
      <div className="dropdown position-relative" style={{ zIndex: 9999 }}>
        <button
          className="btn btn-primary dropdown-toggle"
          type="button"
          id="dropdownMenuButtonProfile"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          {userInfo?.user?.displayName}
        </button>
        <ul
          className="dropdown-menu dropdown-option-profile"
          aria-labelledby="dropdownMenuButtonProfile"
        >
          <li>
            <a className="dropdown-item" href="/profile">
              Profile
            </a>
          </li>
          <li>
            <div
              className="dropdown-item cursor-pointer"
              onClick={() => logout()}
            >
              Log out
            </div>
          </li>
        </ul>
      </div>
    </>
  );
}
