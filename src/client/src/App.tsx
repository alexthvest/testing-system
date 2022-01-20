import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import { LoginPage } from "./features/login/pages/LoginPage";
import { DisciplinePage } from "./features/discipline/pages/DisciplinePage";
import { ProtectedOutlet } from "./core/components/ProtectedOutlet";

export const App: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/" element={<ProtectedOutlet />}>
          <Route path="" element={<DisciplinePage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};
