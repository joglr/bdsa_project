import React, { createContext, useContext, useReducer } from "react";

export type State =
  | { status: Status.IDLE }
  | { status: Status.PENDING }
  | { status: Status.SUCCESS; response: any }
  | { status: Status.FAILURE; error: string };

export enum Status {
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

const StoreContext = createContext([null]);

export function StoreProvider({ children }) {
  const [state, dispatch] = useReducer<Reducer<State, Action>>(
    reducer,
    getDefaultState()
  );

  return (
    <StoreContext.Provider value={[state, dispatch]}>
      {children}
    </StoreContext.Provider>
  );
}

function getDefaultState(): State {
  return {
    status: Status.IDLE,
  };
}

function reducer(prevState: State = null, action: Action = null): State {
  switch (action.type) {
    case ACTION_TYPE.SUBMIT:
      return { status: Status.PENDING };
    case ACTION_TYPE.CANCEL:
      return { status: Status.IDLE };
    case ACTION_TYPE.SUCCEED:
      return { status: Status.SUCCESS, response: action.response };
    case ACTION_TYPE.FAIL:
      return { status: Status.FAILURE, error: action.error };
    default:
      throw new Error("Unknown action type: " + action);
  }
}

export function useStore() {
  return useContext(StoreContext);
}
