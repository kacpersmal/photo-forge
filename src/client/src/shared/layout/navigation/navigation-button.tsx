import { Button } from "@/components/ui/button";
import { motion } from "framer-motion";
import { Link } from "react-router-dom";

type NavigationButtonProps = {
  icon: React.ReactNode;
  text: string;
  href: string;
};

const NavigationButton = ({ icon, text, href }: NavigationButtonProps) => {
  return (
    <motion.div whileTap={{ scale: 0.8 }}>
      <Button asChild variant="ghost">
        <Link to={href} className="flex flex-row items-center justify-between">
          {icon}
          {text}
        </Link>
      </Button>
    </motion.div>
  );
};

export default NavigationButton;
export type { NavigationButtonProps };
