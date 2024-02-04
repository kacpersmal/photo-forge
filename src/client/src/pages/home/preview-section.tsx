import { Carousel, CarouselContent, CarouselItem } from "@/components/ui/carousel";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
import Autoplay from "embla-carousel-autoplay";

type PreviewSectionProps = {
  id: string;
};
const PreviewSection = ({ id }: PreviewSectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className="flex flex-col sm:flex-row items-center justify-center h-screen snap-start"
    >
      <div className="flex flex-col md:flex-row md:items-center">
        <FadeInWhenVisible>
          <h1 className="text-3xl md:text-5xl p-6 md:p-0 font-bold text-left md:mb-4 md:mr-4">
            O to parę moich ujęć
          </h1>
        </FadeInWhenVisible>
        <FadeInWhenVisible delay={1}>
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
            className="flex items-center justify-center h-full w-screen max-w-screen-md"
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
        </FadeInWhenVisible>
      </div>
    </div>
  );
};

export default PreviewSection;
