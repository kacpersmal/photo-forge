import { motion } from "framer-motion";

type FadeInWhenVisibleProps = {
  children: React.ReactNode;
  duration?: number;
  delay?: number;
  once?: boolean;
};
const FadeInWhenVisible = ({
  children,
  duration = 1,
  delay = 0.5,
  once = true,
}: FadeInWhenVisibleProps) => {
  return (
    <motion.div
      initial="hidden"
      whileInView="visible"
      viewport={{ once: once }}
      transition={{ duration: duration, delay: delay }}
      variants={{
        visible: { opacity: 1 },
        hidden: { opacity: 0 },
      }}
      className="w-full h-full"
    >
      {children}
    </motion.div>
  );
};
export default FadeInWhenVisible;
