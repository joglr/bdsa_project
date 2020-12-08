import React, {
  createContext,
  useContext,
  useReducer,
  Dispatch,
  useEffect,
} from "react";
import { Employer } from "./entities/Employer";
import { Student } from "./entities/Student";

export enum USER_TYPE {
  STUDENT,
  EMPLOYER,
}

export type STATE = {
  user: Student | Employer | null;
  userType: USER_TYPE | null;
} & (
  | { status: STATUS.IDLE }
  | { status: STATUS.PENDING }
  | { status: STATUS.SUCCESS; response: any }
  | { status: STATUS.FAILURE; error: string }
);

export enum STATUS {
  IDLE = "IDLE",
  SUCCESS = "SUCCESS",
  PENDING = "PENDING",
  FAILURE = "FAILURE",
}

export enum ACTION_TYPE {
  SUBMIT = "SUBMIT",
  CHANGE_USER = "CHANGE_USER",
  CHANGE_USER_TYPE = "CHANGE_USER_TYPE",
  CANCEL = "CANCEL",
  SUCCEED = "SUCCEED",
  FAIL = "FAIL",
}

function getDefaultState(): STATE {
  if (localStorage.getItem("state"))
    return JSON.parse(localStorage.getItem("state") ?? "{}");
  return {
    status: STATUS.IDLE,
    user: null,
    userType: null,
  };
}

type Reducer<S, A> = (prevState: S, action: A) => S;

type Action =
  | {
      type: ACTION_TYPE.CHANGE_USER;
      user: Student | Employer | null;
      userType: USER_TYPE | null;
    }
  | { type: ACTION_TYPE.SUBMIT; value: string }
  | { type: ACTION_TYPE.CANCEL }
  | { type: ACTION_TYPE.SUCCEED; response: any }
  | { type: ACTION_TYPE.FAIL; error: string };

const StoreContext = createContext<[STATE, Dispatch<Action>]>([
  getDefaultState(),
  (_action: Action) => {
    throw new Error(
      "No context provider, did you forget to wrap your tree in <StoreProvider /> ?"
    );
  },
]);

export function StoreProvider({ children }: any) {
  const [state, dispatch] = useReducer<Reducer<STATE, Action>>(
    reducer,
    getDefaultState()
  );
  const stringifiedState = JSON.stringify(state);

  useEffect(() => {
    localStorage.setItem("store", stringifiedState);
  }, [stringifiedState]);

  const contextValue: [STATE, Dispatch<Action>] = [state, dispatch];

  return (
    <StoreContext.Provider value={contextValue}>
      {children}
    </StoreContext.Provider>
  );
}

function reducer(prevState: STATE | null, action: Action | null): STATE {
  if (prevState === null || action === null) return getDefaultState();
  switch (action.type) {
    case ACTION_TYPE.CHANGE_USER:
      return { ...prevState, user: action.user, userType: action.userType };
    case ACTION_TYPE.SUBMIT:
      return { ...prevState, status: STATUS.PENDING };
    case ACTION_TYPE.CANCEL:
      return { ...prevState, status: STATUS.IDLE };
    case ACTION_TYPE.SUCCEED:
      return {
        ...prevState,
        status: STATUS.SUCCESS,
        response: action.response,
      };
    case ACTION_TYPE.FAIL:
      return { ...prevState, status: STATUS.FAILURE, error: action.error };
    default:
      throw new Error("Unknown action type: " + JSON.stringify(action));
  }
}

export function useStore() {
  return useContext(StoreContext);
}
