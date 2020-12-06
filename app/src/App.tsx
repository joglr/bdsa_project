import React from "react";
import "./App.css";
import { Grow, useTheme } from "@material-ui/core";
import { Router } from "@reach/router";
import Employers from "./Employers";
import Students from "./Students";
import Placements from "./Placements";
import Capabilities from "./Capatabilities";
import Navigation from "./Navigation";

import styled from "styled-components";
import Landing from "./Landing";
import { useStore } from "./store";

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
    <Root theme={theme}>
      <Main>
        <Router>
          {user !== null ? (
            <Placements default path="/" />
          ) : (
            <Landing default path="/" />
          )}
        </Router>
      </Main>
      <Grow in={user !== null} mountOnEnter unmountOnExit>
        <Navigation />
      </Grow>
    </Root>
  );
}

export default App;
