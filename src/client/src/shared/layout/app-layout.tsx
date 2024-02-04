import { Outlet } from "react-router";

import Navigation from "./navigation/navigation-bar";

const AppLayout = () => {
  return (
    <>
      <Navigation />
      <main className="">
        <Outlet />
      </main>
    </>
  );
};

export default AppLayout;
