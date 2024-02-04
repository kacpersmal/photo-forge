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
    <Section className="grid h-screen place-items-center" id={id}>
      <div className="grid-cols-2 grid-rows-1 place-items-center md:grid">
        <FadeInWhenVisible className="p-2">
          <h1 className="text-left text-3xl  font-bold text-primary md:mb-4 md:mr-4 md:p-0 md:text-5xl">
            O to parę moich ujęć
          </h1>
          <p className="max-w-xl text-lg font-semibold">Spójrz na to z mojej perspektywy</p>
          <Link to="/galeria">
            <Button className="mt-4 text-background">
              Zobacz więcej <ArrowRight />
            </Button>
          </Link>
        </FadeInWhenVisible>
        <FadeInWhenVisible className="" delay={1}>
          <Carousel
            opts={{
              align: "start",
              dragFree: true,
              loop: true,
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
                <CarouselItem className="basis-1/3" key={index}>
                  <div className=" aspect-square">
                    {Array.from({ length: 3 }).map((_, gridIndex) => (
                      <img
                        alt={`Preview ${index}`}
                        className="size-full object-cover py-2"
                        src={`https://source.unsplash.com/random?sig=${gridIndex * 100 + index}`}
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
