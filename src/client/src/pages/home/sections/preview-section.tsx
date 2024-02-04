import { Button } from "@/components/ui/button";
import { Carousel, CarouselContent, CarouselItem } from "@/components/ui/carousel";
import Section from "@/shared/layout/section";
import FadeInWhenVisible from "@/shared/utils/animations/fade-in-when-visible";
import Autoplay from "embla-carousel-autoplay";
import { ArrowRight } from "lucide-react";
import { Link } from "react-router-dom";

type PreviewSectionProps = {
  id: string;
};
const PreviewSection = ({ id }: PreviewSectionProps) => {
  return (
    <Section id={id} className="grid h-screen place-items-center">
      <div className="md:grid grid-rows-1 grid-cols-2 place-items-center">
        <FadeInWhenVisible className="p-2">
          <h1 className="text-3xl md:text-5xl  md:p-0 font-bold text-left md:mb-4 md:mr-4 text-primary">
            O to parę moich ujęć
          </h1>
          <p className="max-w-xl text-lg font-semibold">Spójrz na to z mojej perspektywy</p>
          <Link to="/galeria">
            <Button className="mt-4 text-background">
              Zobacz więcej <ArrowRight />
            </Button>
          </Link>
        </FadeInWhenVisible>
        <FadeInWhenVisible delay={1} className="">
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
          >
            <CarouselContent className="">
              {Array.from({ length: 10 }).map((_, index) => (
                <CarouselItem key={index} className="basis-1/3">
                  <div className=" aspect-square">
                    {Array.from({ length: 3 }).map((_, gridIndex) => (
                      <img
                        src={`https://source.unsplash.com/random?sig=${gridIndex * 100 + index}`}
                        alt={`Preview ${index}`}
                        className="object-cover w-full h-full py-2"
                      />
                    ))}
                  </div>
                </CarouselItem>
              ))}
            </CarouselContent>
          </Carousel>
        </FadeInWhenVisible>
      </div>
    </Section>
  );
};

export default PreviewSection;
