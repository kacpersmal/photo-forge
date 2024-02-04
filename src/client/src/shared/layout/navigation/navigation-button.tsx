import { Button } from "@/components/ui/button";
import { motion } from "framer-motion";
import { Link, NavLink } from "react-router-dom";

type NavigationButtonProps = {
  icon: React.ReactNode;
  text: string;
  href: string;
};

const NavigationButton = ({ icon, text, href }: NavigationButtonProps) => {
  return (
    <motion.div whileTap={{ scale: 0.8 }}>
      <NavLink to={href} className="flex flex-row items-center justify-between">
        {({ isActive }) => (
          <Button variant="ghost" className={isActive ? "text-primary" : ""}>
            {icon}
            {text}
          </Button>
        )}
      </NavLink>
    </motion.div>
  );
};

export default NavigationButton;
export type { NavigationButtonProps };
