import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useEmployers } from "./api";
import Navigation from "./Navigation";

export default function Employers(props: RouteComponentProps) {
  const stuff = useEmployers();
  return (
    <div>
      {stuff.map((x) => (
        <div>{JSON.stringify(x)}</div>
      ))}
    </div>
  );
}
