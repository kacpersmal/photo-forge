import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";

type AboutSectionProps = { id: string };
const AboutSection = ({ id }: AboutSectionProps) => {
  return (
    <Section id={id} bgImage="https://source.unsplash.com/random/1">
      <div className="grid h-screen place-items-center">
        <div className="md:grid grid-rows-1 grid-cols-2 place-items-center w-full h-full">
          <FadeInWhenVisible className="p-2">
            <h1 className="text-3xl md:text-5xl  md:p-0 font-bold text-left md:mb-4 md:mr-4 text-primary">
              Poznajmy się
            </h1>
            <p className="text-white max-w-xl text-lg">
              Jestem Gabriela, pełna energii i entuzjazmu młoda artystka z pasją do fotografii i
              muzyki. Moje dni wypełnione są dźwiękami, a moim aparatem staram się zatrzymać każdy
              unikalny moment, przechwycić emocje i opowiedzieć historię, która nieśmiało szepcze
              zza obiektywu.
            </p>
          </FadeInWhenVisible>
          <FadeInWhenVisible delay={1} className="w-full h-full">
            <img
              src="https://source.unsplash.com/random/1"
              alt="Preview 1"
              className="object-cover w-full max-h-lvh p-2 md:p-0"
            />
          </FadeInWhenVisible>
        </div>
      </div>
    </Section>
  );
};

export default AboutSection;
