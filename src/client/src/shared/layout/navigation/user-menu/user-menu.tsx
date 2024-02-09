import { ModeToggle } from "@/components/mode-toggle";
import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import useAuthStore from "@/state/auth-store";
import { CircleUserRound } from "lucide-react";

import AdminUserMenu from "./admin-user-menu";
import AuthenticatedUserMenuContent from "./authenticated-user-menu-content";
import UnauthenticatedUserMenuContent from "./unathenticated-user-menu-content";

const UserMenu = () => {
  const user = useAuthStore(state => state.user);

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button size="icon" variant="ghost">
          <CircleUserRound className="size-6 text-primary" />
        </Button>
      </DropdownMenuTrigger>

      <DropdownMenuContent className="w-56 bg-background">
        {user?.role === "Admin" && <AdminUserMenu />}
        {user ? <AuthenticatedUserMenuContent /> : <UnauthenticatedUserMenuContent />}
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <ModeToggle />
        </DropdownMenuGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default UserMenu;
