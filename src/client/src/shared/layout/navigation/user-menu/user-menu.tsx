import { CircleUserRound } from "lucide-react";

import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import UnauthenticatedUserMenuContent from "./unathenticated-user-menu-content";
import { ModeToggle } from "@/components/mode-toggle";

const UserMenu = () => {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" size="icon">
          <CircleUserRound className="size-6 text-primary" />
        </Button>
      </DropdownMenuTrigger>

      <DropdownMenuContent className="w-56">
        <UnauthenticatedUserMenuContent />
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <ModeToggle />
        </DropdownMenuGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default UserMenu;
