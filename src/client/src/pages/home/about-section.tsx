import { motion } from "framer-motion";

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
          <motion.div
            className="md:w-1/2"
            initial={{ opacity: 0 }}
            whileInView={{ opacity: 1 }}
            viewport={{ once: false, margin: "-200px" }}
            transition={{ delay: 0, duration: 1 }}
          >
            <h1 className="text-2xl md:text-5xl font-bold mb-4"> Witaj na moim portfolio</h1>
            <motion.div
              className=""
              initial={{ opacity: 0 }}
              whileInView={{ opacity: 1 }}
              viewport={{ once: false, margin: "-200px" }}
              transition={{ delay: 1, duration: 1 }}
            >
              <p className="text-sm md:text-2xl">
                Witaj w moim portfolio, gdzie światło staje się historią, a cienie malują emocje.
                Każde zdjęcie to krok w niezwykłą podróż przez moje obiektywy.
              </p>
            </motion.div>
          </motion.div>
          <motion.div
            className="md:mr-0 md:ml-auto mb-0 mt-auto"
            initial={{ opacity: 0 }}
            whileInView={{ opacity: 1 }}
            viewport={{ once: false, margin: "-200px" }}
            transition={{ delay: 2, duration: 1 }}
          >
            <img
              src="https://source.unsplash.com/random/2"
              alt="About me"
              className="max-h-svh aspect-auto object-cover mb-0 mt-auto p-0"
            />
          </motion.div>
        </div>
      </div>
    </div>
  );
};

export default AboutSection;
