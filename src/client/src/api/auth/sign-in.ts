import { z } from "zod";

import AxiosInstance from "../client";

const SignInSchema = z.object({
  email: z.string().min(2, {}),
  password: z.string().min(8, {}),
});

type SignInSchemaType = z.infer<typeof SignInSchema>;

type AuthSession = {
  refreshToken: {
    expirationDate: string;
    value: string;
  };
  sessionId: string;
  token: {
    expirationDate: string;
    value: string;
  };
};

const SignInFn = async (data: SignInSchemaType): Promise<AuthSession> => {
  const response = await AxiosInstance.post<AuthSession>("/auth", data);
  return response.data;
};

export default SignInFn;
export { SignInSchema };
export type { AuthSession, SignInSchemaType };
