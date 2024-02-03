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
import { motion } from "framer-motion";

const UserMenu = () => {
  return (
    <DropdownMenu>
      <motion.div whileTap={{ scale: 0.8 }}>
        <DropdownMenuTrigger asChild>
          <Button variant="ghost" size="icon">
            <CircleUserRound className="h-6 w-6" />
          </Button>
        </DropdownMenuTrigger>
      </motion.div>

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
