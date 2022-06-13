import React from "react";
import SpeedDial, { SpeedDialProps } from "@material-ui/lab/SpeedDial";
import AccountCircleOutlinedIcon from "@material-ui/icons/AccountCircleOutlined";
import InsertDriveFileOutlinedIcon from "@material-ui/icons/InsertDriveFileOutlined";
import HelpOutlineOutlinedIcon from "@material-ui/icons/HelpOutlineOutlined";
import SpeedDialIcon from "@material-ui/lab/SpeedDialIcon";
import SpeedDialAction from "@material-ui/lab/SpeedDialAction";
import useStyles from "./homeStyles";
import { Box, ThemeProvider } from "@material-ui/core";

const actions = [
  {
    icon: <AccountCircleOutlinedIcon color="secondary" />,
    name: "Lista korisnika",
    history: "/TableKorisnickiNalozi",
  },
  {
    icon: <InsertDriveFileOutlinedIcon color="secondary" />,
    name: "Lista materijala",
    history: "TableMaterijali",
  },
  {
    icon: <HelpOutlineOutlinedIcon color="secondary" />,
    name: "Administrski zahtevi",
    history: "/TableKorisnickiNalozi",
  }, //za ADMINA ONLY

  // { icon: <ShareIcon color="secondary" />, name: "Share" },
  // { icon: <FavoriteIcon color="secondary" />, name: "Like" },
];

export default function SpeedDials(history:any) {
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => {
    setOpen(true);
  };

  return (
    <Box className={classes.exampleWrapper}>
      <SpeedDial
        FabProps={{ size: "medium", style: { backgroundColor: "#f88cb4" } }} //
        ariaLabel="SpeedDial example"
        className={classes.speedDial}
        icon={<SpeedDialIcon color="secondary" />}
        onClose={() => {
          setOpen(false);
        }}
        onOpen={handleOpen}
        open={open}
        color="secondary"
      >
        {actions.map((action) => (
          <SpeedDialAction
            key={action.name}
            icon={action.icon}
            tooltipTitle={action.name}
            onClick={() => {
              setOpen(false);
              history.push(action.history);
            }}
            className={classes.speedAction} //visak vrv
            color="secondary"
          />
        ))}
      </SpeedDial>
    </Box>
  );
}
//accounts
//file
// zahtevi nalog
//(zahtev materijal)
//(folder) jos nije
