import { lazy } from "react";
import Loadable from "./components/Loadable";
import LayoutEksperimen from "./layout"; // Import LayoutEksperimen directly

// Lazy-load AppForm
const AppForm = Loadable(lazy(() => import("./views/forms/AppForm")));

export default function Tampilkan() {
  return (
    <LayoutEksperimen>
      <AppForm />
    </LayoutEksperimen>
  );
}
