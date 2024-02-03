import HeroSection from "./hero-section";
import PreviewSection from "./preview-section";
import AnchorNav from "../../shared/components/anchor-nav";
import SocialsSection from "./socials-section";

const anchors = ["hero", "preview", "socials"];
const HomePage = () => {
  return (
    <>
      <div>
        <HeroSection id={anchors[0]} />
        <PreviewSection id={anchors[1]} />
        <SocialsSection id={anchors[2]} />
      </div>
      <AnchorNav />
    </>
  );
};

export default HomePage;
