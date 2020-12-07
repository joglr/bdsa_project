import {
  BottomNavigation,
  BottomNavigationAction,
  Theme,
  useTheme,
} from "@material-ui/core";
import { Link } from "@reach/router";
import React from "react";
import WorkIcon from "@material-ui/icons/Work";
import SettingsIcon from "@material-ui/icons/Settings";
import { ContentX } from "./components/util";
import { USER_TYPE, useStore } from "./store";

const routes = [
  { title: "Browse", route: "/placements", icon: <WorkIcon /> },
  { title: "My placements", route: "/my-placements", icon: <WorkIcon /> },
  { title: "Settings", route: "/settings", icon: <SettingsIcon /> },
];

export default function Navigation() {
  const theme = useTheme<Theme>();
  const [{ userType }] = useStore();
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
        {routes
          .filter(
            (route) =>
              !(route.title === "Browse" && userType === USER_TYPE.EMPLOYER)
          )
          .map(({ title, route, icon }, i) => (
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
