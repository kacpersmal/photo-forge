import { MotionProps } from "framer-motion";

const AppearOnSight = (delay: number, once = false) => {
  const cfg: MotionProps = {
    initial: { opacity: 0 },
    viewport: { margin: "-200", once: once },
    whileInView: { opacity: 1, transition: { delay: delay } },
  };

  return cfg;
};

export { AppearOnSight };
