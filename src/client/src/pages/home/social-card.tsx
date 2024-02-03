import { Card, CardContent } from "@/components/ui/card";

type SocialCardProps = { name: string, url: string, icon: React.ReactNode };
const SocialCard = ({name,url,icon} : SocialCardProps) => {
  return (
    <Card className="w-full aspect-square">
        <CardContent className="p-4">
         <a href={url} target="_blank" rel="noopener noreferrer">
           {icon}
         </a>
        </CardContent>
      </Card>
  );
};

export default SocialCard;
export type { SocialCardProps };