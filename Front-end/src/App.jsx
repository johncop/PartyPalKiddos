import { CategoryScale } from "chart.js";
import Chart from "chart.js/auto";
import { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import {
  BrowserRouter,
  Navigate,
  Outlet,
  Route,
  Routes,
} from "react-router-dom";
import { Charts } from "./components/admin/charts";
import { DistrictPage } from "./components/admin/districts";
import { HomePage } from "./components/admin/home";
import { FoodCategoryPage } from "./components/admin/foodCategory";
import { ComboPage } from "./components/admin/combo";
import { FoodPage } from "./components/admin/food";
import { ServiceCategoryPage } from "./components/admin/serviceCategory";
import { ServicePackagePage } from "./components/admin/servicePackage";
import { ServicesPage } from "./components/admin/services";
import { VenuePage } from "./components/admin/venues";
import Details from "./components/common/Details";
import Profile from "./components/common/Profile";
import { ForgotPassword } from "./components/common/modal/ForgotPassword";
import Login from "./components/common/modal/Login";
import SignUp from "./components/common/modal/SignUp";
import { AdminLayout } from "./components/layout/Admin";
import { Cart } from "./components/layout/Cart";
import PageNotFound from "./components/layout/PageNotFound";
import Search from "./components/layout/Search";
import Layout from "./components/layout/layout";
import {
  BIRTHDAY_BANNER_VALUE,
  CATEGORY_LIST,
  LOCATION_LIST,
  MENU_PAGE,
  REVIEWER_LIST,
  UPDATE_BIRTHDAY_ACTION,
  UPDATE_CATEGORY_ACTION,
  UPDATE_LOCATION_ACTION,
  UPDATE_POPULAR_ACTION,
  UPDATE_REVIEWERS_ACTION,
} from "./constants";
import axios from "./middleware/axios";
import "./styles/css/style.css";

Chart.register(CategoryScale);

export const App = () => {
  // Popup
  const [isPopup, setPopup] = useState(false);
  const handlePopup = () => setPopup(!isPopup);

  //#region This is just a sample data set, so when calling from the api, it must be moved to the main page
  const dispatch = useDispatch();
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

  const ProtectedRoute = ({ redirectPath = "/landing", children }) => {
    const [restult, setResult] = useState(null);

    useEffect(() => {
      axios
        .get(`${process.env.REACT_APP_API_BASE_URL}users/current`)
        .then((response) => {
          if (response.data.data.roles.includes("Admin")) {
            setResult(children ? children : <Outlet />);
          } else {
            setResult(<Navigate to={redirectPath} replace />);
          }
        })
        .catch((error) => {
          setResult(<Navigate to={redirectPath} replace />);
        });
    }, []);

    return restult;
  };

  return (
    <>
      <BrowserRouter basename="/">
        <Routes>
          <Route element={<ProtectedRoute redirectPath="/forbbiden" />}>
            <Route
              path="/admin/charts"
              element={
                <AdminLayout>
                  <Charts />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/venue"
              element={
                <AdminLayout>
                  <VenuePage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/district"
              element={
                <AdminLayout>
                  <DistrictPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/combo"
              element={
                <AdminLayout>
                  <ComboPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/food"
              element={
                <AdminLayout>
                  <FoodPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/food-category"
              element={
                <AdminLayout>
                  <FoodCategoryPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/service-category"
              element={
                <AdminLayout>
                  <ServiceCategoryPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/service"
              element={
                <AdminLayout>
                  <ServicesPage />
                </AdminLayout>
              }
            />
            <Route
              path="/admin/service-package"
              element={
                <AdminLayout>
                  <ServicePackagePage />
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
          </Route>

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
            path="/profile"
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
            path="/forbbiden"
            element={
              <Layout handlePopup={handlePopup}>
                <PageNotFound path={"assets/images/403-forbbiden.png"} />
              </Layout>
            }
          />
          <Route
            path="/forgot-password"
            element={
              <Layout handlePopup={handlePopup}>
                <ForgotPassword />
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
                <PageNotFound path={"assets/images/404-page-not-found.png"} />
              </Layout>
            }
          />
        </Routes>
      </BrowserRouter>
    </>
  );
};
