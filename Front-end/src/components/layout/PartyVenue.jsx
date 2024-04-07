import { useState, useEffect } from "react";
import WeddingVenues from "../common/WeddingVenues";
import BannerHomePage from "../common/bannerHomePage";
import StartPlanningBanner from "../common/startPlanningBanner";
import axios from "axios";
import { useDispatch } from "react-redux";
import { UPDATE_VENUE_LIST } from "../../constants";

export default function PartyVenue({ isPopup }) {
  const dispatch = useDispatch();

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}/venues`)
      .then((response) => {
        if (response.data.data) {
          dispatch({ type: UPDATE_VENUE_LIST, venues: response.data.data });
        }
        return response;
      })
      .catch((error) => {
        return error;
      });
  }, []);

  return (
    <>
      {isPopup && <BannerHomePage showText={true} />}
      <WeddingVenues />
      <StartPlanningBanner />
    </>
  );
}
