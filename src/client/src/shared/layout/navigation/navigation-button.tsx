import { Button } from "@/components/ui/button";

type NavigationButtonProps = {
  icon: React.ReactNode;
  text: string;
  href: string;
};

const NavigationButton = ({ icon, text, href }: NavigationButtonProps) => {
  return (
    <Button asChild variant="ghost">
      <a href={href}>
        {icon}
        {text}
      </a>
    </Button>
  );
};

export default NavigationButton;
export type { NavigationButtonProps };
