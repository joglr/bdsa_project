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
import { Link, RouteComponentProps } from "@reach/router";
import React, { useState } from "react";
import styled from "styled-components";
import { apply } from "./api";
import { Content } from "./components/util";
import { Capability } from "./entities/Capability";
import { Employer } from "./entities/Employer";
import { Placement } from "./entities/Placement";
import { Student } from "./entities/Student";
import { USER_TYPE, useStore } from "./store";

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

export default function Placements({
  browse,
  placements,
}: RouteComponentProps & { placements: Placement[]; browse: boolean }) {
  const [{ user, userType }] = useStore();
  const theme = useTheme();
  const [skipped, setSkipped] = useState<number[]>([]);
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
        ? filteredPlacements.map(
            ({
              id,
              title,
              placementImage,
              description,
              minHours,
              maxHours,
              capabilities,
              location,
              ...rest
            }) => (
              <Flex item key={id}>
                <StyledCard theme={theme}>
                  <CardMedia
                    style={{
                      paddingTop: "56.25%",
                    }}
                    image={`http://placeimg.com/400/200/${placementImage}`}
                  />
                  <CardHeader
                    title={title}
                    subheader={
                      <>
                        {rest.employer !== null ? (
                          <span>{rest.employer.companyName} · </span>
                        ) : (
                          (user as Employer).companyName
                        )}
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
                    {userType === USER_TYPE.STUDENT && browse && (
                      <>
                        <Button
                          onClick={async () => {
                            await apply(user.id, id);
                            console.log("applied!");
                          }}
                        >
                          Apply
                        </Button>
                        <Button
                          onClick={() =>
                            setSkipped((prevSkipped: number[]) => [
                              ...prevSkipped,
                              id,
                            ])
                          }
                        >
                          Reject
                        </Button>
                      </>
                    )}
                    {userType === USER_TYPE.EMPLOYER && (
                      <>
                        <Button component={Link} to={`/placements/${id}`}>
                          View applicants
                        </Button>
                      </>
                    )}
                  </CardActions>
                </StyledCard>
              </Flex>
            )
          )
        : browse
        ? "No placements. Come back later!"
        : userType === USER_TYPE.EMPLOYER
        ? "No placements created"
        : "You have not applied to any placements yet"}
    </Content>
  );
}
