import React from "react";
import { LinearProgress } from "@material-ui/core";
import { STATUS, useStore } from "./store";

export default function Status() {
  const [state] = useStore();

  switch (state.status) {
    case STATUS.PENDING:
      return (
        <LinearProgress
          style={{
            width: 100,
          }}
        />
      );
    case STATUS.SUCCESS:
      return <span>Result: {JSON.stringify(state.response)}</span>;
    case STATUS.FAILURE:
      return <span>Result: {JSON.stringify(state.error)}</span>;
    default:
      return <div />;
  }
}
