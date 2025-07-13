import { createTheme, type Theme, type ThemeOptions } from "@mui/material";
import { forEach, merge } from "lodash";
import { themeColors } from "./themeColors";
import themeOptions from "./themeOption";

// Define the shape of the themes object
interface Themes {
  [key: string]: Theme;
}

// Create themes
function createMatxThemes(): Themes {
  const themes: Themes = {};

  forEach(themeColors, (value, key) => {
    // Ensure the merged object is typed as ThemeOptions
    const mergedOptions = merge({}, themeOptions, value) as ThemeOptions;
    themes[key] = createTheme(mergedOptions);
  });

  return themes;
}

export const themes: Themes = createMatxThemes();
