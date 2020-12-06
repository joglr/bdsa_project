import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  useTheme,
} from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useStudents } from "./api";
import { ContentY } from "./components/util";
import { ACTION_TYPE, useStore } from "./store";

export default function Students(_: RouteComponentProps) {
  const [state, dispatch] = useStore();
  const students = useStudents();
  const theme = useTheme();
  return (
    <ContentY
      style={{
        padding: theme.spacing(),
      }}
    >
      <FormControl>
        <InputLabel>Who are you?</InputLabel>
        <Select
          onChange={(event) =>
            dispatch({
              type: ACTION_TYPE.CHANGE_USER,
              user: students.find((e) => e.id === event.target.value) ?? null,
            })
          }
          label=""
          value={state.user !== null ? state.user.id : ""}
        >
          {students.map((student) => (
            <MenuItem key={student.id} value={student.id}>
              {student.firstName} {student.lastName}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </ContentY>
  );
}
