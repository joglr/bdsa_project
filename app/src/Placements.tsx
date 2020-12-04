import {
  Card,
  CardActionArea,
  CardContent,
  CardHeader,
  CardMedia,
  Grid as Flex,
  Grow,
  useTheme,
} from "@material-ui/core";
import { RouteComponentProps } from "@reach/router";
import React from "react";
import { usePlacements } from "./api";

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
              <CardContent>{description}</CardContent>
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
