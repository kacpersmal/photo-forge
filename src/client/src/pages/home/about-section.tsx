import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";

type AboutSectionProps = { id: string };
const AboutSection = ({ id }: AboutSectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className="h-screen bg-cover bg-center snap-start"
      style={{ backgroundImage: "url('https://source.unsplash.com/random/1')" }}
    >
      <div className="h-full bg-black bg-opacity-50 flex items-center justify-center">
        <div className="text-center text-white flex flex-col md:flex-row items-center justify-center">
          <FadeInWhenVisible>
            <div className="md:w-1/2">
              <h1 className="text-2xl md:text-5xl font-bold mb-4"> Witaj na moim portfolio</h1>
              <p className="text-sm md:text-2xl">
                Witaj w moim portfolio, gdzie światło staje się historią, a cienie malują emocje.
                Każde zdjęcie to krok w niezwykłą podróż przez moje obiektywy.
              </p>
            </div>
          </FadeInWhenVisible>
          <FadeInWhenVisible delay={1}>
            <div className="md:mr-0 md:ml-auto mb-0 mt-auto">
              <img
                src="https://source.unsplash.com/random/2"
                alt="About me"
                className="max-h-svh aspect-auto object-cover mb-0 mt-auto p-0"
              />
            </div>
          </FadeInWhenVisible>
        </div>
      </div>
    </div>
  );
};

export default AboutSection;
