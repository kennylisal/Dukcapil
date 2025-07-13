import Box from "@mui/material/Box";
import { styled } from "@mui/material";
import { MatxLogo } from "../components/index";
import { Span } from "./Typography";
import useSettings from "../hooks/useSettings";

// Define the type for the settings object
interface Settings {
  layout1Settings: {
    leftSidebar: {
      mode: "compact" | "full";
    };
  };
}

// Define the props type for the Brand component
interface BrandProps {
  children?: React.ReactNode;
}

// STYLED COMPONENTS
const BrandRoot = styled("div")(() => ({
  display: "flex",
  alignItems: "center",
  justifyContent: "space-between",
  padding: "20px 18px 20px 29px",
}));

const StyledSpan = styled(Span)(({ mode }: { mode: "compact" | "full" }) => ({
  fontSize: 18,
  marginLeft: ".5rem",
  display: mode === "compact" ? "none" : "block",
}));

export default function Brand({ children }: BrandProps) {
  const { settings } = useSettings() as { settings: Settings };
  const leftSidebar = settings.layout1Settings.leftSidebar;
  const { mode } = leftSidebar;

  return (
    <BrandRoot>
      <Box display="flex" alignItems="center">
        <MatxLogo />
        <StyledSpan mode={mode} className="sidenavHoverShow">
          Matx
        </StyledSpan>
      </Box>

      <Box
        className="sidenavHoverShow"
        sx={{ display: mode === "compact" ? "none" : "block" }}
      >
        {children || null}
      </Box>
    </BrandRoot>
  );
}
