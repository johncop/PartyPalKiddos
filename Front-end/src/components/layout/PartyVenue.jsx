import WeddingVenues from "../common/WeddingVenues"
import BannerHomePage from "../common/bannerHomePage"
import StartPlanningBanner from "../common/startPlanningBanner"

export default function PartyVenue({isPopup}) {
    return (
        <>
            {isPopup && <BannerHomePage  showText={true}/>}
            <WeddingVenues />
            <StartPlanningBanner />
        </>
    )
}