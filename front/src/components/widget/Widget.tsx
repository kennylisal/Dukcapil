import { WidgetContainer, WidgetTitle, WidgetTitleContainer } from "./styled";
import { type ReactNode } from "react";
import { Box, type BoxProps } from "@mui/material";

export interface WidgetProps {
  title: string;
  children?: ReactNode;
  sx?: BoxProps["sx"];
  contentHeight?: string;
}

export const Widget = ({ title, children, sx, contentHeight }: WidgetProps) => {
  return (
    <WidgetContainer sx={sx}>
      <WidgetTitleContainer>
        <WidgetTitle>{title}</WidgetTitle>
      </WidgetTitleContainer>
      <Box sx={{ flexGrow: 1, height: contentHeight }}>
        <Box height={"100%"}>{children}</Box>
      </Box>
    </WidgetContainer>
  );
};
