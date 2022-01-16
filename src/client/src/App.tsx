import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import { LoginPage } from "./features/login/pages/LoginPage";

export const App: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
};
