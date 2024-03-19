import {
  UPDATE_PACKAGE_ACTION,
  UPDATE_SUGGEST_ACTION,
  UPDATE_CATEGORY_ACTION,
  UPDATE_LOCATION_ACTION,
  UPDATE_POPULAR_ACTION,
  UPDATE_BIRTHDAY_ACTION,
  UPDATE_REVIEWERS_ACTION,
  UPDATE_LASTEST_PACKAGES_ACTION,
} from "../../constants";
import {
  getPackagesFormApi,
  setCategories,
  setLocations,
  setSuggestValue,
  setPopular,
  setBirthdayBanner,
  setReviewers,
  setLastestPackages,
} from "../handlers";
import { defaultStore } from "..";

/**
 * All getData's actions are brought here for branching processing
 * @param {State} state saved state
 * @param {*} action action to be executed
 * @returns new state
 */
const getDataReducer = (state = defaultStore, action) => {
  switch (action.type) {
    case UPDATE_PACKAGE_ACTION:
      return getPackagesFormApi(state, action.packages);
    case UPDATE_SUGGEST_ACTION:
      return setSuggestValue(state, action.suggestions);
    case UPDATE_CATEGORY_ACTION:
      return setCategories(state, action.categories);
    case UPDATE_LOCATION_ACTION:
      return setLocations(state, action.locations);
    case UPDATE_BIRTHDAY_ACTION:
      return setBirthdayBanner(state, action.birthdayBanner);
    case UPDATE_REVIEWERS_ACTION:
      return setReviewers(state, action.reviewers);
    case UPDATE_POPULAR_ACTION:
      return setPopular(state, action.popular);
    case UPDATE_LASTEST_PACKAGES_ACTION:
      return setLastestPackages(state, action.lastestPackages);
    default:
      return state;
  }
};

export default getDataReducer;
