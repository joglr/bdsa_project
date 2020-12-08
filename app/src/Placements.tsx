import { Grid as Flex, useTheme } from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React, { useState } from "react";
import styled from "styled-components";
import { Content } from "./components/util";
import { Placement } from "./entities/Placement";
import PlacementCard from "./PlacementCard";
import { USER_TYPE, useStore } from "./store";
import { useLocalStorage } from "./util";

const StyledCard = styled(PlacementCard)``;

export default function Placements({
  browse,
  placements,
}: RouteComponentProps & { placements: Placement[]; browse: boolean }) {
  const [{ user, userType }] = useStore();
  const theme = useTheme();
  const [skipped, setSkipped] = useLocalStorage<number[]>("skipped", []);
  const filteredPlacements = placements.filter(
    ({ id }) =>
      (!skipped.includes(id) && !user?.placements.find((p) => p.id === id)) ||
      !browse
  );

  return (
    <Content
      style={{
        padding: theme.spacing(2),
      }}
    >
      {user && filteredPlacements.length > 0
        ? filteredPlacements.map((placement: Placement) => (
            <Flex item key={placement.id}>
              <StyledCard
                theme={theme}
                placement={placement}
                setSkipped={setSkipped}
                browse={browse}
                style={{
                  width: "100%",
                  margin: theme.spacing(2, 0),
                }}
              />
            </Flex>
          ))
        : browse
        ? "No placements. Come back later!"
        : userType === USER_TYPE.EMPLOYER
        ? "No placements created"
        : "You have not applied to any placements yet"}
    </Content>
  );
}
