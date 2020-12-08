import React, { useState } from "react";
import { Placement } from "./entities/Placement";
import {
  Card,
  CardContent,
  CardHeader,
  CardMedia,
  Chip,
  Button,
  CardActions,
  useTheme,
  CircularProgress,
  Grow,
} from "@material-ui/core";
import { apply } from "./api";
import { Capability } from "./entities/Capability";
import { Link } from "@reach/router";
import { Employer } from "./entities/Employer";
import styled from "styled-components";
import { USER_TYPE, useStore } from "./store";
import { ContentX } from "./components/util";
import { sleep } from "./util";

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

export default function PlacementCard({
  placement: {
    id,
    title,
    placementImage,
    description,
    minHours,
    maxHours,
    capabilities,
    location,
    ...rest
  },
  setSkipped,
  browse,
  ...props
}: {
  placement: Placement;
  browse: boolean;
  setSkipped: any;
  style: any;
}) {
  const [{ user, userType }, dispatch] = useStore();
  const theme = useTheme();
  const [isApplying, setIsApplying] = useState(false);

  return (
    <Card {...props} style={{ ...props.style, position: "relative" }}>
      <Grow in={!isApplying}>
        <div>
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
                  <span>{(user as Employer).companyName} · </span>
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
          {user && (
            <CardActions>
              {userType === USER_TYPE.STUDENT && browse && (
                <>
                  <Button
                    onClick={async () => {
                      setIsApplying(true);
                      await sleep(500);
                      await apply(user.id, id, dispatch);
                      setIsApplying(false);
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
          )}
        </div>
      </Grow>
      <Grow in={isApplying} style={{ position: "absolute", bottom: 0 }}>
        <ContentX
          style={{
            padding: theme.spacing(),
            justifyContent: "center",
          }}
        >
          <CircularProgress />
        </ContentX>
      </Grow>
    </Card>
  );
}
