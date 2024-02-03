import HeroSection from "./hero-section";
import PreviewSection from "./preview-section";
import AnchorNav from "../../shared/components/anchor-nav";

const anchors = ["hero", "preview", "contact"];
const HomePage = () => {
  return (
    <>
      <div>
        <HeroSection id={anchors[0]} />
        <PreviewSection id={anchors[1]} />
        <HeroSection id={anchors[2]} />
      </div>
      <AnchorNav />
    </>
  );
};

export default HomePage;
