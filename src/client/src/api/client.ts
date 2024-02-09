import useAuthStore from "@/state/auth-store";
import axios from "axios";

function getCurrentAccessToken() {
    return useAuthStore.getState().authSession?.token.value
}

const AxiosInstance = axios.create({
  baseURL: "http://localhost:5075",
});

 AxiosInstance.interceptors.request.use(
    (config) => {
        const token = getCurrentAccessToken();
        if (token) {
          config.headers.Authorization = "Bearer " + token;
        }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
export default AxiosInstance;
