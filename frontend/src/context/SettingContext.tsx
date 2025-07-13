import { createContext, useState, type FC, type ReactNode } from "react";
import { merge } from "lodash";
import { MatxLayoutSettings } from "../components/Layout/setting";
// CUSTOM COMPONENT

// Define the shape of a single theme's palette
interface PaletteConfig {
  type?: "light" | "dark";
  primary?: {
    main: string;
    contrastText: string;
  };
  secondary?: {
    main: string;
    contrastText: string;
  };
  background?: {
    paper: string;
    default: string;
  };
  error?: {
    main: string;
  };
  text?: {
    primary: string;
    secondary?: string;
    disabled?: string;
    hint?: string;
  };
}

// Define the shape of a single theme configuration
interface ThemeConfig {
  [key: string]: {
    palette: PaletteConfig;
  };
}

// Define the shape of layout1Settings
interface Layout1Settings {
  topbar: {
    show: boolean;
    fixed: boolean;
    theme: string;
  };
  leftSidebar: {
    show: boolean;
    mode: "full" | "compact" | "close";
    theme: string;
    bgImgURL: string; // Added to match MatxLayoutSettings
  };
}

// Define the shape of secondarySidebar
interface SecondarySidebarSettings {
  show: boolean;
  open: boolean;
  theme: string;
}

// Define the shape of footer
interface FooterSettings {
  show: boolean;
  fixed: boolean;
  theme: string;
}

// Define the full settings structure
interface Settings {
  activeLayout: string;
  activeTheme: string;
  perfectScrollbar: boolean;
  themes: ThemeConfig;
  layout1Settings: Layout1Settings;
  secondarySidebar: SecondarySidebarSettings;
  footer: FooterSettings;
}

// Define the context value shape
interface SettingsContextValue {
  settings: Settings;
  updateSettings: (update: Partial<Settings>) => void;
}

// Create the context with typed value
const SettingsContext = createContext<SettingsContextValue>({
  settings: MatxLayoutSettings as Settings, // Type cast to ensure compatibility
  updateSettings: () => {},
});

// Props for the SettingsProvider component
interface SettingsProviderProps {
  children: ReactNode;
  settings?: Settings;
}

// SettingsProvider component
export const SettingsProvider: FC<SettingsProviderProps> = ({
  settings,
  children,
}) => {
  const [currentSettings, setCurrentSettings] = useState<Settings>(
    settings || (MatxLayoutSettings as Settings)
  );

  const handleUpdateSettings = (update: Partial<Settings> = {}) => {
    const merged = merge({}, currentSettings, update) as Settings;
    setCurrentSettings(merged);
  };

  return (
    <SettingsContext.Provider
      value={{
        settings: currentSettings,
        updateSettings: handleUpdateSettings,
      }}
    >
      {children}
    </SettingsContext.Provider>
  );
};

export default SettingsContext;
