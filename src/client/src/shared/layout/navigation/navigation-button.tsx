import { Button } from "@/components/ui/button";
import { motion } from "framer-motion";
import { NavLink } from "react-router-dom";

type NavigationButtonProps = {
  href: string;
  icon: React.ReactNode;
  text: string;
};

const NavigationButton = ({ href, icon, text }: NavigationButtonProps) => {
  return (
    <motion.div whileTap={{ scale: 0.8 }}>
      <NavLink className="flex flex-row items-center justify-between" to={href}>
        {({ isActive }) => (
          <Button className={isActive ? "text-primary" : ""} variant="ghost">
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
