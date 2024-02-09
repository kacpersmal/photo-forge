import {
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";
import { LayoutDashboard } from "lucide-react";

const AdminUserMenu = () => {
  return (
    <>
      <DropdownMenuGroup>
        <DropdownMenuLabel>Panel Admina</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <LayoutDashboard className="mr-2 size-4" />
            <span>Dashboard</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
      </DropdownMenuGroup>
    </>
  );
};

export default AdminUserMenu;
