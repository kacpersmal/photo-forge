import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";

type AboutSectionProps = { id: string };
const AboutSection = ({ id }: AboutSectionProps) => {
  return (
    <Section bgImage="https://source.unsplash.com/random/1" id={id}>
      <div className="grid h-screen place-items-center">
        <div className="size-full grid-cols-2 grid-rows-1 place-items-center md:grid">
          <FadeInWhenVisible className="p-2">
            <h1 className="text-left text-3xl  font-bold text-primary md:mb-4 md:mr-4 md:p-0 md:text-5xl">
              Poznajmy się
            </h1>
            <p className="max-w-xl text-lg text-white">
              Jestem Gabriela, pełna energii i entuzjazmu młoda artystka z pasją do fotografii i
              muzyki. Moje dni wypełnione są dźwiękami, a moim aparatem staram się zatrzymać każdy
              unikalny moment, przechwycić emocje i opowiedzieć historię, która nieśmiało szepcze
              zza obiektywu.
            </p>
          </FadeInWhenVisible>
          <FadeInWhenVisible className="size-full" delay={1}>
            <img
              alt="Preview 1"
              className="max-h-lvh w-full object-cover p-2 md:p-0"
              src="https://source.unsplash.com/random/1"
            />
          </FadeInWhenVisible>
        </div>
      </div>
    </Section>
  );
};

export default AboutSection;
