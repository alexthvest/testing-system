import React, { ButtonHTMLAttributes } from "react";
import "./Button.css";

export type ButtonProps = ButtonHTMLAttributes<HTMLButtonElement> & {
  readonly variant?: "primary" | "secondary";
};

export const Button: React.FC<ButtonProps> = ({
  variant,
  children,
  ...props
}) => {
  return (
    <button {...props} className={`ml-auto button-${variant ?? "primary"}`}>
      {children}
    </button>
  );
};
