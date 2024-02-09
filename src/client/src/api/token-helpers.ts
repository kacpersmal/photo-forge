import { jwtDecode } from "jwt-decode";

type UserPrincipal = {
  aud: string;
  email: string;
  exp: number;
  iat: number;
  iss: string;
  nameid: string;
  nbf: number;
  role: "Admin" | "Guest";
};

const DecodeToken = (token: string): UserPrincipal => {
  return jwtDecode(token) as UserPrincipal;
};

export default DecodeToken;
export type { UserPrincipal };
