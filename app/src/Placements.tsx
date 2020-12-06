import {
  Card,
  CardContent,
  CardHeader,
  CardMedia,
  Grid as Flex,
  useTheme,
  Chip,
  Button,
  CardActions,
} from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React from "react";
import styled from "styled-components";
import { apply } from "./api";
import { Content } from "./components/util";
import { Capability } from "./entities/Capability";
import { Placement } from "./entities/Placement";
import { useStore } from "./store";

const Chips = styled.div`
  padding: 0px ${(props) => props.theme.spacing(1.7)}px;
  .MuiChip-root {
    .MuiChip-label {
      padding: 0;
    }
    height: auto;
    border-radius: ${(p) => p.theme.spacing(2)}px;
    padding: ${(props) => props.theme.spacing(0.5, 1)};
    margin: 0px ${(props) => props.theme.spacing(1)}px
      ${(props) => props.theme.spacing(1)}px 0px;
  }
`;

const StyledParagraph = styled.p``;

const StyledCard = styled(Card)`
  width: 100%;
  margin-bottom: ${(p) => p.theme.spacing(2)}px;
`;

export default function Placements(_: RouteComponentProps) {
  const [{ user }] = useStore();
  const theme = useTheme();

  return (
    <Content
      style={{
        padding: theme.spacing(2),
      }}
    >
      {user ? (
        user.placements.map(
          ({
            id,
            // employer: { companyName, companyDescription, companyImage },
            title,
            placementImage,
            description,
            minHours,
            maxHours,
            capabilities,
            location,
          }) => (
            <Flex item key={id}>
              <StyledCard theme={theme}>
                <CardMedia
                  style={{
                    paddingTop: "56.25%",
                  }}
                  image={"http://placeimg.com/400/200?" + Math.random()}
                />
                <CardHeader
                  title={title}
                  subheader={
                    <>
                      {/* <span>{companyName} · </span> */}
                      <span>
                        {minHours}-{maxHours} hours
                      </span>{" "}
                      <span>· {location}</span>
                    </>
                  }
                />
                <Chips theme={theme}>
                  {capabilities.map((x: Capability, key) => {
                    return <Chip key={key} label={x.name} />;
                  })}
                </Chips>
                <CardContent>
                  <StyledParagraph>{description}</StyledParagraph>
                </CardContent>
                <CardActions>
                  <Button
                    onClick={async () => {
                      await apply(user.id, id);
                      console.log("applied!");
                    }}
                  >
                    Apply
                  </Button>
                  <Button
                    onClick={async () => {
                      await apply(user.id, id);
                      console.log("applied!");
                    }}
                  >
                    Reject
                  </Button>
                </CardActions>
              </StyledCard>
            </Flex>
          )
        )
      ) : (
        <p>Please select a user</p>
      )}
    </Content>
  );
}
