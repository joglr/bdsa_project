import { Button } from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React, { useState } from "react";
import { Content } from "./components/util";
import Employers from "./Employers";
import Students from "./Students";

export default function Landing(_: RouteComponentProps) {
  enum USER_TYPE {
    STUDENT,
    EMPLOYER,
  }

  const [userType, setUserType] = useState<USER_TYPE | null>(null);
  switch (userType) {
    case null:
      return (
        <Content
          style={{
            textAlign: "center",
          }}
        >
          <p>Are you a student or employer?</p>
          <Button onClick={() => setUserType(USER_TYPE.STUDENT)}>
            Student
          </Button>
          <Button onClick={() => setUserType(USER_TYPE.EMPLOYER)}>
            Employer
          </Button>
        </Content>
      );
    case USER_TYPE.STUDENT:
      return <Students />;
    case USER_TYPE.EMPLOYER:
      return <Employers />;
  }
}
