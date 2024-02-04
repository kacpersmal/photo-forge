import {
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";
import { LogIn, UserRoundPlus } from "lucide-react";

const UnauthenticatedUserMenuContent = () => {
  return (
    <>
      <DropdownMenuGroup>
        <DropdownMenuLabel>Autoryzacja</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <LogIn className="mr-2 size-4" />
            <span>Zaloguj się</span>
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
