import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useCapabilities } from "./api";
import Navigation from "./Navigation";

export default function Capabilities(props: RouteComponentProps) {
  const stuff = useCapabilities();
  return (
    <div>
      {stuff.map((x) => (
        <div>{JSON.stringify(x)}</div>
      ))}
    </div>
  );
}
