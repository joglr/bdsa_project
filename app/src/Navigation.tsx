import {
  BottomNavigation,
  BottomNavigationAction,
  Theme,
  useTheme,
} from "@material-ui/core";
import { Link } from "@reach/router";
import React from "react";
import WorkIcon from "@material-ui/icons/Work";
import BusinessIcon from "@material-ui/icons/Business";
import PeopleIcon from "@material-ui/icons/People";
import AssignmentTurnedInIcon from "@material-ui/icons/AssignmentTurnedIn";

const routes = [
  { title: "Placements", route: "/placements", icon: <WorkIcon /> },
  { title: "Students", route: "/students", icon: <PeopleIcon /> },
  { title: "Employers", route: "/employers", icon: <BusinessIcon /> },
  {
    title: "Capabilities",
    route: "/capabilities",
    icon: <AssignmentTurnedInIcon />,
  },
];

export default function Navigation() {
  const theme = useTheme<Theme>();
  return (
    <BottomNavigation
      style={{
        boxShadow: theme.shadows[10],
        position: "sticky",
        width: "100%",
        bottom: 0,
      }}
    >
      <div>
        {routes.map(({ title, route, icon }, i) => (
          <BottomNavigationAction
            showLabel
            key={i}
            component={Link}
            to={route}
            label={title}
            icon={icon}
          />
        ))}
      </div>
    </BottomNavigation>
  );
}
// virker det i jeres browser?
// http://localhost:3000/placements
