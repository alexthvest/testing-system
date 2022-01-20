import { User } from "../models/user.model";

export const fetchUser = async (): Promise<User | null> => {
  const accessToken = localStorage.getItem("accessToken");

  const response = await fetch("/api/user", {
    method: "GET",
    headers: {
      Authorization: `Bearer ${accessToken}`,
    },
  });

  if (!response.ok) {
    return null;
  }

  const { data } = await response.json();
  return data;
};
