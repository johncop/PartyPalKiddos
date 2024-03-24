import Layout from "./components/layout/layout";
import { AdminLayout } from "./components/layout/Admin";
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
import { Charts } from "./components/admin/charts";
import { HomePage } from "./components/admin/home";
import { Cart } from "./components/layout/Cart";
import Search from "./components/layout/Search";
import { useState } from "react";
import axios from "./middleware/axios";
import Chart from "chart.js/auto";
import { CategoryScale } from "chart.js";
Chart.register(CategoryScale);

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
    <>
      <BrowserRouter basename="/">
        <Routes>
            <Route
              path="/admin/charts"
              element={
                <AdminLayout>
                  <Charts />
                </AdminLayout>
              }
            />
            <Route
              path="/admin"
              element={
                <AdminLayout>
                  <HomePage />
                </AdminLayout>
              }
            />

            {MENU_PAGE(isPopup).map((item) => (
              <Route
                key={item.element + item.name + item.url}
                path={item.url}
                element={
                  <Layout handlePopup={handlePopup}>{item.element}</Layout>
                }
              />
            ))}
            <Route
              path="/profile/:id"
              element={
                <Layout handlePopup={handlePopup}>
                  <Profile />
                </Layout>
              }
            />
            <Route
              path="/profile/edit/:id"
              element={
                <Layout handlePopup={handlePopup}>
                  <Profile />
                </Layout>
              }
            />
            <Route
              path="/:category/:id"
              element={
                <Layout handlePopup={handlePopup}>
                  <Details />
                </Layout>
              }
            />
            <Route
              path="/login"
              element={
                <Layout handlePopup={handlePopup}>
                  <Login />
                </Layout>
              }
            />
            <Route
              path="/sign-up"
              element={
                <Layout handlePopup={handlePopup}>
                  <SignUp />
                </Layout>
              }
            />
            <Route
              path="/cart"
              element={
                <Layout handlePopup={handlePopup}>
                  <Cart />
                </Layout>
              }
            />
            <Route
              path="/"
              element={
                <Layout handlePopup={handlePopup}>
                  <Search />
                </Layout>
              }
            />
            <Route
              path="*"
              element={
                <Layout handlePopup={handlePopup}>
                  <PageNotFound />
                </Layout>
              }
            />
        </Routes>
      </BrowserRouter>
    </>
  );
};
