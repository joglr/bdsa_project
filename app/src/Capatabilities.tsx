import { RouteComponentProps } from "@reach/router";
import React from "react";
import { useCapabilities } from "./api";

export default function Capabilities(props: RouteComponentProps) {
  const stuff = useCapabilities();
  return (
    <div>
      {stuff.map((x) => (
        <div key={x.id}>{JSON.stringify(x)}</div>
      ))}
    </div>
  );
}
