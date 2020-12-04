import {
  Card,
  CardActionArea,
  CardContent,
  CardHeader,
  CardMedia,
  Grid as Flex,
  Grow,
  useTheme,
  Chip,
  Typography,
} from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React from "react";
import styled from "styled-components";
import { usePlacements } from "./api";

const Chips = styled.div`
padding: 0px ${(props) => props.theme.spacing(1.7)}px;
.chip {
    margin: 0px ${(props) => props.theme.spacing(1)}px ${(props) => props.theme.spacing(1)}px 0px;
  }
`

const StyledParagraph = styled.p`
  
`

export default function Placements(props: RouteComponentProps) {
  const placements = usePlacements();
  const theme = useTheme();

  const [firstPlacement, ...rest] = placements;

  return (
    <Flex
      container
      direction="column"
      alignItems="center"
      spacing={2}
      style={{ width: "100%", padding: theme.spacing(2) }}
    >
      {placements.map(
        ({
          employer: { companyName, companyDescription, companyImage },
          title,
          placementImage,
          description,
          minHours,
          maxHours,
          capabilities,
          location,
        }) => (
          <Flex item>
            <Card>
              <CardMedia
                style={{
                  paddingTop: "56.25%",
                }}
                image={"http://placeimg.com/400/200?" + Math.random()}
              />
              <CardHeader
                title={title}
                subheader={
                  <span>
                    {companyName} ·{" "}
                    <span>
                      {minHours}-{maxHours} hours
                    </span>{" "}
                    · {location}
                  </span>
                }
              />
              <Chips theme={theme}>
                {capabilities.map((x, key) => {
                  return <Chip className="chip" key={key} label={x.name} />
                })}               
              </Chips>
              <CardContent>
                <StyledParagraph>
                  {description}
                </StyledParagraph>
              </CardContent>
              <CardActionArea>{/* <Car</Card> */}</CardActionArea>
            </Card>
          </Flex>
        )
      )}
    </Flex>
  );
}

// function Placement(({ placement }) : { placement: Placement}) :  {
//   return <Card>
//     hello stuff
//   </Card>
// }
