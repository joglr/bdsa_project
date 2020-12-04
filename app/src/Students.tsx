import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useStudents } from "./api";
import Navigation from "./Navigation";

export default function Students(props: RouteComponentProps) {
  const stuff = useStudents();
  return (
    <div>
      {stuff.map((student) => (
        <div>{}</div>
      ))}
    </div>
  );
}
