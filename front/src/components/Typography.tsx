import { styled } from "@mui/material";
import Box, { type BoxProps } from "@mui/material/Box";
import clsx from "clsx";
import type { ReactNode } from "react";

interface StyledBoxProps extends BoxProps {
  ellipsis: boolean;
}
const StyledBox = styled(Box)<StyledBoxProps>(({ ellipsis }) => ({
  textTransform: "none",
  ...(ellipsis && {
    overflow: "hidden",
    whiteSpace: "nowrap",
    textOverflow: "ellipsis",
  }),
}));

interface TypographyProps extends BoxProps {
  children?: ReactNode;
  className?: string;
  ellipsis?: boolean;
}

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H1 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h1"
      fontSize="28px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H2 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h2"
      fontSize="24px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H3 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h3"
      fontSize="18px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H4 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h4"
      fontSize="16px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H5 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h5"
      fontSize="14px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const H6 = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="h6"
      fontSize="13px"
      fontWeight="500"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const Paragraph = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      mb={0}
      mt={0}
      component="p"
      fontSize="14px"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const Small = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      fontSize="12px"
      fontWeight="500"
      lineHeight="1.5"
      component="small"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const Span = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      component="span"
      lineHeight="1.5"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};

/**
 * @typedef {import("@mui/material").BoxProps} Other
 * @param {Other & {ellipsis: boolean}}
 * @returns {JSX.Element}
 */
export const Tiny = ({
  children,
  className,
  ellipsis,
  ...props
}: TypographyProps) => {
  return (
    <StyledBox
      fontSize="10px"
      lineHeight="1.5"
      component="small"
      ellipsis={!ellipsis}
      className={clsx({ [className || ""]: true })}
      {...props}
    >
      {children}
    </StyledBox>
  );
};
