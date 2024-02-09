import { Card, CardContent, CardHeader } from "@/components/ui/card";
import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";

import SignInForm from "./sign-in/sign-in-form";

const SignInPage = () => {
  return (
    <Section className="grid h-screen place-items-center" id="sign-in">
      <FadeInWhenVisible duration={0.125}>
        <Card className="bg-background">
          <CardHeader>
            <h1 className="mb-4 text-5xl font-bold text-primary">Zaloguj się!</h1>
          </CardHeader>
          <CardContent>
            <SignInForm />
          </CardContent>
        </Card>
      </FadeInWhenVisible>
    </Section>
  );
};

export default SignInPage;
