import BannerHomePage from "../common/bannerHomePage";
import StartPlanningBanner from "../common/startPlanningBanner";
import LastestPakages from "../common/LastestPakages";
import { useDispatch } from "react-redux";
import axios from "axios";
import { UPDATE_LASTEST_PACKAGES_ACTION } from "../../constants";
import { useEffect } from "react";

export default function PartyPackages({ isPopup }) {
  const dispatch = useDispatch();
  useEffect(() => {
    axios
      .get(`${process.env.REACT_APP_API_BASE_URL}service-packages`)
      .then((response) => {
        dispatch({
          type: UPDATE_LASTEST_PACKAGES_ACTION,
          lastestPackages: response.data.data,
        });
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  return (
    <>
      {isPopup && <BannerHomePage showText={true} />}
      <LastestPakages />
      <StartPlanningBanner />
    </>
  );
}
