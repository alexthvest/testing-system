import React, { useEffect, useState } from "react";

export const App: React.FC = () => {
  const [title, setTitle] = useState("Failed to fetch title");

  useEffect(() => {
    fetch("/api/hello")
      .then((r) => r.text())
      .then(setTitle);
  }, []);

  return (
    <div className="container mx-auto my-16">
      <h1 className="text-2xl font-medium text-fuchsia-700 ">{title}</h1>
      <p className="text-md font-medium text-gray-400">
        This is the students testing system
      </p>
    </div>
  );
};
