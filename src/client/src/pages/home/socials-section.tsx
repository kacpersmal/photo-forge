import SocialCard, { SocialCardProps } from "./social-card";
import { Facebook, Instagram } from "lucide-react";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
const socials: SocialCardProps[] = [
  {
    name: "Facebook",
    url: "https://facebook.com",
    icon: <Facebook className="w-full h-full text-blue-600" />,
  },
  {
    name: "Instagram",
    url: "https://instagram.com",
    icon: <Instagram className="w-full h-full text-pink-700" />,
  },
];

type SocialsSectionProps = { id: string };
const SocialsSection = ({ id }: SocialsSectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className="flex flex-col sm:flex-row items-center justify-center h-screen snap-start"
    >
      <div className="flex flex-col w-1/2 h-1/2">
        <FadeInWhenVisible>
          <h1 className="text-3xl md:text-5xl p-6 md:p-0 font-bold text-center mb-10">
            Moje sociale
          </h1>
        </FadeInWhenVisible>
        <div className="flex flex-col md:flex-row gap-4 w-full h-full">
          {socials.map((social, index) => (
            <FadeInWhenVisible delay={1 + index}>
              <SocialCard key={index} {...social} />
            </FadeInWhenVisible>
          ))}
        </div>
      </div>
    </div>
  );
};

export default SocialsSection;
