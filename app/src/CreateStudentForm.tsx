import React from "react";
import { Button, Grid, TextField } from "@material-ui/core";
import { ACTION_TYPE, STATUS, useStore } from "./store";
import { useInput } from "./util";

export function CreateStudentForm() {
  const [state, dispatch] = useStore();
  const inputProps = useInput();

  async function submit() {
    dispatch({
      type: ACTION_TYPE.SUBMIT,
      value: "hej",
    });

    try {
      // const employer = [API_ROOT, "employer"].join("/");

      const response = await fetch("https://localhost:5001/student", {
        headers: {
          // accept: "*/*",
          "content-type": "application/json",
          // "sec-fetch-dest": "empty",
          // "sec-fetch-mode": "cors",
        },
        referrer: "https://localhost:5001/index.html",
        // referrerPolicy: "strict-origin-when-cross-origin",
        body: JSON.stringify({
          firstName: inputProps.value,
          lastName: "Marley",
          capabilities: [],
        }),
        method: "POST",
        // credentials: "include",
      });

      // fetch(employer, {
      //   // method: "post",
      // });

      if (response.ok && response.status >= 200 && response.status < 300) {
        dispatch({
          type: ACTION_TYPE.SUCCEED,
          response: await response.text(),
        });
      } else {
        dispatch({
          type: ACTION_TYPE.FAIL,
          error: response.statusText,
        });
      }
    } catch (e) {
      dispatch({
        type: ACTION_TYPE.FAIL,
        error: e.message,
      });
    }
  }

  return (
    <Grid item>
      <TextField {...inputProps} />
      <Button
        onClick={submit}
        color="secondary"
        disabled={state.status === STATUS.PENDING}
        variant="text"
      >
        Submit
      </Button>
    </Grid>
  );
}
