import { Fragment } from "react";

import Breadcrumbs from "@mui/material/Breadcrumbs";

import { styled, type Theme } from "@mui/material/styles";
import HomeIcon from "@mui/icons-material/Home"; // Define the type for route segments
import { NavigateNext } from "@mui/icons-material";
import { NavLink } from "react-router-dom";
interface RouteSegment {
  name: string;
  path?: string;
}

// Define the props type for the Breadcrumb component
interface BreadcrumbProps {
  routeSegments?: RouteSegment[];
}

// STYLED COMPONENTS
const BreadcrumbRoot = styled("div")({
  display: "flex",
  flexWrap: "wrap",
  alignItems: "center",
});

const BreadcrumbName = styled("h4")(({ theme }: { theme: Theme }) => ({
  margin: 0,
  fontSize: "16px",
  paddingBottom: "1px",
  verticalAlign: "middle",
  textTransform: "capitalize",
  [theme.breakpoints.down("xs")]: { display: "none" },
}));

const SubName = styled("span")(({ theme }: { theme: Theme }) => ({
  textTransform: "capitalize",
  color: theme.palette.text.secondary,
}));

const Separator = styled("h4")(({ theme }: { theme: Theme }) => ({
  margin: 0,
  marginLeft: 8,
  paddingBottom: "3px",
  color: theme.palette.text.secondary,
  [theme.breakpoints.down("xs")]: { display: "none" },
}));

const StyledIcon = styled(HomeIcon)({
  marginLeft: 8,
  marginBottom: "4px",
  verticalAlign: "middle",
});

export default function Breadcrumb({ routeSegments }: BreadcrumbProps) {
  return (
    <BreadcrumbRoot>
      {routeSegments ? (
        <Fragment>
          <BreadcrumbName>
            {routeSegments[routeSegments.length - 1].name}
          </BreadcrumbName>
          <Separator>|</Separator>
        </Fragment>
      ) : null}

      <Breadcrumbs
        separator={<NavigateNext sx={{ color: "text.hint" }} />}
        sx={{ display: "flex", alignItems: "center", position: "relative" }}
      >
        <NavLink to="/">
          <StyledIcon color="primary" />
        </NavLink>

        {routeSegments
          ? routeSegments.map((route, index) => {
              return index !== routeSegments.length - 1 ? (
                <NavLink key={index} to={route.path ?? "#"}>
                  <SubName>{route.name}</SubName>
                </NavLink>
              ) : (
                <SubName key={index}>{route.name}</SubName>
              );
            })
          : null}
      </Breadcrumbs>
    </BreadcrumbRoot>
  );
}
