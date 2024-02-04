import { Button } from "@/components/ui/button";
import FacebookIcon from "@/shared/icons/facebook-icon";
import InstagramIcon from "@/shared/icons/instagram-icon";
import TikTokIcon from "@/shared/icons/tiktok-icon";
import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
import { Contact, Mail, Phone } from "lucide-react";
import { Link } from "react-router-dom";

type SocialsSectionProps = { id: string };
const SocialsSection = ({ id }: SocialsSectionProps) => {
  return (
    <Section id={id} data-name={id} className="grid h-screen place-items-center">
      <div className="text-center">
        <FadeInWhenVisible>
          <h1 className="text-4xl font-bold mb-4 text-primary">Skontakuj się ze mną</h1>
        </FadeInWhenVisible>
        <FadeInWhenVisible delay={1}>
          <div className="text-lg mb-8">
            <p>Znajdź mnie na swoich social mediach albo skontaktuj się ze mną prywatnie!</p>
            lub skorzystaj z
            <Link to="/kontakt">
              <Button className="ml-2 text-background" size="sm">
                Mojego formularzu kontaktowego
              </Button>
            </Link>
          </div>
        </FadeInWhenVisible>

        <FadeInWhenVisible delay={1.5} className="grid grid-rows-3 grid-cols-2 gap-2">
          <a className="flex flex-row items-center gap-2">
            <InstagramIcon className="w-12 h-12 bg-primary p-2 text-background" />
            @Instagram
          </a>
          <a className="flex flex-row items-center gap-2">
            <FacebookIcon className="w-12 h-12 bg-primary p-2 text-background" />
            @Facebook
          </a>
          <a className="flex flex-row items-center gap-2">
            <TikTokIcon className="w-12 h-12 bg-primary p-2 text-background" />
            @TikTok
          </a>
          <a className="flex flex-row items-center gap-2">
            <Mail className="w-12 h-12 bg-primary p-2 text-background" />
            @email
          </a>
          <a className="flex flex-row items-center gap-2">
            <Phone className="w-12 h-12 bg-primary p-2 text-background" />
            @phone
          </a>
        </FadeInWhenVisible>
      </div>
    </Section>
  );
};

export default SocialsSection;
