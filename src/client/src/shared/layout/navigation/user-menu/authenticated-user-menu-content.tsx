import {
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";
import useAuthStore from "@/state/auth-store";
import { Bell, Camera, LogOut, User } from "lucide-react";
import { useNavigate } from "react-router-dom";

const AuthenticatedUserMenuContent = () => {
  const logout = useAuthStore(state => state.logout);
  const navigate = useNavigate();

  const onLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <>
      <DropdownMenuGroup>
        <DropdownMenuLabel>Moje konto</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <User className="mr-2 size-4" />
            <span>Profil</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <Camera className="mr-2 size-4" />
            <span>Moje zdjęcia</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <Bell className="mr-2 size-4" />
            <span>Powiadomienia</span>
          </DropdownMenuItem>
          <DropdownMenuSeparator />
          <DropdownMenuItem className="text-red-600" onClick={onLogout}>
            <LogOut className="mr-2 size-4" />
            <span>Wyloguj się</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
      </DropdownMenuGroup>
    </>
  );
};

export default AuthenticatedUserMenuContent;
