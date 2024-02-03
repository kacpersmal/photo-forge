import { motion } from "framer-motion";

type HeroSectionProps = {
  id: string;
};
const HeroSection = ({ id }: HeroSectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className="h-screen bg-cover bg-center"
      style={{ backgroundImage: "url('https://source.unsplash.com/random')" }}
    >
      <div className="h-full bg-black bg-opacity-50 flex items-center justify-center">
        <motion.div
          initial={{ opacity: 0, y: -50 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 1 }}
          className="text-center text-white"
        >
          <motion.h1
            className="text-5xl font-bold mb-4"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            transition={{ delay: 1, duration: 1 }}
          >
            Witaj na moim portfolio
          </motion.h1>
          <motion.p
            className="text-xl"
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            transition={{ delay: 2, duration: 1 }}
          >
            Witaj w moim portfolio, gdzie światło staje się historią, a cienie malują emocje. Każde
            zdjęcie to krok w niezwykłą podróż przez moje obiektywy.
          </motion.p>
        </motion.div>
      </div>
    </div>
  );
};

export default HeroSection;
