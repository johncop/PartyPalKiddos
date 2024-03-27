import { useEffect, useState } from "react";
import Login from "../common/modal/Login";
import Menu from "../layout/Menu";
import MobileMenu from "../layout/MobileMenu";
import SignUp from "../common/modal/SignUp";
import OptionProfile from "../common/OptionProfile";

export default function Header({
  scroll,
  isMobileMenu,
  handleMobileMenu,
  isSidebar,
  handlePopup,
  handleSidebar,
}) {
  const [isLogin, setIsLogin] = useState(false);
  const [isSignUp, setIsSignUp] = useState(false);
  const [isLoginDone, setLoginIsDone] = useState("");
  useEffect(() => {
    setLoginIsDone(localStorage.getItem("token"));
  }, []);

  function logout() {
    localStorage.removeItem("token");
    setLoginIsDone("");
  }

  return (
    <>
      <div className="header-top-1">
        <div className="auto-container">
          <div className="header-top-1-row d-flex align-items-center justify-content-between">
            <div className="header-top-1-left-column">
              <ul className="header-top-1-contact-info d-flex align-items-center">
                <li>
                  <a href="mailto:info@example.com">info@example.com</a>
                </li>
                <li>
                  <a href="tel:+91-213-666-0027">+12-345-678-9999</a>
                </li>
              </ul>
            </div>
            <div className="header-top-1-right-column d-flex align-items-center gap-3 header-top-1-user">
              {isLoginDone ? (
                <OptionProfile logout={logout} />
              ) : (
                <>
                  {" "}
                  <a
                    className="bg-transparent text-white btn-login"
                    href="/login"
                  >
                    LOGIN
                  </a>
                  <a
                    className="bg-danger px-2 b_radius_2 text-white btn-sign-up"
                    href="/sign-up"
                  >
                    SIGN UP
                  </a>
                </>
              )}
            </div>
          </div>
        </div>
      </div>
      <header
        className={`main-header header-style-one ${
          scroll ? "fixed-header" : ""
        }`}
      >
        <div className="header-upper">
          <div className="auto-container">
            <div className="inner-container d-flex align-items-center justify-content-between">
              <div className="logo-box">
                <div className="logo">
                  <a
                    href="/"
                    className="fs-2 fw-bold d-flex align-items-center animation-text-head-color-hoz"
                  >
                    <img
                      src="/assets/images/logo.png"
                      alt=""
                      width={100}
                      height={60}
                    />
                    PartyPal Kiddos
                  </a>
                </div>
              </div>
              <div className="nav-outer">
                <nav className="main-menu navbar-expand-md navbar-light">
                  <div
                    className="collapse navbar-collapse show clearfix"
                    id="navbarSupportedContent"
                  >
                    <Menu />
                  </div>
                </nav>
                {window.location.pathname !== "/" && (
                  <>
                    <a href="/cart" className="ms-3">
                      <i className="fas fa-cart-plus"></i>
                    </a>
                    <div
                      className="mobile-nav-toggler"
                      onClick={handleMobileMenu}
                    >
                      <img src="/assets/images/icons/icon-bar-2.png" alt="" />
                    </div>
                    <div className="right-column d-flex align-items-center">
                      <button
                        type="button"
                        className="theme-btn search-toggler ps-3"
                      >
                        <span
                          onClick={handlePopup}
                          className="search-box-outer search-toggler"
                        >
                          <i className="icon-1"></i>
                        </span>
                      </button>
                    </div>{" "}
                  </>
                )}
              </div>
            </div>
          </div>
        </div>
        {/* Header Upper */}

        {/* End Header Upper*/}
        {/* Sticky Header  */}
        <div className="sticky-header">
          <div className="header-upper">
            <div className="auto-container">
              <div className="inner-container d-flex align-items-center justify-content-between">
                {/* Logo */}
                <div className="logo-box">
                  <div className="logo" style={{ width: "350px" }}>
                    <a
                      href="/"
                      className="fs-2 fw-bold d-flex align-items-center"
                    >
                      <img src="/assets/images/logo.png" alt="" width={100} />
                      PartyPal Kiddos
                    </a>
                  </div>
                </div>
                <div className="middle-column">
                  {/* Nav Box */}
                  <div className="nav-outer">
                    {/* Mobile Navigation Toggler */}
                    <nav className="main-menu navbar-expand-md navbar-light">
                      <div
                        className="collapse navbar-collapse show clearfix"
                        id="navbarSupportedContent"
                      >
                        <Menu />
                      </div>
                    </nav>
                    {isLoginDone && (
                      <a href="/cart" className="ms-3">
                        <i className="fas fa-cart-plus"></i>
                      </a>
                    )}
                    <div
                      className="mobile-nav-toggler"
                      onClick={handleMobileMenu}
                    >
                      <img src="/assets/images/icons/icon-bar-2.png" alt="" />
                    </div>
                    <div className="right-column d-flex align-items-center">
                      <button
                        type="button"
                        className="theme-btn search-toggler ps-3"
                      >
                        <span
                          onClick={handlePopup}
                          className="search-box-outer search-toggler"
                        >
                          <i className="icon-1"></i>
                        </span>
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        {/* End Sticky Menu */}
        {/* Mobile Menu  */}

        <MobileMenu
          handleMobileMenu={handleMobileMenu}
          setIsLogin={setIsLogin}
          setIsSignUp={setIsSignUp}
          isLoginDone={isLoginDone}
        />
      </header>

      {/* Login */}
      {isLogin && <Login setIsLogin={setIsLogin} />}
      {/* Sign up */}
      {isSignUp && <SignUp setIsSignUp={setIsSignUp} />}
    </>
  );
}
