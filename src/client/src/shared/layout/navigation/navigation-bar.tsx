import { Camera, Home, Mail, Menu } from "lucide-react";
import NavigationButton, { NavigationButtonProps } from "./navigation-button";
import { useState } from "react";
import { Button } from "@/components/ui/button";

const NavigationItems: NavigationButtonProps[] = [
  { icon: <Home className="h-5 w-5 mr-1 inline-block" />, text: "Poznajmy się", href: "#" },
  { icon: <Camera className="h-5 w-5 mr-1 inline-block" />, text: "Galeria", href: "#" },
  { icon: <Mail className="h-5 w-5 mr-1 inline-block" />, text: "Kontakt", href: "#" }
]

const Navigation = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-white shadow">
      <div className="max-w-7xl mx-auto px-2 sm:px-4 lg:px-8">
        <div className="relative flex items-center justify-between h-16">
          <div className="flex-1 flex items-center justify-center sm:items-stretch sm:justify-start">
            <div className="flex-shrink-0 flex items-center text-center">
              <h1 className="font-bold tracking-tight text-2xl lg:text-3xl">
                Gabriela Mirek
              </h1>
            </div>
            <div className="hidden sm:block sm:ml-6">
              <div className="flex space-x-4">
                {NavigationItems.map((item, index) => (<NavigationButton key={index} {...item} />))}
              </div>
            </div>
            <div className="sm:hidden ml-auto mr-0">
              <Button onClick={() => setIsOpen(!isOpen)} variant="ghost">
                <Menu className="h-6 w-6" />
              </Button>
            </div>
          </div>
        </div>
        {isOpen && (
          <div className="sm:hidden">
            <div className="px-2 pt-2 pb-3 space-y-1">
              {NavigationItems.map((item, index) => (<NavigationButton key={index} {...item} />))}
            </div>
          </div>
        )}
      </div>
    </nav>
  );
}

export default Navigation;