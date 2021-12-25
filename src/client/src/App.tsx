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
      <h1 className="text-2xl font-medium text-black">{title}</h1>
      <p className="text-md font-medium text-gray-900">
        This is the students testing system
      </p>
      <button className="mt-4 text-white font-medium bg-green-300 rounded-md px-8 py-2 transition hover:bg-green-500 active:bg-green-700">
        Button
      </button>
    </div>
  );
};
