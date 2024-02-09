import { AuthSession } from "@/api/auth/sign-in";
import { UserPrincipal } from "@/api/token-helpers";
import { create } from "zustand";

interface AuthState {
  authSession: AuthSession | null;
  logout: () => void;
  setAuthSession: (authSession: AuthSession) => void;
  setUser: (user: UserPrincipal) => void;
  user: UserPrincipal | null; 
}

const useAuthStore = create<AuthState>(set => ({
  authSession: null as AuthSession | null,
  logout: () => set({ authSession: null, user: null}),
  setAuthSession: (authSession: AuthSession) => set({ authSession }),
  setUser: (user: UserPrincipal) => set({ user }),
  user: null as UserPrincipal | null,
}));

export default useAuthStore;
