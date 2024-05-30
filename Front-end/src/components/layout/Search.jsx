import axios from "axios";
import { useDispatch } from "react-redux";
import {
  UPDATE_CATEGORY_ACTION,
  UPDATE_LOCATION_ACTION,
} from "../../constants";
import BannerHomePage from "../common/bannerHomePage";
import { useEffect } from "react";

export default function Search() {
  const dispatch = useDispatch();
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}service-categories`)
      .then((response) => {
        dispatch({
          type: UPDATE_CATEGORY_ACTION,
          categories: response.data.data,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}districts`)
      .then((response) => {
        dispatch({
          type: UPDATE_LOCATION_ACTION,
          locations: response.data.data,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  return (
    <>
      <div className="video-background">
        <video autoPlay loop muted>
          <source src="/assets/background-video.mp4" type="video/mp4" />
          Your browser does not support the video tag.
        </video>
        <div className="content">
          <BannerHomePage showText={false} />
        </div>
      </div>
    </>
  );
}
