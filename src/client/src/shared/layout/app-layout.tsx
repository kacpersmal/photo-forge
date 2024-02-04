import Navigation from "./navigation/navigation-bar";
import { Outlet } from "react-router";

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
