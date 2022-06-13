import {
  AppBar,
  Box,
  Button,
  Drawer,
  Fab,
  Grid,
  Hidden,
  IconButton,
  Toolbar,
  Typography,
  useTheme,
} from "@material-ui/core";
import { Pagination } from "@material-ui/lab";
import useStyles from "./homeStyles";
import ComboBox from "./BottomAppBarCombo";
import React from "react";

function AllTabs(classes: any, num: number) {
  return (
    <Box className={classes.Paging}>
      <Pagination count={num} variant="outlined" color="primary" size="large" />
    </Box>
  );
}

export default function BottomAppBar(brMaterijala:number,pagenum:number,setPagenum:(a:number)=>void) {

  const handlePagenum = (val: number) => {
    setPagenum(val);//broj prikaza po strani
  };

  const classes = useStyles(0);
  return (
    <AppBar position="fixed" className={classes.appBarBottom}>
      <Toolbar>
        {AllTabs(classes, brMaterijala/pagenum)}

        {ComboBox(classes, handlePagenum)}
      </Toolbar>
    </AppBar>
  );
}
