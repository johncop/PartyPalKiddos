import PartyCategories from "../common/PartyCategories"
import PopularPhotographerVideographer from "../common/PopularPhotographerVideographer"
import TrendingDesigner from "../common/TrendingDesigner"
import TrendingChoreographers from "../common/TrendingChoreographers"
import BannerHomePage from "../common/bannerHomePage"
import StartPlanningBanner from "../common/startPlanningBanner"

export default function PartyServices({isPopup}) {
    return (
        <>
            {isPopup && <BannerHomePage showText={true}/>}
            <PartyCategories/>
            <PopularPhotographerVideographer/>
            <TrendingDesigner/>
            <TrendingChoreographers/>
            <StartPlanningBanner/>
        </>
    )
}