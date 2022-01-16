import React, { useEffect, useState } from "react";
import { IconUser, IconLock } from "@tabler/icons";

import { Button } from "./core/components/Button/Button";
import { InputField } from "./core/components/InputField";

export const App: React.FC = () => {
  const [title, setTitle] = useState("Failed to fetch title");

  useEffect(() => {
    fetch("/api/hello")
      .then((r) => r.text())
      .then(setTitle);
  }, []);

  return (
    <div className="container mx-auto my-16 space-y-4">
      <h1 className="text-2xl font-medium text-black">{title}</h1>
      <p className="text-md font-medium text-gray-900">
        This is the students testing system
      </p>
      <InputField type="text" icon={IconUser} placeholder="Имя пользователя" />
      <InputField type="password" icon={IconLock} placeholder="Пароль" />
      <Button variant="primary">Войти в систему</Button>
    </div>
  );
};
