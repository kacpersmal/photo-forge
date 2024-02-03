import { Button } from "@/components/ui/button";
import { Link } from "react-router-dom";

type NavigationButtonProps = {
  icon: React.ReactNode;
  text: string;
  href: string;
};

const NavigationButton = ({ icon, text, href }: NavigationButtonProps) => {
  return (
    <Button asChild variant="ghost">
      <Link to={href} className="flex flex-row items-center justify-between">
        {icon}
        {text}
      </Link>
    </Button>
  );
};

export default NavigationButton;
export type { NavigationButtonProps };
