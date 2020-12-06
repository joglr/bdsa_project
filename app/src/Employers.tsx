import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  useTheme,
} from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useEmployers } from "./api";
import { ContentY } from "./components/util";
import { Employer } from "./entities/Employer";
import { ACTION_TYPE, useStore } from "./store";

export default function Employers(props: RouteComponentProps) {
  const [state, dispatch] = useStore();
  const employers = useEmployers();
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
              user: employers.find((e) => e.id === event.target.value) ?? null,
            })
          }
          label=""
          value={state.user !== null ? state.user.id : ""}
        >
          {employers.map((employer: Employer) => (
            <MenuItem key={employer.id} value={employer.id}>
              {employer.companyName}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </ContentY>
  );
}
