type SectionProps = {
  bgImage?: string;
  children: React.ReactNode;
  className?: string;
  id: string;
};
const Section = ({ bgImage, children, className, id }: SectionProps) => {
  return (
    <div
      className={["min-h-lvh bg-cover bg-center snap-start", className].join(" ")}
      data-name={id}
      id={id}
      style={{ backgroundImage: bgImage ? `url(${bgImage})` : "none" }}
    >
      {bgImage == undefined ? children : <div className="min-h-lvh bg-black/50">{children}</div>}
    </div>
  );
};

export default Section;
