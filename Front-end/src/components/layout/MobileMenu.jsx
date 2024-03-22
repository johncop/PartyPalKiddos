import { useState } from "react";
import { MENU_PAGE } from "../../constants";
import OptionProfile from "../common/OptionProfile";

const MobileMenu = ({ isSidebar, handleMobileMenu, handleSidebar, setIsLogin, setIsSignUp, isLoginDone }) => {
  const [isActive, setIsActive] = useState({
    status: false,
    key: "",
    subMenuKey: "",
  });

  const handleToggle = (key, subMenuKey = "") => {
    if (isActive.key === key && isActive.subMenuKey === subMenuKey) {
      setIsActive({
        status: false,
        key: "",
        subMenuKey: "",
      });
    } else {
      setIsActive({
        status: true,
        key,
        subMenuKey,
      });
    }
  };

  return (
    <>
      <div className="mobile-menu">
        <div className="menu-backdrop" onClick={handleMobileMenu} />
        <div className="close-btn" onClick={handleMobileMenu}>
          <span className="fal fa-times" />
        </div>
        <nav className="menu-box">
          <div className="nav-logo mb-2 mt-2">
            <a href="/">
              <img src="/assets/images/logo.png" alt="" />
            </a>
          </div>
          <div className="menu-outer">
            <div
              className="collapse navbar-collapse show clearfix"
              id="navbarSupportedContent"
            >
              <div className="d-flex justify-content-center gap-5 mb-2">
                  {
                    isLoginDone && <a href="/cart" className="ms-3">
                      <i className="fas fa-cart-plus text-white"></i>
                    </a>
                  }
                  <a href="/"
                    className="search-box-outer search-toggler"
                  >
                    <i className="icon-1 text-white"></i>
                  </a>
                </div>
              <ul className="navigation clearfix">
                {MENU_PAGE(false).map(item =>
                  <li key={"mobile" + item.url} className={isActive.key === 1 ? "dropdown current" : "dropdown"}>
                    <a href={item.url} onClick={handleMobileMenu}>{item.name}</a>
                  </li>
                )}
              </ul>
            </div>
          </div>
          {/*Social Links*/}
          <div className="social-links">
            <ul className="clearfix">
              <li><a href="/#"><span className="fab fa-twitter" /></a></li>
              <li><a href="/#"><span className="fab fa-facebook-square" /></a></li>
              <li><a href="/#"><span className="fab fa-pinterest-p" /></a></li>
              <li><a href="/#"><span className="fab fa-instagram" /></a></li>
              <li><a href="/#"><span className="fab fa-youtube" /></a></li>
            </ul>
          </div>
          <div className="header-top-1-right-column d-flex align-items-center gap-3 justify-content-center">
            {
              isLoginDone ? <OptionProfile /> : <> <a className="bg-transparent text-white btn-login" href="/login">
                LOGIN
              </a>
                <a className="bg-danger px-2 b_radius_2 text-white btn-sign-up" href="/sign-up">
                  SIGN UP
                </a>
              </>
            }
          </div>
        </nav>
      </div>{/* End Mobile Menu */}
      <div className="nav-overlay" style={{ display: `${isSidebar ? "block" : "none"}` }} onClick={handleSidebar} />
    </>
  );
};

export default MobileMenu;
