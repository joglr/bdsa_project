import React from "react";
import "./App.css";
import { Grow, useTheme } from "@material-ui/core";
import { Router } from "@reach/router";
import Placements from "./Placements";
import Navigation from "./Navigation";

import styled from "styled-components";
import Landing from "./Landing";
import { USER_TYPE, useStore } from "./store";
import Settings from "./Settings";
import { usePlacements } from "./api";

const Root = styled.div`
  height: 100vh;
  display: grid;
  grid-template-rows: 1fr ${(props) => props.theme.spacing(7)}px;
`;

const Main = styled.main`
  overflow-y: auto;
`;

function App() {
  const [{ user, userType }] = useStore();
  const theme = useTheme();
  const placements = usePlacements();
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
                <Placements
                  default={userType === USER_TYPE.STUDENT}
                  path="/placements"
                  browse
                  placements={placements}
                />
                <Placements
                  default={userType === USER_TYPE.EMPLOYER}
                  path="/my-placements"
                  browse={false}
                  placements={user.placements}
                />
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
