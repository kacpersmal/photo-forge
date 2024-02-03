import { Bell, Camera, LogOut, User } from "lucide-react";

import {
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";

const AuthenticatedUserMenuContent = () => {
  return (
    <>
      <DropdownMenuGroup>
        <DropdownMenuLabel>Moje konto</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <User className="mr-2 h-4 w-4" />
            <span>Profil</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <Camera className="mr-2 h-4 w-4" />
            <span>Moje zdjęcia</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <Bell className="mr-2 h-4 w-4" />
            <span>Powiadomienia</span>
          </DropdownMenuItem>
          <DropdownMenuSeparator />
          <DropdownMenuItem className="text-red-600">
            <LogOut className="mr-2 h-4 w-4" />
            <span>Wyloguj się</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
      </DropdownMenuGroup>
    </>
  );
};

export default AuthenticatedUserMenuContent;
