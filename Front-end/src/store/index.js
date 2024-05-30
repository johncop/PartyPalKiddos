import { createStore, combineReducers } from "redux";
import getDataReducer from "./reducers/getData";

export const defaultStore = {
  uiState: {
    packages: [],
    suggest: [],
    lastestPackages: [],
    categories: [],
    locations: [],
    popular: [],
    reviewers: [],
    venues: [],
    packageCategories: [],
    services: [],
    carts: [],
    searchResults: {
      venues: [],
      services: [],
    },
    birthdayBanner: {
      name: "",
      title: "",
      image: "",
      description: "",
    },
    popup: {
      item: {},
      index: -1,
    },
  },
};

/**
 * create a store for the given data source and store
 * @param {State} state default state
 * @returns store
 */
function configureStore(state = defaultStore) {
  return createStore(
    combineReducers({
      uiState: getDataReducer,
    }),
    state
  );
}

export default configureStore;
