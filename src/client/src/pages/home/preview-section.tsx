import { Carousel, CarouselContent, CarouselItem } from "@/components/ui/carousel";
import Autoplay from "embla-carousel-autoplay";
import { motion } from "framer-motion";

type PreviewSectionProps = {
  id: string;
};
const PreviewSection = ({ id }: PreviewSectionProps) => {
  return (
    <motion.div
      id={id}
      data-name={id}
      className="flex flex-col sm:flex-row items-center justify-center h-screen"
      initial={{ opacity: 0 }}
      whileInView={{ opacity: 1 }}
      viewport={{ once: true }}
      transition={{ delay: 1, duration: 1 }}
    >
      <motion.h1
        className="text-3xl md:text-5xl p-6 md:p-0 font-bold text-left md:mb-4 md:mr-4"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ delay: 1, duration: 1 }}
      >
        O to parę moich ujęć
      </motion.h1>
      <Carousel
        opts={{
          align: "start",
          loop: true,
          dragFree: true,
        }}
        plugins={[
          Autoplay({
            delay: 2000,
            stopOnInteraction: false,
          }),
        ]}
        className="flex items-center justify-center h-screen w-screen max-w-screen-md"
      >
        <CarouselContent className="">
          {Array.from({ length: 10 }).map((_, index) => (
            <CarouselItem key={index} className="basis-1/3">
              <div className="p-1 aspect-square">
                {Array.from({ length: 3 }).map((_, gridIndex) => (
                  <img
                    src={`https://source.unsplash.com/random?sig=${gridIndex * 100 + index}`}
                    alt={`Preview ${index}`}
                    className="object-cover w-full h-full"
                  />
                ))}
              </div>
            </CarouselItem>
          ))}
        </CarouselContent>
      </Carousel>
    </motion.div>
  );
};

export default PreviewSection;
