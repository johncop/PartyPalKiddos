import BannerAbout from "../common/bannerAbout";
import Funfacts from "../common/funfacts";
import StartPlanningBanner from "../common/startPlanningBanner";
import WhatWeOffer from "../common/whatWeOffer";
import WhoWeAre from "../common/whoWeAre";
import AboutUs from "../common/aboutus";

export default function About(){
    return <>
        <BannerAbout />
        <AboutUs/>
        <Funfacts/>
        <WhatWeOffer/>
        <WhoWeAre/>
        <StartPlanningBanner/>
    </>
}