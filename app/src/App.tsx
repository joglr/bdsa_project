import React from "react";
import "./App.css";
import { useTheme } from "@material-ui/core";
import { Router } from "@reach/router";
import Employers from "./Employers";
import Students from "./Students";
import Placements from "./Placements";
import Capabilities from "./Capatabilities";
import Navigation from "./Navigation";

import styled from "styled-components";

const Root = styled.div`
  height: 100vh;
  display: grid;
  grid-template-rows: 1fr ${(props) => props.theme.spacing(7)}px;
`;

const Main = styled.main`
  overflow-y: auto;
`;

function App() {
  // const [state] = useStore();
  const theme = useTheme();
  return (
    <Root theme={theme}>
      <Main>
        <Router>
          <Placements default path="/placements" />
          <Students path="/students" />
          <Employers path="/employers" />
          <Capabilities path="/capabilities" />
        </Router>
      </Main>
      <Navigation />
    </Root>
  );
}

export default App;
