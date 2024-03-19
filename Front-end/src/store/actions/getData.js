/**
 * Handles all events when the action is called
 * @param {string} type type of the action
 * @param {*} payload value of the function used to execute the action 
 * @returns new state
 */
const getDataAction = (type, payload) => {
  return {
    type,
    payload,
  };
};
export default getDataAction;
