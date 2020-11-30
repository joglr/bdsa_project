import React from "react";
import "./App.css";
import { Button, Grid, LinearProgress } from "@material-ui/core";
import { ACTION_TYPE, Status, useStore } from "./store";

function App() {
  const [state] = useStore();
  return (
    <Grid
      style={{
        height: "100vh",
      }}
      container
      direction="column"
      justify="space-evenly"
      alignItems="center"
      alignContent="center"
    >
      <SubmitButton />
      <span>State: {state.status}</span>
      <br />
      {state.status === Status.PENDING ? (
        <LinearProgress
          style={{
            width: 100,
          }}
        />
      ) : state.status === Status.SUCCESS ? (
        "Result: " + JSON.stringify(state.response)
      ) : (
        <div />
      )}
    </Grid>
  );
}

interface SubmitButtonProps {}

function SubmitButton(props: SubmitButtonProps) {
  const [state, dispatch] = useStore();

  async function submit() {
    dispatch({
      type: ACTION_TYPE.SUBMIT,
      value: "hej",
    });

    await sleep(2000);
    const response = await fetch("api.json");

    if (response.ok && response.status >= 200 && response.status < 300) {
      try {
        dispatch({
          type: ACTION_TYPE.SUCCEED,
          response: await response.json(),
        });
      } catch (e) {
        dispatch({
          type: ACTION_TYPE.FAIL,
          error: e.message,
        });
      }
    } else {
      dispatch({
        type: ACTION_TYPE.FAIL,
        error: response.statusText,
      });
    }
  }

  return (
    <Grid item>
      <Button
        onClick={submit}
        color="secondary"
        disabled={state.status === Status.PENDING}
        variant="text"
      >
        Submit
      </Button>
    </Grid>
  );
}

function sleep(amount: number) {
  return new Promise((resolve) => setTimeout(resolve, amount));
}

export default App;
