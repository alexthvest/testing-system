import React from "react";
import { IconLock, IconUser } from "@tabler/icons";

import { Button } from "../../../core/components/Button/Button";
import { InputField } from "../../../core/components/InputField";

import background from "../../../assets/images/background.jpg";

export const LoginPage: React.FC = () => {
  return (
    <div className="flex w-full h-screen justify-center">
      <div className="flex flex-col lg:w-3/6 lg:px-56 justify-center space-y-10 bg-white px-0 w-full">
        <div className="flex flex-col justify-center items-start w-full">
          <h1 className="text-2xl text-black font-medium">Авторизация</h1>
          <p className="text-md text-gray-900 font-medium">
            Введите ваши данные для входа в систему
          </p>
        </div>
        <div className="flex flex-col justify-center space-y-4">
          <InputField
            type="text"
            icon={IconUser}
            placeholder="Имя пользователя"
          />
          <InputField type="password" icon={IconLock} placeholder="Пароль" />
          <Button variant="primary">Войти в систему</Button>
        </div>
        <div className="flex justify-end"></div>
      </div>
      <img
        className="w-4/6 [clip-path:circle(105%_at_100%_50%)] invisible lg:visible"
        src={background}
      />
    </div>
  );
};
