/**
 * get package list from the api
 * @param {*} state current state
 * @returns new package list
 */
export function getPackagesFormApi(state, packages) {
  return {
    ...state,
    packages: packages,
  };
}

/**
 * set new suggestions into the state
 * @param {*} state current state
 * @returns new suggestions
 */
export function setSuggestValue(state, value) {
  return {
    ...state,
    suggest: value,
  };
}

/**
 * set new categories into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setCategories(state, value) {
  return {
    ...state,
    categories: value,
  };
}

/**
 * set new categories into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setLocations(state, value) {
  return {
    ...state,
    locations: value,
  };
}

/**
 * set new popular list into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setPopular(state, value) {
  return {
    ...state,
    popular: value,
  };
}

/**
 * set a new birthday banner list into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setBirthdayBanner(state, value) {
  return {
    ...state,
    birthdayBanner: value,
  };
}

/**
 * set a new reviewers list into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setReviewers(state, value) {
  return {
    ...state,
    reviewers: value,
  };
}

/**
 * set a new reviewers list into the state
 * @param {*} state current state
 * @returns new categories
 */
export function setLastestPackages(state, value) {
  return {
    ...state,
    lastestPackages: value,
  };
}

/**
 * set a new venues list into the state
 * @param {*} state current state
 * @returns new venues
 */
export function setVenues(state, value) {
  return {
    ...state,
    venues: value,
  };
}

/**
 * set a new venues list into the state
 * @param {*} state current state
 * @returns new venues
 */
export function setPackageCategories(state, value) {
  return {
    ...state,
    packageCategories: value,
  };
}

/**
 * set a new venues list into the state
 * @param {*} state current state
 * @returns new venues
 */
export function setServices(state, value) {
  return {
    ...state,
    services: value,
  };
}

/**
 * set a new venues list into the state
 * @param {*} state current state
 * @returns new venues
 */
export function setCarts(state, value) {
  return {
    ...state,
    carts: value,
  };
}
