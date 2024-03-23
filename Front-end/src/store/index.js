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
    birthdayBanner: {
      name: "",
      title: "",
      image: "",
      description: ""
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
