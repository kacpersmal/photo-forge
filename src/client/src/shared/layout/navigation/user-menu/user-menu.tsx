import { CircleUserRound } from "lucide-react";

import { Button } from "@/components/ui/button";
import { DropdownMenu, DropdownMenuTrigger } from "@/components/ui/dropdown-menu";
import UnauthenticatedUserMenuContent from "./unathenticated-user-menu-content";

const UserMenu = () => {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" size="icon">
          <CircleUserRound className="h-6 w-6" />
        </Button>
      </DropdownMenuTrigger>
      <UnauthenticatedUserMenuContent />
    </DropdownMenu>
  );
};

export default UserMenu;
