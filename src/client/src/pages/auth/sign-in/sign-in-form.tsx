import SignInFn, { SignInSchema, SignInSchemaType } from "@/api/auth/sign-in";
import DecodeToken from "@/api/token-helpers";
import { Button } from "@/components/ui/button";
import { Form, FormControl, FormField, FormItem, FormLabel } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import useAuthStore from "@/state/auth-store";
import { zodResolver } from "@hookform/resolvers/zod";
import { ReloadIcon } from "@radix-ui/react-icons";
import { useMutation } from "@tanstack/react-query";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";

const SignInForm = () => {
  const setUser = useAuthStore(state => state.setUser);
  const setAuthSession = useAuthStore(state => state.setAuthSession);
  const navigate = useNavigate();
  const mutation = useMutation({
    mutationFn: SignInFn,
    onSuccess: data => {
      const decoded = DecodeToken(data.token.value);
      setUser(decoded);
      setAuthSession(data);
      if (decoded.role === "Admin") navigate("/dashboard");
      navigate("/");
    },
  });

  const form = useForm<SignInSchemaType>({
    defaultValues: {
      email: "",
      password: "",
    },
    resolver: zodResolver(SignInSchema),
  });

  function onSubmit(values: SignInSchemaType) {
    mutation.mutate(values);
  }

  return (
    <Form {...form}>
      <form className="" onSubmit={form.handleSubmit(onSubmit)}>
        <div className="mb-2">
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Twój adres email</FormLabel>
                <FormControl>
                  <Input autoComplete="signin-email" placeholder="email" {...field} />
                </FormControl>
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="password"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Hasło</FormLabel>
                <FormControl>
                  <Input autoComplete="signin-password" type="password" {...field} />
                </FormControl>
              </FormItem>
            )}
          />
        </div>
        <Button className="w-full text-background" disabled={mutation.isPending} type="submit">
          {mutation.isPending && <ReloadIcon className="mr-2 size-4 animate-spin" />}
          Zaloguj się
        </Button>
      </form>
    </Form>
  );
};

export default SignInForm;
