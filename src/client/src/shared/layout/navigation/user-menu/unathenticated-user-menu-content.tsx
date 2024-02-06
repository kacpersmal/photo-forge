import {
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";
import { LogIn, UserRoundPlus } from "lucide-react";
import { Link } from "react-router-dom";

const UnauthenticatedUserMenuContent = () => {
  return (
    <>
      <DropdownMenuGroup>
        <DropdownMenuLabel>Autoryzacja</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <Link className="flex flex-row items-center" to="/zaloguj-się">
              <LogIn className="mr-2 size-4" />
              <span>Zaloguj się</span>
            </Link>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <UserRoundPlus className="mr-2 size-4" />
            <span>Utwórz nowe konto</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
      </DropdownMenuGroup>
    </>
  );
};

export default UnauthenticatedUserMenuContent;
