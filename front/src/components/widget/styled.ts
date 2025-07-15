import { Box, Paper, styled, Typography } from "@mui/material";

export const WidgetContainer = styled(Paper)<{
  borderRadius?: string | number;
  padding?: string | number;
}>(({ theme, borderRadius, padding }) => ({
  border: `1px solid ${theme.palette.divider}`,
  padding: padding ?? theme.spacing(2),
  borderRadius: borderRadius ?? theme.shape.borderRadius,
  flex: 1,
  justifyContent: "space-between",
  flexDirection: "column",
  height: "100%",
  display: "flex",
}));

export const WidgetTitleContainer = styled(Box)(({ theme }) => ({
  marginBottom: theme.spacing(2),
}));

export const WidgetTitle = styled(Typography)(({ theme }) => ({
  fontSize: theme.typography.h6.fontSize,
  fontWeight: theme.typography.h6.fontWeight,
  color: theme.palette.text.primary,
}));
