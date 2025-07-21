import { Card, styled } from "@mui/material";
import type { ReactNode } from "react";

const CardRoot = styled(Card)({
  height: "100%",
  padding: "20px 24px",
  ".subtitle": { marginBottom: "1rem" },
});

interface CardTitleProps {
  subtitle?: string;
}

const CardTitle = styled("div")<CardTitleProps>(({ subtitle }) => ({
  fontSize: "1rem",
  fontWeight: 500,
  textTransform: "capitalize",
  marginBottom: !subtitle ? "16px" : undefined,
}));

interface SimpleCardProps {
  children?: ReactNode;
  title?: string;
  subtitle?: string;
}

const SimpleCard = ({ children, title, subtitle }: SimpleCardProps) => (
  <CardRoot elevation={6}>
    <CardTitle subtitle={subtitle}>{title}</CardTitle>
    {subtitle && <div className="subtitle">{subtitle}</div>}
    {children}
  </CardRoot>
);

export default SimpleCard;
