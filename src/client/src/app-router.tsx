import { createBrowserRouter } from "react-router-dom";

import ContactPage from "./pages/contact/contact-page";
import ErrorPage from "./pages/error-page";
import GalleryPage from "./pages/galleries/gallery-page";
import HomePage from "./pages/home/home-page";
import AppLayout from "./shared/layout/app-layout";

const AppRouter = createBrowserRouter([
  {
    children: [
      {
        element: <HomePage />,
        path: "/",
      },
      {
        element: <GalleryPage />,
        path: "/galeria",
      },
      {
        element: <ContactPage />,
        path: "/kontakt",
      },
    ],
    element: <AppLayout />,
    errorElement: <ErrorPage />,
    path: "/",
  },
]);

export default AppRouter;
