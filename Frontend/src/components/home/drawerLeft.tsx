import {
  Box,
  Divider,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
} from "@material-ui/core";
import React from "react";
import useStyles from "./homeStyles";

import { ITree, INode } from "./homeInterfaces";
import TreeFunction from "./tree";
import Typography from "@material-ui/core/Typography";

export default function DrawerLeft(
  data: ITree[],
  selectedOblast:INode,
  handleOblastClick: (a: INode) => Promise<any>,
  setTree: Function,
  setListaMaterijal: Function,
  setselectedFile: Function
) {
  const classes = useStyles();
  return (
    <Box>
      <Box display="flex" className={classes.naslov}>
        <Typography variant="h6">Pregled dostupnih foldera</Typography>
      </Box>
      <Divider />
      <List className={classes.treeItem} key="treeRoot">
        {TreeFunction(data,selectedOblast, handleOblastClick, setTree,setListaMaterijal,setselectedFile)}
      </List>
    </Box>
  );
}
