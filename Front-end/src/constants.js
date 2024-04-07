import About from "./components/layout/About";
import ContactUs from "./components/layout/ContactUs";
import Home from "./components/layout/Home";
import PartyPackages from "./components/layout/PartyPackages";
import PartyServices from "./components/layout/PartyServices";
import PartyVenue from "./components/layout/PartyVenue";

export const UPDATE_PACKAGE_ACTION = "update-package-action";
export const UPDATE_SUGGEST_ACTION = "update-suggest-action";
export const UPDATE_CATEGORY_ACTION = "update-category-action";
export const UPDATE_LOCATION_ACTION = "update-location-action";
export const UPDATE_BIRTHDAY_ACTION = "update-birthday-action";
export const UPDATE_REVIEWERS_ACTION = "update-reviewer-action";
export const UPDATE_POPULAR_ACTION = "update-popular-action";
export const UPDATE_LASTEST_PACKAGES_ACTION = "update-lastest-packages-action";
export const UPDATE_VENUE_LIST = "update-venue-action";

//#region Sample Data
export const CATEGORY_LIST = [
  { value: 1, name: "DESTINATION BIRTHDAY" },
  { value: 2, name: "TRAVEL BIRTHDAY" },
  { value: 3, name: "VIDEOGRAPHERS BIRTHDAY" },
  { value: 4, name: "CELEBRANT" },
];
export const LOCATION_LIST = [
  { value: 1, name: "TP HCM" },
  { value: 2, name: "HA NOI" },
  { value: 3, name: "DA NANG" },
];
export const BIRTHDAY_BANNER_VALUE = {
  name: "Lorem, ipsum.",
  title: "LOREM IPSUM DOLOR SIT.",
  image:
    "https://images-cdn.ubuy.co.id/634d262dda72487d39725676-happy-birthday-decorations-backdrop.jpg",
  description:
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Adipiscing integer ultrices suspendisse varius etiam est. Est, felis, tempus nec vitae orci sodales Metus, velit nec at diam in sed. Massa dui ipsum ornare sagittis dolor sagittis amet odio est. Sit semper et velit fusce.",
};

export const REVIEWER_LIST = [
  {
    image: "https://swiperjs.com/demos/images/nature-1.jpg",
    name: "Nguyen Van A",
    description:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis hic saepe adipisci commodi vel provident tempora? Fugiat minima laboriosam neque!",
  },
  {
    image: "https://swiperjs.com/demos/images/nature-1.jpg",
    name: "Nguyen Van B",
    description:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis hic saepe adipisci commodi vel provident tempora? Fugiat minima laboriosam neque!",
  },
  {
    image: "https://swiperjs.com/demos/images/nature-1.jpg",
    name: "Nguyen Van C",
    description:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis hic saepe adipisci commodi vel provident tempora? Fugiat minima laboriosam neque!",
  },
  {
    image: "https://swiperjs.com/demos/images/nature-1.jpg",
    name: "Nguyen Van D",
    description:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis hic saepe adipisci commodi vel provident tempora? Fugiat minima laboriosam neque!",
  },
  {
    image: "https://swiperjs.com/demos/images/nature-1.jpg",
    name: "Nguyen Van E",
    description:
      "Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis hic saepe adipisci commodi vel provident tempora? Fugiat minima laboriosam neque!",
  },
];
//#endregion

export const MENU_PAGE = (isPopup) => [
  {
    name: "Home",
    url: "/home",
    element: <Home isPopup={isPopup}/>,
  },
  {
    name: "Party services",
    url: "/party-services",
    element: <PartyServices isPopup={isPopup}/>,
  },
  {
    name: "Party Packages",
    url: "/party-packages",
    element: <PartyPackages isPopup={isPopup}/>,
  },
  {
    name: "Venue",
    url: "/venue",
    element: <PartyVenue isPopup={isPopup}/>,
  },
  {
    name: "About",
    url: "/about",
    element: <About />,
  },
  {
    name: "Contact",
    url: "/contact",
    element: <ContactUs />,
  },
];
export const LIST_CATE = {
  CATEGORY: "category",
  SERVICES: "services",
  PARTY_SERVICES: "party-services",
  PARTY_PACKAGES: "party-packages",
  VENUE: "venue",
}
export const LIST_SHOW_BOOK = [LIST_CATE.CATEGORY, LIST_CATE.SERVICES, LIST_CATE.PARTY_PACKAGES, LIST_CATE.VENUE]
export const IMG_DEFAULT = "https://images.squarespace-cdn.com/content/v1/54b7b93ce4b0a3e130d5d232/1519986430884-H1GYNRLHN0VFRF6W5TAN/icon.png?format=500w"