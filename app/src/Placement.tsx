import { IconButton, Typography } from "@material-ui/core";
import { Link, RouteComponentProps } from "@reach/router";
import React from "react";
import { usePlacement } from "./api";
import { Content } from "./components/util";
import { Student } from "./entities/Student";
import BackIcon from "@material-ui/icons/ArrowBack";

export default function PlacementDetails(
  _: RouteComponentProps & { placementID?: number }
) {
  const placement = usePlacement(_.placementID ?? null);
  return (
    <Content>
      <IconButton component={Link} to="/placements">
        <BackIcon />
      </IconButton>
      <Typography variant="h6">{placement?.title}</Typography>
      <Typography variant="subtitle1">Applicants:</Typography>
      {placement?.students.length && placement.students.length > 0 ? (
        <ul>
          {placement?.students.map((s: Student) => (
            <li>
              {s.firstName} {s.lastName}
            </li>
          ))}
        </ul>
      ) : (
        <div>No applicants yet!</div>
      )}
    </Content>
  );
}
