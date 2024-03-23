import Layout from "./components/layout/layout";
import "./styles/css/style.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";
import {
  UPDATE_SUGGEST_ACTION,
  UPDATE_PACKAGE_ACTION,
  UPDATE_CATEGORY_ACTION,
  UPDATE_LOCATION_ACTION,
  UPDATE_POPULAR_ACTION,
  UPDATE_BIRTHDAY_ACTION,
  UPDATE_REVIEWERS_ACTION,
  SUGGESTION_LIST,
  CATEGORY_LIST,
  LOCATION_LIST,
  BIRTHDAY_BANNER_VALUE,
  REVIEWER_LIST,
  MENU_PAGE,
} from "./constants";
import Details from "./components/common/Details";
import PageNotFound from "./components/layout/PageNotFound";
import Profile from "./components/common/Profile";
import Login from "./components/common/modal/Login";
import SignUp from "./components/common/modal/SignUp";
import { Cart } from "./components/layout/Cart";
import Search from "./components/layout/Search";
import { useState } from "react";

export const App = () => {
  // Popup
  const [isPopup, setPopup] = useState(false);
  const handlePopup = () => setPopup(!isPopup);

  //#region This is just a sample data set, so when calling from the api, it must be moved to the main page
  const dispatch = useDispatch();
  dispatch({ type: UPDATE_SUGGEST_ACTION, suggestions: SUGGESTION_LIST });
  dispatch({ type: UPDATE_CATEGORY_ACTION, categories: CATEGORY_LIST });
  dispatch({ type: UPDATE_LOCATION_ACTION, locations: LOCATION_LIST });
  dispatch({ type: UPDATE_POPULAR_ACTION, popular: CATEGORY_LIST });
  dispatch({
    type: UPDATE_BIRTHDAY_ACTION,
    birthdayBanner: BIRTHDAY_BANNER_VALUE,
  });
  dispatch({
    type: UPDATE_REVIEWERS_ACTION,
    reviewers: REVIEWER_LIST,
  });
  //#endregion
  return (
    <Layout handlePopup={handlePopup}>
      <BrowserRouter basename="/">
        <Routes>
          {MENU_PAGE(isPopup).map((item) => (
            <Route
              key={item.element + item.name + item.url}
              path={item.url}
              element={item.element}
            />
          ))}
          <Route
            path="/profile/:id"
            element={<Profile />}
          />
          <Route
            path="/profile/edit/:id"
            element={<Profile />}
          />
          <Route
            path="/:category/:id"
            element={<Details />}
          />
          <Route
            path="/login"
            element={<Login />}
          />
          <Route
            path="/sign-up"
            element={<SignUp />}
          />
          <Route
            path="/cart"
            element={<Cart />}
          />
          <Route
            path="/"
            element={<Search />}
          />
          <Route
            path="*"
            element={<PageNotFound />}
          />
        </Routes>
      </BrowserRouter>
    </Layout>
  );
};
