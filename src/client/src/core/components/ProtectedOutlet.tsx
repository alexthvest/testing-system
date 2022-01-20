import { Navigate, Outlet } from "react-router-dom";

export const ProtectedOutlet: React.FC = () => {
  const accessToken = localStorage.getItem("accessToken");
  return accessToken ? <Outlet /> : <Navigate to="/login" />;
};
