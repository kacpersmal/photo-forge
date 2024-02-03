import { createBrowserRouter } from "react-router-dom";
import HomePage from "./pages/home/home-page";
import ErrorPage from "./pages/error-page";
import AppLayout from "./shared/layout/app-layout";
import ContactPage from "./pages/contact/contact-page";
import GalleryPage from "./pages/galleries/gallery-page";

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
      {
        path: "/galeria",
        element: <GalleryPage />,
      },
      {
        path: "/kontakt",
        element: <ContactPage />,
      },
    ],
  },
]);

export default AppRouter;
