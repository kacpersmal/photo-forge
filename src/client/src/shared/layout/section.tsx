type SectionProps = {
  id: string;
  className?: string;
  children: React.ReactNode;
  bgImage?: string;
};
const Section = ({ id, bgImage, children, className }: SectionProps) => {
  return (
    <div
      id={id}
      data-name={id}
      className={["min-h-lvh bg-cover bg-center snap-start", className].join(" ")}
      style={{ backgroundImage: bgImage ? `url(${bgImage})` : "none" }}
    >
      {bgImage == undefined ? (
        children
      ) : (
        <div className="min-h-lvh bg-black bg-opacity-50">{children}</div>
      )}
    </div>
  );
};

export default Section;
