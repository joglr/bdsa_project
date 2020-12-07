/* eslint-disable react-hooks/rules-of-hooks */
import React from "react";
import "./App.css";
import { AppBar, Grow, Toolbar, Typography, useTheme } from "@material-ui/core";
import { Router } from "@reach/router";
import Placements from "./Placements";
import Navigation from "./Navigation";

import styled from "styled-components";
import Landing from "./Landing";
import { USER_TYPE, useStore } from "./store";
import Settings from "./Settings";
import { useEmployer, usePlacements, useStudent } from "./api";
import { ContentX } from "./components/util";
import { Employer } from "./entities/Employer";
import { Student } from "./entities/Student";
import PlacementDetails from "./Placement";

const Root = styled.div`
  height: 100vh;
  display: grid;
  grid-template-rows: ${(props) => props.theme.spacing(7)}px 1fr ${(props) =>
      props.theme.spacing(7)}px;
`;

const Main = styled.main`
  overflow-y: auto;
`;

function App() {
  const [{ user, userType }] = useStore();
  const theme = useTheme();
  const placements = usePlacements();
  const studentPlacements = useStudent(user?.id ?? null)?.placements ?? [];
  const employerPlacements = useEmployer(user?.id ?? null)?.placements ?? [];

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
            <AppBar position="relative">
              <ContentX>
                <Toolbar>
                  <Typography variant="h6">
                    Hello,{" "}
                    {userType === USER_TYPE.EMPLOYER
                      ? (user as Employer).companyName
                      : `${(user as Student).firstName} ${
                          (user as Student).lastName
                        }`}
                  </Typography>
                </Toolbar>
              </ContentX>
            </AppBar>
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
                <PlacementDetails path="/placements/:placementID" />
                <Placements
                  default={userType === USER_TYPE.EMPLOYER}
                  path="/my-placements"
                  browse={false}
                  placements={
                    userType === USER_TYPE.EMPLOYER
                      ? employerPlacements
                      : userType === USER_TYPE.STUDENT
                      ? studentPlacements
                      : []
                  }
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
