import React, { FormEvent, useState } from "react";
import { IconLock, IconUser } from "@tabler/icons";

import { Button } from "../../../core/components/Button/Button";
import { InputField } from "../../../core/components/InputField";

import { authorize } from "../api/authorize.api";

import background from "../../../assets/images/background.jpg";
import { useNavigate } from "react-router";

export const LoginPage: React.FC = () => {
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const onAuthorize = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    setError("");

    const { data, failure } = await authorize(username, password);

    setUsername("");
    setPassword("");

    if (data?.accessToken) {
      localStorage.setItem("accessToken", data.accessToken);
      navigate("/");
      return;
    }

    setError(failure?.message ?? "Something went wrong");
  };

  return (
    <div className="flex w-full h-screen justify-center">
      <div className="flex flex-col lg:w-3/6 lg:px-56 justify-center space-y-10 bg-white px-0 w-full">
        <div className="flex flex-col justify-center items-start w-full">
          <h1 className="text-2xl text-black font-medium">Авторизация</h1>
          <p className="text-md text-gray-900 font-medium">
            Введите ваши данные для входа в систему
          </p>
        </div>
        <form
          className="flex flex-col justify-center space-y-4"
          onSubmit={onAuthorize}
        >
          <InputField
            type="text"
            icon={IconUser}
            placeholder="Имя пользователя"
            value={username}
            name="username"
            onChange={(e) => setUsername(e.target.value)}
          />
          <InputField
            type="password"
            icon={IconLock}
            placeholder="Пароль"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          {error && (
            <p className="ml-auto text-sm text-red-300 font-medium">
              Error: {error}
            </p>
          )}
          <Button variant="primary" type="submit">
            Войти в систему
          </Button>
        </form>
      </div>
      <img
        className="w-4/6 [clip-path:circle(105%_at_100%_50%)] invisible lg:visible"
        src={background}
      />
    </div>
  );
};
