import { Button, useTheme } from "@material-ui/core";
import { RouteComponentProps, useNavigate } from "@reach/router";
import React from "react";
import { Content } from "./components/util";
import { ACTION_TYPE, useStore } from "./store";

export default function Settings(_: RouteComponentProps) {
  const [, dispatch] = useStore();
  const navigate = useNavigate();
  const theme = useTheme();
  return (
    <Content
      style={{
        padding: theme.spacing(),
      }}
    >
      <Button
        onClick={async () => {
          localStorage.clear();
          await navigate("/");
          dispatch({
            type: ACTION_TYPE.CHANGE_USER,
            user: null,
            userType: null,
          });
        }}
      >
        Sign out
      </Button>
    </Content>
  );
}
