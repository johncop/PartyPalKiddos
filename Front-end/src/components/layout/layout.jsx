import { useState, useEffect } from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import SearchPopup from "../common/searchPopup";
import BackToTop from "../common/backToTop";

export default function Layout({
  children,
  wrapperCls,
  handlePopup
}) {
  const [scroll, setScroll] = useState(0);
  // Mobile Menu
  const [isMobileMenu, setMobileMenu] = useState(false);
  const handleMobileMenu = () => {
    setMobileMenu(!isMobileMenu);
    !isMobileMenu
      ? document.body.classList.add("mobile-menu-visible")
      : document.body.classList.remove("mobile-menu-visible");
  };

  // Sidebar
  const [isSidebar, setSidebar] = useState(false);
  const handleSidebar = () => setSidebar(!isSidebar);

  useEffect(() => {
    const WOW = require("wowjs");
    window.wow = new WOW.WOW({
      live: false,
    });
    window.wow.init();

    document.addEventListener("scroll", () => {
      const scrollCheck = window.scrollY > 100;
      if (scrollCheck !== scroll) {
        setScroll(scrollCheck);
      }
    });
  }, []);
  return (
    <>
      <div className={`page-wrapper ${wrapperCls ? wrapperCls : ""}`} id="#top">
        <Header
          scroll={scroll}
          isMobileMenu={isMobileMenu}
          handleMobileMenu={handleMobileMenu}
          handlePopup={handlePopup}
          isSidebar={isSidebar}
          handleSidebar={handleSidebar}
        />

        <SearchPopup isPopup={false} handlePopup={handlePopup} />

        {children}

        {window.location.pathname !== "/" && <Footer />}
      </div>
      <BackToTop scroll={scroll} />
    </>
  );
}
