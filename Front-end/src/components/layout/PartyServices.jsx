import PartyCategories from "../common/PartyCategories";
import BannerHomePage from "../common/bannerHomePage";
import StartPlanningBanner from "../common/startPlanningBanner";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import axios from "axios";
import {
  UPDATE_PACKAGE_CATEGORY_ACTION,
  UPDATE_SERVICES_ACTION,
} from "../../constants";

export default function PartyServices({ isPopup }) {
  const dispatch = useDispatch();
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}service-categories`)
      .then((response) => {
        dispatch({
          type: UPDATE_PACKAGE_CATEGORY_ACTION,
          categories: response.data.data,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}services`)
      .then((response) => {
        dispatch({
          type: UPDATE_SERVICES_ACTION,
          services: response.data.data,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);
  return (
    <>
      {isPopup && <BannerHomePage showText={true} />}
      <PartyCategories />
      <StartPlanningBanner />
    </>
  );
}
