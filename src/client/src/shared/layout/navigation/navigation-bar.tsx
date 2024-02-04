import { Camera, Contact, Home, Menu } from "lucide-react";
import NavigationButton, { NavigationButtonProps } from "./navigation-button";
import { useEffect, useRef, useState } from "react";
import { Button } from "@/components/ui/button";
import UserMenu from "./user-menu/user-menu";
import { motion, useViewportScroll } from "framer-motion";

const NavigationItems: NavigationButtonProps[] = [
  { icon: <Home className="mr-1 inline-block size-5" />, text: "Poznajmy się", href: "/" },
  { icon: <Camera className="mr-1 inline-block size-5" />, text: "Galeria", href: "/galeria" },
  { icon: <Contact className="mr-1 inline-block size-5" />, text: "Kontakt", href: "/kontakt" },
];

const MobileNavigation = () => {
  return (
    <div className="sm:hidden">
      <div className="flex flex-row justify-between space-y-1 px-2 pb-3 pt-2">
        {NavigationItems.map((item, index) => (
          <NavigationButton key={index} {...item} />
        ))}
      </div>
    </div>
  );
};

const Navigation = () => {
  const [isOpen, setIsOpen] = useState(false);

  const [isScrollingUp, setIsScrollingUp] = useState(true);
  const { scrollY } = useViewportScroll();
  const lastY = useRef(0);

  useEffect(() => {
    return scrollY.onChange(v => {
      setIsScrollingUp(v <= lastY.current);
      lastY.current = v;
    });
  }, [scrollY]);

  return (
    <motion.nav
      className="sticky top-0 z-50 bg-background opacity-90 shadow dark:opacity-75"
      initial={{ y: 0 }}
      animate={{ y: isScrollingUp ? 0 : "-100%" }}
      transition={{ duration: 0.3 }}
    >
      <div className="mx-auto max-w-7xl px-2 sm:px-4 lg:px-8">
        <div className="relative flex h-16 items-center justify-between">
          <div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
            <div className="flex shrink-0 items-center text-center">
              <h1 className="text-2xl font-bold tracking-tight text-primary lg:text-3xl">
                Gabriela Mirek
              </h1>
            </div>
            <div className="hidden sm:ml-6 sm:block ">
              <div className="flex space-x-4">
                {NavigationItems.map((item, index) => (
                  <NavigationButton key={index} {...item} />
                ))}
              </div>
            </div>
            <div className="ml-auto mr-0 hidden sm:block">
              <UserMenu />
            </div>
            <div className="ml-auto mr-0 sm:hidden">
              <UserMenu />
              <Button onClick={() => setIsOpen(!isOpen)} variant="link">
                <motion.div whileHover={{ scale: 1.2 }} whileTap={{ scale: 0.8 }}>
                  <Menu className="size-6" />
                </motion.div>
              </Button>
            </div>
          </div>
        </div>
        {isOpen && <MobileNavigation />}
      </div>
    </motion.nav>
  );
};

export default Navigation;
