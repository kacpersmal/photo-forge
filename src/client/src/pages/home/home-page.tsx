import HeroSection from "./sections/hero-section";
import PreviewSection from "./sections/preview-section";
import AnchorNav from "../../shared/components/anchor-nav";
import SocialsSection from "./sections/socials-section";
import AboutSection from "./sections/about-section";

const anchors = ["hero", "preview", "about", "socials"];
const HomePage = () => {
  return (
    <>
      <div>
        <HeroSection id={anchors[0]} />
        <PreviewSection id={anchors[1]} />
        <AboutSection id={anchors[2]} />
        <SocialsSection id={anchors[3]} />
      </div>
      <AnchorNav />
    </>
  );
};

export default HomePage;
