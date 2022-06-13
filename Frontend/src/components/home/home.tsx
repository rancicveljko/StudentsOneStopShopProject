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
import useStyles from "./homeStyles";
import DrawerLeft from "./drawerLeft";
import DrawerRight from "./drawerRight";
import MenuIcon from "@material-ui/icons/Menu";
import FilterListOutlinedIcon from "@material-ui/icons/FilterListOutlined";
import SortOutlinedIcon from "@material-ui/icons/SortOutlined";
import React from "react";
import Middle from "./middle";
import { INode, IOblastSadrzaj, ISadrzaj, ITree } from "./homeInterfaces";
import {
  PribaviSadrzajOblast,
  FetchBrojMaterijala,
  PribaviSadrzajOblastInit,
  fetchFileDetails,
  FetchKomentari,
} from "./fetches";
import { useHistory, useLocation } from "react-router-dom";
import { useEffect } from "react";
import Sort from "./sort/sort";
import Filter from "./filter/filter";
import BottomAppBar from "./bottomAppBar";
import SpeedDials from "./speedDial";
interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
}

export default function Home(props: Props) {
  const location = useLocation(); //konditional render dial
// Osnovni_Korisnik
//Napredni_Korisnik
//Administrator


  const history = useHistory();
  const { window: windoww } = props;
  const classes = useStyles();
  const theme = useTheme();
  const [mobileOpenLeft, setMobileOpenLeft] = React.useState(false);
  const [mobileOpenRight, setMobileOpenRight] = React.useState(false);
  const [listaMaterijal, setListaMaterijal] = React.useState<ISadrzaj>(
    //middle
    {
      path: "",
      files: [],
    }
  );

  const [selectedFile, setselectedFile] = React.useState<INode>({
    path: "",
    naziv: "root",
  });

  const [selectedOblast, setselectedOblast] = React.useState<INode>({
    path: "",
    naziv: "root",
  });

  const [tree, setTree] = React.useState<ITree[]>([
    { name: "", path: "root", children: [] },
  ]);

  useEffect(() => {
    //za intit
    PribaviSadrzajOblastInit(
      setTree,
      setListaMaterijal,
      setselectedFile,
      setBrMaterijala,
      selectedOblast
    );
    fetchFileDetails(selectedFile);
  }, []); //da se doda sta na koju promenu ide fetch

  /* useEffect(() => {//za sve posle init
    PribaviSadrzajOblast(
      setTree,
      setListaMaterijal,
      setselectedFile,
      setBrMaterijala,
      selectedOblast
    );
    fetchFileDetails(selectedFile);
  }, []);filter sort*/

  async function handleOblastClick(val: INode): Promise<any> {
    setselectedOblast(val);
    setBrMaterijala(FetchBrojMaterijala(val));
    return PribaviSadrzajOblast(
      val,
      setTree,
      setListaMaterijal,
      setselectedFile
    );
  }

  const handleDrawerToggleRight = () => {
    setMobileOpenRight(!mobileOpenRight);
  };
  const handleDrawerToggleLeft = () => {
    setMobileOpenLeft(!mobileOpenLeft);
  };

  const container =
    windoww !== undefined ? () => windoww().document.body : undefined;

  /////sort
  const handleClickSortOpen = () => {
    setOpenSort(true);
  };
  const [openSort, setOpenSort] = React.useState(false);
  const [selectedValue, setSelectedValue] = React.useState("");
  /////

  ///////filter
  const [openFilter, setOpenFilter] = React.useState(false);
  const handleClickFilterOpen = () => {
    setOpenFilter(true);
  };
  const [selectedExtension, setSelectedExtension] = React.useState(""); //za fetch ako je "" ide null
  const [selectedName, setSelectedName] = React.useState(""); //za fetch ako je "" ide null
  ///////

  //////////pagination
  const [pagenum, setPagenum] = React.useState(10); //deafult prikaza po strani
  const [brMaterijala, setBrMaterijala] = React.useState(0);
  //////////

  return (
    <Box className={classes.root}>
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <Grid
            justify="space-between"
            alignItems="flex-start"
            container
            spacing={10}
            style={{
              height: "120px",
              display: "flex",
              alignItems: "center",
              justifyContent: "space-between",
            }}
          >
            <Grid item style={{ paddingLeft: "27px" }}>
              <IconButton
                color="inherit"
                aria-label="open drawer"
                edge="start"
                onClick={handleDrawerToggleLeft}
                className={classes.menuButtonLeft}
              >
                <MenuIcon />
              </IconButton>
              <Fab
                variant="round"
                size="medium"
                color="secondary"
                className={classes.dugmeFabSortr}
                onMouseDown={() => {
                  handleClickSortOpen();
                }}
              >
                {<SortOutlinedIcon />}
              </Fab>
            </Grid>
            <Grid item style={{ flexShrink: 1 }}>
              <Typography variant="h5" noWrap>
                {window.innerWidth > 600 ? "Sadržaj oblasti: " : ""}
                {selectedOblast.naziv}
              </Typography>
              <Fab
                variant="round"
                size="medium"
                color="secondary"
                className={classes.dugmeFab}
                onMouseDown={() => {
                  handleClickFilterOpen();
                }}
              >
                {<FilterListOutlinedIcon />}
              </Fab>
              {SpeedDials(history)}
            </Grid>

            <Grid item style={{ paddingRight: "0px" }}>
              <IconButton
                color="inherit"
                aria-label="open drawer"
                edge="start"
                onClick={handleDrawerToggleRight}
                className={classes.menuButtonRight}
              >
                <MenuIcon />
              </IconButton>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
      <nav className={classes.drawer} aria-label="mailbox folders">
        {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
        <Hidden lgUp /*lg*/ implementation="css">
          <Drawer
            container={container}
            variant="temporary"
            anchor={theme.direction === "rtl" ? "right" : "left"}
            open={mobileOpenLeft}
            onClose={handleDrawerToggleLeft}
            classes={{
              paper: classes.drawerPaper,
            }}
            ModalProps={{
              keepMounted: true, // Better open performance on mobile.
            }}
          >
            {DrawerLeft(
              tree,
              selectedOblast,
              handleOblastClick,
              setTree,
              setListaMaterijal,
              setselectedFile
            )}
          </Drawer>
        </Hidden>
        <Hidden mdDown /*md*/ implementation="css">
          <Drawer
            classes={{
              paper: classes.drawerPaper,
            }}
            variant="permanent"
            open
          >
            {DrawerLeft(
              tree,
              selectedOblast,
              handleOblastClick,
              setTree,
              setListaMaterijal,
              setselectedFile
            )}
          </Drawer>
        </Hidden>
      </nav>
      <main className={classes.content}>
        <div className={classes.toolbar} />
        <Box display="flex" justifyContent="start">
          {Middle(listaMaterijal, selectedFile, setselectedFile)}
          {Sort(openSort, setOpenSort, selectedValue, setSelectedValue)}
          {Filter(
            openFilter,
            setOpenFilter,
            selectedExtension,
            setSelectedExtension,
            selectedName,
            setSelectedName
          )}
        </Box>
      </main>
      <nav className={classes.drawer} aria-label="mailbox folders">
        {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
        <Hidden lgUp /* lg */ implementation="css">
          <Drawer
            container={container}
            variant="temporary"
            anchor={theme.direction === "rtl" ? "left" : "right"}
            open={mobileOpenRight}
            onClose={handleDrawerToggleRight}
            classes={{
              paper: classes.drawerPaper,
            }}
            ModalProps={{
              keepMounted: true, // Better open performance on mobile.
            }}
          >
            {DrawerRight(selectedFile, history)}
          </Drawer>
        </Hidden>
        <Hidden mdDown /*md*/ implementation="css">
          <Drawer
            classes={{
              paper: classes.drawerPaper,
            }}
            variant="permanent"
            open
            anchor="right"
          >
            {DrawerRight(selectedFile, history)}
          </Drawer>
        </Hidden>
      </nav>
      {BottomAppBar(brMaterijala, pagenum, setPagenum)}
    </Box>
  );
}
