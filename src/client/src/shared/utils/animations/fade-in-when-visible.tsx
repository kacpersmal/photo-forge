import { motion } from "framer-motion";

type FadeInWhenVisibleProps = {
  children: React.ReactNode | React.ReactNode[];
  className?: string;
  delay?: number;
  duration?: number;
  once?: boolean;
};
const FadeInWhenVisible = ({
  children,
  className,
  delay = 0.5,
  duration = 1,
  once = true,
}: FadeInWhenVisibleProps) => {
  return (
    <motion.div
      className={className ? className : ""}
      initial="hidden"
      transition={{ delay: delay, duration: duration }}
      variants={{
        hidden: { opacity: 0 },
        visible: { opacity: 1 },
      }}
      viewport={{ once: once }}
      whileInView="visible"
    >
      {children}
    </motion.div>
  );
};
export default FadeInWhenVisible;
