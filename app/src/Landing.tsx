import React, { useState } from "react";
import { Button, Grow, Typography, useTheme } from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import { ContentY } from "./components/util";

import { useEmployers, useStudents } from "./api";
import { ACTION_TYPE, USER_TYPE, useStore } from "./store";
import styled from "styled-components";
import User from "./entities/User";

const AbsoluteChildren = styled.div``;

export default function Landing(_: RouteComponentProps) {
  const [, dispatch] = useStore();
  const [userType, setUserType] = useState<USER_TYPE | null>(null);
  const employers = useEmployers();
  const students = useStudents();
  const theme = useTheme();

  const users: User[] =
    userType === null
      ? []
      : userType === USER_TYPE.STUDENT
      ? students.map<User>((s) => ({
          id: s.id,
          name: `${s.firstName} ${s.lastName}`,
          person: s,
          userType: USER_TYPE.STUDENT,
        }))
      : employers.map<User>((e) => ({
          id: e.id,
          name: e.companyName,
          person: e,
          userType: USER_TYPE.EMPLOYER,
        }));

  return (
    <ContentY
      style={{
        height: "100%",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Typography variant="h2">Welcome!</Typography>
      <AbsoluteChildren>
        <Grow in={userType === null}>
          <div>
            <p>Are you a student or employer?</p>
            <div
              style={{
                display: "flex",
                flexDirection: "row",
                justifyContent: "center",
              }}
            >
              <Button
                color="inherit"
                onClick={() => setUserType(USER_TYPE.STUDENT)}
              >
                Student
              </Button>
              <Button
                color="inherit"
                onClick={() => setUserType(USER_TYPE.EMPLOYER)}
              >
                Employer
              </Button>
            </div>
          </div>
        </Grow>
        <Grow in={userType !== null} mountOnEnter unmountOnExit>
          <div>
            <Typography
              variant="subtitle2"
              style={{
                textAlign: "center",
              }}
            >
              Who are you?
            </Typography>
            <div
              style={{
                display: "grid",
                gridTemplateColumns: "1fr 1fr",
                alignItems: "center",
                flexWrap: "wrap",
              }}
            >
              {users.map((user: User) => (
                <Button
                  key={user.id}
                  variant="outlined"
                  color="inherit"
                  style={{
                    margin: theme.spacing(),
                  }}
                  onClick={() =>
                    dispatch({
                      type: ACTION_TYPE.CHANGE_USER,
                      user: user.person,
                      userType: userType,
                    })
                  }
                >
                  {user.name}
                </Button>
              ))}
            </div>
          </div>
        </Grow>
      </AbsoluteChildren>
    </ContentY>
  );
}
