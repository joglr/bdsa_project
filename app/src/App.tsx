import React from "react";
import "./App.css";
import { Grow, useTheme } from "@material-ui/core";
import { Router } from "@reach/router";
import Placements from "./Placements";
import Navigation from "./Navigation";

import styled from "styled-components";
import Landing from "./Landing";
import { useStore } from "./store";
import Settings from "./Settings";

const Root = styled.div`
  height: 100vh;
  display: grid;
  grid-template-rows: 1fr ${(props) => props.theme.spacing(7)}px;
`;

const Main = styled.main`
  overflow-y: auto;
`;

function App() {
  const [{ user }] = useStore();
  const theme = useTheme();
  return (
    <>
      {user === null ? (
        <div
          style={{
            height: "100vh",
            backgroundColor: theme.palette.primary.main,
            color: theme.palette.primary.contrastText,
          }}
        >
          <Landing />
        </div>
      ) : (
        <>
          <Root theme={theme}>
            <Main>
              <Router
                style={{
                  height: "100%",
                }}
              >
                <Placements default path="/" />
                <Settings path="/settings" />
              </Router>
            </Main>
            <Grow in={user !== null} mountOnEnter unmountOnExit>
              <Navigation />
            </Grow>
          </Root>
        </>
      )}
    </>
  );
}

export default App;
