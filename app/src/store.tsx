import React, { createContext, useContext, useReducer, Dispatch } from "react";

export type STATE =
  | { status: STATUS.IDLE }
  | { status: STATUS.PENDING }
  | { status: STATUS.SUCCESS; response: any }
  | { status: STATUS.FAILURE; error: string };

export enum STATUS {
  IDLE = "IDLE",
  SUCCESS = "SUCCESS",
  PENDING = "PENDING",
  FAILURE = "FAILURE",
}

export enum ACTION_TYPE {
  SUBMIT = "SUBMIT",
  CANCEL = "CANCEL",
  SUCCEED = "SUCCEED",
  FAIL = "FAIL",
}

type Reducer<S, A> = (prevState: S, action: A) => S;

type Action =
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

  const contextValue: [STATE, Dispatch<Action>] = [state, dispatch];

  return (
    <StoreContext.Provider value={contextValue}>
      {children}
    </StoreContext.Provider>
  );
}

function getDefaultState(): STATE {
  return {
    status: STATUS.IDLE,
  };
}

function reducer(prevState: STATE | null, action: Action | null): STATE {
  if (prevState === null || action === null) return getDefaultState();
  switch (action.type) {
    case ACTION_TYPE.SUBMIT:
      return { status: STATUS.PENDING };
    case ACTION_TYPE.CANCEL:
      return { status: STATUS.IDLE };
    case ACTION_TYPE.SUCCEED:
      return { status: STATUS.SUCCESS, response: action.response };
    case ACTION_TYPE.FAIL:
      return { status: STATUS.FAILURE, error: action.error };
    default:
      throw new Error("Unknown action type: " + action);
  }
}

export function useStore() {
  return useContext(StoreContext);
}
