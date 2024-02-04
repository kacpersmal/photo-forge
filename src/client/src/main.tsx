import React from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider } from "react-router-dom";

import AppRouter from "./app-router.tsx";
import { ThemeProvider } from "./components/theme-provider.tsx";
import "./index.css";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <ThemeProvider defaultTheme="dark" storageKey="photo-ui-theme">
      <RouterProvider router={AppRouter} />
    </ThemeProvider>
  </React.StrictMode>,
);
