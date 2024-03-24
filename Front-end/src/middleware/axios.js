import axios from "axios";

// Add a request interceptor
axios.interceptors.request.use(
  function (config) {
    config.headers["Authorization"] = `bearer ${localStorage.getItem("token")}`;
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

// Add a response interceptor
axios.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    if (error.code === "ERR_NETWORK") {
      window.location.href = "/page-not-found";
    }

    return Promise.reject(error);
  }
);

export default axios;
