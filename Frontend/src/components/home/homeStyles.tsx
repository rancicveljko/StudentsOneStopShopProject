import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
const drawerWidth = window.innerWidth > 600 ? 450 : 300;

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      display: "flex",
    },
    drawer: {
      [theme.breakpoints.up("lg")]: {
        //lg
        width: drawerWidth,
        flexShrink: 0,
      },
    },
    appBar: {
      [theme.breakpoints.up("lg")]: {
        //lg
        marginLeft: drawerWidth,
      },
      height: "65px",
    },

    menuButtonLeft: {
      position: "absolute",
      marginRight: theme.spacing(2),
      left: "15px",
      top: "7px",
      [theme.breakpoints.up("xl")]: {
        //lg
        display: "none",
      },
    },
    menuButtonRight: {
      position: "absolute",
      marginRight: theme.spacing(2),
      left: window.innerWidth - 40,
      top: "7px",
      [theme.breakpoints.up("xl")]: {
        //lg
        display: "none",
      },
    },
    // necessary for content to be below app bar
    toolbar: theme.mixins.toolbar,
    drawerPaper: {
      width: drawerWidth,
    },
    content: {
      flexGrow: 1,
      padding: theme.spacing(3),
    },
    tree: {
      height: 240,
      flexGrow: 1,
      maxWidth: 400,
    },
    treeItem: {
      paddingLeft: "10px",
    },
    naslov: {
      justifyContent: "center",
      height: "65px",
      alignItems: "center",
    },
    komentarBox: {
      padding: "5px",
      margin: "5px",
    },
    komentarNew: {
      marginTop: "10px",
      marginLeft: "5px",
      marginRight: "10px",
    },
    dugmeKomentar: {
      marginTop: "10px",
      marginLeft: "5px",
    },
    dugmeFab: {
      position: "absolute",
      top: "0.85vh",
      left:
        window.innerWidth > 1280
          ? window.innerWidth - 510
          : window.innerWidth - 100,
    },
    dugmeFabSortr: {
      position: "absolute",
      top: "0.85vh",
      left: window.innerWidth > 1280 ? 465 : 55,
    },
    Middle: {
      display: "flex",
      flexWrap: "wrap",
      overflowY: 'auto',
      height:window.innerHeight-250
    },
    MiddleItem: {
      minWidth: "200px",
    },
    FileClicked: {
      //fontWeight: 600,
      color: "#ff3c64",
      //color:theme.palette.secondary.light,
      fontSize: 25,
    },
    FileNotClicked: {
      //fontWeight:400,
      color: "#ffffff",
      fontSize: 25,
    },
    appBarBottom: {
      position: "absolute",
      left: window.innerWidth > 1280 ? 450 : 0,
      width:
        window.innerWidth > 1280
          ? window.innerWidth - 2 * drawerWidth
          : window.innerWidth,
      height: "75px",
      top: "auto",
      bottom: 0,
      backgroundColor: theme.palette.background.paper,
    },
    appBarBottomContainer: {
      display: "flex",
      alignItems: "center",
      justifyItems: "center",
    },
    Paging: {
      flex: "1",
      flexShrink: 1,
      justifyContent: "center",
      paddingTop: "10px",
      alignItems: "center",
      "& .MuiPaginationItem-root": {
        //color: "#ffffff",
      },
    },
    combo: {
      width: "150px",
      paddingTop: "10px",
    },
    rootSpeedDial: {
      transform: "translateZ(0px)",
      flexGrow: 1,
    }, //speed dail
    exampleWrapper: {
      position: "absolute",
      left:
        window.innerWidth > 1280
          ? window.innerWidth - drawerWidth+5
          : window.innerWidth +5,
      top: window.innerHeight - 480,

      marginTop: theme.spacing(3),
      height: 380,
    },
    speedDial: {
      position: "absolute",
      "&.MuiSpeedDial-directionUp": {
        bottom: theme.spacing(2),
        right: theme.spacing(2),
      },
    },
    speedAction: {},
    ///speed dail
  })
);
export default useStyles;
