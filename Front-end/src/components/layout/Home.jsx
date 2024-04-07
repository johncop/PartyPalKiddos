import BannerHomePage from "../common/bannerHomePage";
import BirthdayDateBanner from "../common/birthdayBanner";
import FeaturedPackages from "../common/featuredPackages";
import ListCategory from "../common/listCategory";
import PopularVenue from "../common/popularVenue";
import Reviews from "../common/reviews";
import SuggestionService from "../common/suggestionService";
import axios from "axios";
import { useDispatch } from "react-redux";
import {
  UPDATE_SUGGEST_ACTION,
} from "../../constants";
import { useEffect } from "react";

export default function Home({ isPopup }) {
  const dispatch = useDispatch();

  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}service-packages`)
      .then(function (response) {
        dispatch({ type: UPDATE_SUGGEST_ACTION, suggestions: response.data.data });
      });

  }, []);

  return (
    <>
      {isPopup && <BannerHomePage showText={true} />}
      <ListCategory />
      <PopularVenue />
      <BirthdayDateBanner />
      <FeaturedPackages />
      <Reviews />
      <SuggestionService />
    </>
  );
}
