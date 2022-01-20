import { Failure } from "./failure";

export interface OperationResult<T> {
  readonly success: boolean;
  readonly data?: T;
  readonly failure?: Failure;
}
