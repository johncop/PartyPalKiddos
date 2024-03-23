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
  UPDATE_PACKAGE_ACTION,
  UPDATE_POPULAR_ACTION,
} from "../../constants";

export default function Home({isPopup}) {
  const dispatch = useDispatch();

  axios
    .get("https://658bc0b1859b3491d3f4adb4.mockapi.io/Data")
    .then(function (response) {
      dispatch({ type: UPDATE_SUGGEST_ACTION, suggestions: response.data });
    });
  axios
    .get("https://658bc0b1859b3491d3f4adb4.mockapi.io/Data")
    .then(function (response) {
      dispatch({ type: UPDATE_PACKAGE_ACTION, packages: response.data });
    });
  axios
    .get("https://658bc0b1859b3491d3f4adb4.mockapi.io/Data")
    .then(function (response) {
      dispatch({ type: UPDATE_POPULAR_ACTION, popular: response.data });
    });

  return (
    <>
      {isPopup && <BannerHomePage showText={true}/>}
      <ListCategory />
      <PopularVenue />
      <BirthdayDateBanner />
      <FeaturedPackages />
      <Reviews />
      <SuggestionService />
    </>
  );
}
