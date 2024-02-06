import { ModeToggle } from "@/components/mode-toggle";
import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { CircleUserRound } from "lucide-react";

import UnauthenticatedUserMenuContent from "./unathenticated-user-menu-content";

const UserMenu = () => {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button size="icon" variant="ghost">
          <CircleUserRound className="size-6 text-primary" />
        </Button>
      </DropdownMenuTrigger>

      <DropdownMenuContent className="w-56 bg-background">
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
