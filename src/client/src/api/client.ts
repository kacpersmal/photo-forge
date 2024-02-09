import axios from "axios";

const AxiosInstance = axios.create({
  baseURL: "http://localhost:5075",
});

export default AxiosInstance;
