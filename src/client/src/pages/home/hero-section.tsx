import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
type HeroSectionProps = {
  id: string;
};
const HeroSection = ({ id }: HeroSectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className="h-screen bg-cover bg-center snap-start"
      style={{ backgroundImage: "url('https://source.unsplash.com/random')" }}
    >
      <div className="h-full bg-black bg-opacity-50 flex items-center justify-center">
        <div className="text-center text-white">
          <FadeInWhenVisible>
            <h1 className="text-5xl font-bold mb-4">Witaj na moim portfolio</h1>
          </FadeInWhenVisible>
          <FadeInWhenVisible delay={1}>
            <p className="text-xl">
              Witaj w moim portfolio, gdzie światło staje się historią, a cienie malują emocje.
              Każde zdjęcie to krok w niezwykłą podróż przez moje obiektywy.
            </p>
          </FadeInWhenVisible>
        </div>
      </div>
    </div>
  );
};

export default HeroSection;
