import { createBrowserRouter } from "react-router-dom";
import HomePage from "./pages/home-page";
import ErrorPage from "./pages/error-page";
import AppLayout from "./shared/layout/app-layout";

const AppRouter = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
    ],
  },
]);

export default AppRouter;
