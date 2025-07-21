import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import "@fontsource/rajdhani/300.css";
import "@fontsource/rajdhani/400.css";
import "@fontsource/rajdhani/500.css";
import "@fontsource/rajdhani/600.css";
import "@fontsource/rajdhani/700.css";
import React, { Suspense, useState } from "react";
// import { createBrowserRouter, Outlet, RouterProvider } from "react-router-dom";
// import { SidebarLayout } from "./components/sidebar-layout/SidebarLayout";
// import { routes } from "./constant/route";
import { getThemeByName } from "./components/theme/theme";
import { ThemeProvider } from "@emotion/react";
import { CssBaseline } from "@mui/material";
import { Analytics } from "@mui/icons-material";
import { ThemeConfigurator } from "./components/theme/ThemeConfigurator";
import { ColorModeContext } from "./context/ColorMode";
import { SidebarLayout } from "./components/sidebar-layout/SidebarLayout";
import CreateOrangForm from "./pages/orang/orang-create";

const Dashboard = React.lazy(() => import("./pages/dashboard/Dashboard"));
const JobList = React.lazy(() => import("./pages/jobs/jobs-list/JobsListPage"));
const JobCreate = React.lazy(
  () => import("./pages/jobs/jobs-create/JobsCreate")
);

// const router = createBrowserRouter([
//   {
//     path: "/",
//     element: (
//       <SidebarLayout>
//         <Suspense>
//           <Outlet />
//         </Suspense>
//       </SidebarLayout>
//     ),
//     children: [
//       {
//         path: routes.dashboard,
//         element: <Dashboard />,
//       },
//     ],
//   },
// ]);

// const AppRouter = () => {
//   const { data: user, isLoading } = useCurrentUser();

//   if (isLoading) {
//     return <Loader />;
//   }
//   if (!user) return null;
//   return (
//     <RouterProvider
//       router={router}
//       future={{
//         v7_startTransition: true,
//       }}
//     />
//   );
// };

function App() {
  const [mode, setMode] = React.useState<"light" | "dark">("light");
  const [themeName, setThemeName] = useState<
    "appTheme" | "shadTheme" | "cyberpunkTheme" | "ukrTheme"
  >("ukrTheme");
  const colorMode = React.useMemo(
    () => ({
      toggleColorMode: () => {
        setMode((prevMode) => (prevMode === "light" ? "dark" : "light"));
      },
    }),
    []
  );
  const theme = getThemeByName(themeName, mode);
  return (
    <SidebarLayout>
      <Suspense>
        <ColorModeContext.Provider value={colorMode}>
          <ThemeProvider theme={theme}>
            <CssBaseline />
            <Analytics />
            <>
              <JobList />
              <ThemeConfigurator
                setThemeName={setThemeName}
                themeName={themeName}
              />
            </>
          </ThemeProvider>
        </ColorModeContext.Provider>
      </Suspense>
    </SidebarLayout>
  );
}

export default App;
