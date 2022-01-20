import { OperationResult } from "../../../core/common/operationResult";
import { AuthorizationResponse } from "../responses/authorization.response";

export type AuthorizationResult = OperationResult<AuthorizationResponse>;

export const authorize = async (
  username: string,
  password: string
): Promise<AuthorizationResult> => {
  const response = await fetch("/api/user/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      username,
      password,
    }),
  });

  return response.json();
};
