import {
  BottomNavigation,
  BottomNavigationAction,
  Theme,
  useTheme,
} from "@material-ui/core";
import { Link } from "@reach/router";
import React from "react";
import WorkIcon from "@material-ui/icons/Work";
// import BusinessIcon from "@material-ui/icons/Business";
// import PeopleIcon from "@material-ui/icons/People";
import SettingsIcon from "@material-ui/icons/Settings";
import AssignmentTurnedInIcon from "@material-ui/icons/AssignmentTurnedIn";
import { ContentX } from "./components/util";

const routes = [
  { title: "Browse", route: "/placements", icon: <WorkIcon /> },
  { title: "My", route: "/placements", icon: <WorkIcon /> },
  // { title: "Students", route: "/students", icon: <PeopleIcon /> },
  // { title: "Employers", route: "/employers", icon: <BusinessIcon /> },
  // {
  //   title: "Capabilities",
  //   route: "/capabilities",
  //   icon: <AssignmentTurnedInIcon />,
  // },
  { title: "Settings", route: "/settings", icon: <SettingsIcon /> },
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
      <ContentX style={{ gridTemplateColumns: "1fr" }}>
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
      </ContentX>
    </BottomNavigation>
  );
}
// virker det i jeres browser?
// http://localhost:3000/placements
