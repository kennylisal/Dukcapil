import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
// import KTPCreate from "./ktp/create/index.tsx";
import KTPSearch from "./ktp/search/index.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <KTPSearch />
  </StrictMode>
);
