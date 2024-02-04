import { MotionProps } from "framer-motion";

const AppearOnSight = (delay: number, once = false) => {
  const cfg: MotionProps = {
    initial: { opacity: 0 },
    whileInView: { opacity: 1, transition: { delay: delay } },
    viewport: { once: once, margin: "-200" },
  };

  return cfg;
};

export { AppearOnSight };
