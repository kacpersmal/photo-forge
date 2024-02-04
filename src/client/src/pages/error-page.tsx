import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Frown } from "lucide-react";
import { useRouteError } from "react-router-dom";

export default function ErrorPage() {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const error = useRouteError() as any;

  return (
    <div id="error-page" className="flex h-screen items-center justify-center">
      <Card>
        <CardHeader>
          <CardTitle>Ooops!</CardTitle>
          <CardDescription>
            Przepraszamy, ale coś poszło nie tak. Spróbuj ponownie później.
          </CardDescription>
        </CardHeader>
        <CardContent className="flex flex-col items-center justify-center">
          <Frown className="size-24 text-red-500" />
          <h1 className="text-red-500">{error.statusText || error.message}</h1>
        </CardContent>
      </Card>
    </div>
  );
}
