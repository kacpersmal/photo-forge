import { Button } from "@/components/ui/button";
import FacebookIcon from "@/shared/icons/facebook-icon";
import InstagramIcon from "@/shared/icons/instagram-icon";
import TikTokIcon from "@/shared/icons/tiktok-icon";
import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
import { Mail, Phone } from "lucide-react";
import { Link } from "react-router-dom";

type SocialsSectionProps = { id: string };
const SocialsSection = ({ id }: SocialsSectionProps) => {
  return (
    <Section className="grid h-screen place-items-center" data-name={id} id={id}>
      <div className="text-center">
        <FadeInWhenVisible>
          <h1 className="mb-4 text-4xl font-bold text-primary">Skontakuj się ze mną</h1>
        </FadeInWhenVisible>
        <FadeInWhenVisible delay={1}>
          <div className="mb-8 text-lg">
            <p>Znajdź mnie na swoich social mediach albo skontaktuj się ze mną prywatnie!</p>
            lub skorzystaj z
            <Link to="/kontakt">
              <Button className="ml-2 text-background" size="sm">
                Mojego formularzu kontaktowego
              </Button>
            </Link>
          </div>
        </FadeInWhenVisible>

        <FadeInWhenVisible className="grid grid-cols-2 grid-rows-3 gap-2" delay={1.5}>
          <a className="flex flex-row items-center gap-2" href="https://www.instagram.com/">
            <InstagramIcon className="size-12 bg-primary p-2 text-background" />
            @Instagram
          </a>
          <a className="flex flex-row items-center gap-2" href="https://www.instagram.com/">
            <FacebookIcon className="size-12 bg-primary p-2 text-background" />
            @Facebook
          </a>
          <a className="flex flex-row items-center gap-2" href="https://www.instagram.com/">
            <TikTokIcon className="size-12 bg-primary p-2 text-background" />
            @TikTok
          </a>
          <a className="flex flex-row items-center gap-2" href="https://www.instagram.com/">
            <Mail className="size-12 bg-primary p-2 text-background" />
            @email
          </a>
          <a className="flex flex-row items-center gap-2" href="https://www.instagram.com/">
            <Phone className="size-12 bg-primary p-2 text-background" />
            @phone
          </a>
        </FadeInWhenVisible>
      </div>
    </Section>
  );
};

export default SocialsSection;
