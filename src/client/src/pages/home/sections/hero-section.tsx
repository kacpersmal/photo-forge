import Section from "@/shared/layout/section";

type HeroSectionProps = {
  id: string;
};
const HeroSection = ({ id }: HeroSectionProps) => {
  return (
    <Section id={id} bgImage="https://source.unsplash.com/random">
      <div className="grid h-screen place-items-center">
        <div className="p-2 md:p-0">
          <h1 className="mb-4 text-5xl font-bold text-primary">"Uchwyć Chwilę, Zatrzymaj Czas"</h1>
          <p className="max-w-xl text-lg font-semibold text-white">
            Zapraszam Cię do magicznego świata kreatywności, światła i emocji. Jesteś gotów na
            podróż przez unikalne chwile, uwiecznione obiektywem? Witaj na moim portfolio
            fotograficznym, gdzie każde zdjęcie opowiada niepowtarzalną historię.
          </p>
        </div>
      </div>
    </Section>
  );
};

export default HeroSection;
