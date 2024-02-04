import { motion } from "framer-motion";
import SocialCard, { SocialCardProps } from "./social-card";
import { Facebook, Instagram } from "lucide-react";

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
    <motion.div
      id={id}
      data-name={id}
      className="flex flex-col sm:flex-row items-center justify-center h-screen snap-start"
      initial={{ opacity: 0 }}
      whileInView={{ opacity: 1 }}
      viewport={{ once: false, margin: "-200px" }}
      transition={{ delay: 1, duration: 1 }}
    >
      <div className="flex flex-col w-1/2 h-1/2">
        <h1 className="text-3xl md:text-5xl p-6 md:p-0 font-bold text-center mb-10">
          Moje sociale
        </h1>
        <div className="flex flex-col md:flex-row gap-4 w-full h-full">
          {socials.map((social, index) => (
            <SocialCard key={index} {...social} />
          ))}
        </div>
      </div>
    </motion.div>
  );
};

export default SocialsSection;
