import axios from "axios";
import { useDispatch } from "react-redux";
import {
  UPDATE_PACKAGE_ACTION,
  UPDATE_POPULAR_ACTION,
} from "../../constants";
import BannerHomePage from "../common/bannerHomePage";

export default function Search() {
  const dispatch = useDispatch();

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
      <BannerHomePage showText={false}/>
    </>
  );
}
