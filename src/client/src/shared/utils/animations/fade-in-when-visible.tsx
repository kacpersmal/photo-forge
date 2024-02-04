import { motion } from "framer-motion";

type FadeInWhenVisibleProps = {
  children: React.ReactNode | React.ReactNode[];
  duration?: number;
  delay?: number;
  once?: boolean;
  className?: string;
};
const FadeInWhenVisible = ({
  children,
  className,
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
      className={className ? className : ""}
    >
      {children}
    </motion.div>
  );
};
export default FadeInWhenVisible;
