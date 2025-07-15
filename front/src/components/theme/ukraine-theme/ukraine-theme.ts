import { alpha, createTheme } from "@mui/material";
import { amber, blue, blueGrey, grey, yellow } from "@mui/material/colors";
import { ukraineshad } from "./shadows";

const background = "#1a1c1f"; // Slightly adjusted for yellow-blue theme
const bodyBackground = "#121416"; // Darker tone to complement yellow

export const ukrTheme = (mode: "light" | "dark") => {
  const isDarkMode = mode === "dark";

  return createTheme({
    palette: {
      mode,
      primary: {
        main: yellow[700], // Bright yellow as primary
        light: isDarkMode ? yellow[500] : alpha(yellow[100], 0.3),
      },
      secondary: {
        main: blue[500], // Vibrant blue as secondary
      },
      success: {
        main: yellow[800], // Deeper yellow for success
      },
      error: {
        main: amber[900], // Darker amber for error
      },
      info: {
        main: blue[300], // Lighter blue for info
      },
      warning: {
        main: amber[700], // Amber for warning
      },
      divider: isDarkMode ? blueGrey[700] : blueGrey[200],
      background: {
        default: isDarkMode ? background : grey[100],
        paper: isDarkMode ? background : grey[100],
      },
    },
    shape: {
      borderRadius: 8,
    },
    spacing: 8,
    typography: {
      fontFamily: [
        "Noto Sans",
        '"Source Sans Pro"',
        "-apple-system",
        "BlinkMacSystemFont",
        "Roboto",
        '"Helvetica Neue"',
        "Arial",
        "sans-serif",
        '"Apple Color Emoji"',
        '"Segoe UI Emoji"',
        '"Segoe UI Symbol"',
      ].join(","),
      fontWeightMedium: 600,
      fontWeightBold: 700,
      h1: {
        fontSize: "5rem",
        fontWeight: 600,
      },
      h2: {
        fontSize: "3.75rem",
        fontWeight: 600,
      },
      h3: {
        fontSize: "3rem",
        fontWeight: 600,
      },
      h4: {
        fontSize: "2.125rem",
        fontWeight: 600,
      },
      h5: {
        fontSize: "1.5rem",
        fontWeight: 600,
      },
      h6: {
        fontSize: "1.25rem",
        fontWeight: 600,
      },
    },
    shadows: ukraineshad,
    components: {
      MuiCssBaseline: {
        styleOverrides: {
          ":root": {
            colorScheme: isDarkMode ? "dark" : "light",
          },
          html: {
            minHeight: "100%",
          },
          body: {
            minHeight: "100%",
            backgroundColor: isDarkMode ? bodyBackground : blueGrey[100], // Adjusted for yellow-blue theme
            backgroundRepeat: "no-repeat",
            backgroundPosition: "top right",
            backgroundSize: "100%",
          },
        },
      },
      MuiListItemButton: {
        defaultProps: {
          disableRipple: true,
        },
      },
      MuiButton: {
        defaultProps: {
          disableRipple: true,
        },
        styleOverrides: {
          root: {
            textTransform: "none",
            boxShadow: "none",
          },
          contained: {
            // Optional: Uncomment for subtle yellow-blue shadow
            // boxShadow: '2px 5px 10px 2px rgba(255, 235, 59, 0.2)',
          },
          sizeSmall: {
            padding: "2px 12px",
          },
          sizeMedium: {
            padding: "6px 18px",
          },
          sizeLarge: {
            padding: "10px 24px",
          },
        },
      },
      MuiAppBar: {
        styleOverrides: {
          root: {
            boxShadow: "none",
          },
        },
      },
      MuiDrawer: {
        styleOverrides: {
          paper: {
            borderRight: "0",
            backgroundColor: isDarkMode ? background : grey[100],
          },
        },
      },
      MuiCard: {
        styleOverrides: {
          root: {
            backgroundImage: "none",
          },
        },
      },
      MuiPaper: {
        styleOverrides: {
          root: {
            backgroundImage: "none",
          },
        },
      },
    },
  });
};
