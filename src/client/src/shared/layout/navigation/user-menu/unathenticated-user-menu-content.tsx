import { LogIn, UserRoundPlus } from "lucide-react";

import {
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";

const UnauthenticatedUserMenuContent = () => {
  return (
    <DropdownMenuContent className="w-56">
      <DropdownMenuLabel>Autoryzacja</DropdownMenuLabel>
      <DropdownMenuSeparator />
      <DropdownMenuGroup>
        <DropdownMenuItem>
          <LogIn className="mr-2 h-4 w-4" />
          <span>Zaloguj się</span>
        </DropdownMenuItem>
        <DropdownMenuItem>
          <UserRoundPlus className="mr-2 h-4 w-4" />
          <span>Utwórz nowe konto</span>
        </DropdownMenuItem>
      </DropdownMenuGroup>
    </DropdownMenuContent>
  );
};

export default UnauthenticatedUserMenuContent;
