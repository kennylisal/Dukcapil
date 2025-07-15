import {
  type ComponentsOverrides,
  type ComponentsPropsList,
  type Theme,
} from "@mui/material";
import { appTheme } from "./app-theme/appTheme.ts";
import { shadTheme } from "./shad-theme/shadTheme.ts";
import { cyberpunkTheme } from "./cyberpunk-theme/cyberpunkTheme.ts";

type FoxTheme = Omit<Theme, "components">;

declare module "@mui/material/styles" {
  interface ComponentNameToClassKey {
    FoxUiLogo: "text" | "imgContainer" | "img";
    FoxUiNavigationItem: "button";
  }

  interface Components {
    FoxUiLogo?: {
      styleOverrides?: ComponentsOverrides<FoxTheme>["FoxUiLogo"];
    };
    FoxUiNavigationItem?: {
      defaultProps?: ComponentsPropsList["MuiListItemButton"];
      styleOverrides?: ComponentsOverrides<FoxTheme>["FoxUiNavigationItem"];
      variants?: "active" | "nested";
    };
  }
}

const themeMap: { [key: string]: (mode: "light" | "dark") => FoxTheme } = {
  appTheme,
  shadTheme,
  cyberpunkTheme,
};

export const getThemeByName = (theme: string, mode: "light" | "dark") => {
  return themeMap[theme](mode);
};
