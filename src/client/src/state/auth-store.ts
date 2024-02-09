import { UserPrincipal } from "@/api/token-helpers";
import { create } from "zustand";

interface AuthState {
  logout: () => void;
  setUser: (user: UserPrincipal) => void;
  user: UserPrincipal | null;
}

const useAuthStore = create<AuthState>(set => ({
  logout: () => set({ user: null }),
  setUser: (user: UserPrincipal) => set({ user }),
  user: null as UserPrincipal | null,
}));

export default useAuthStore;
