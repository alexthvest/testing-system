import React, { DetailedHTMLProps, InputHTMLAttributes } from "react";
import { TablerIcon } from "@tabler/icons";

export type InputFieldProps = DetailedHTMLProps<
  InputHTMLAttributes<HTMLInputElement>,
  HTMLInputElement
> & {
  readonly icon?: TablerIcon;
};

export const InputField: React.FC<InputFieldProps> = ({ icon, ...props }) => {
  return (
    <div className="group flex px-4 py-3 space-x-4 bg-gray-300 rounded-md">
      {icon &&
        React.createElement(icon, {
          className:
            "text-md text-gray-700 font-medium group-focus-within:text-gray-900 transition",
        })}
      <input
        className="w-full bg-transparent text-md text-gray-900 font-medium placeholder:text-gray-700 outline-none"
        {...props}
      />
    </div>
  );
};
