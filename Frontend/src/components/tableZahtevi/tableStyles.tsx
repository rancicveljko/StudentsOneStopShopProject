import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  rootMain: {
    width: "100vw",
  },
  root: {
    "& > *": {
      borderBottom: "unset",
    },
    width: "100vw",
  },
  container: {},
  rootPaper: {},
  header: {
    backgroundColor: "#000",
    borderBottom: "3px solid " + theme.palette.primary.main,
  },
  visuallyHidden: {
    border: 0,
    clip: "rect(0 0 0 0)",
    height: 1,
    margin: -1,
    overflow: "hidden",
    padding: 0,
    position: "absolute",
    top: 20,
    width: 1,
  },
  buttonBox: {
    display: "flex",
    justifyContent: "center",
  },
  button: {
    backgroundColor: theme.palette.primary.main,
    flex: "none",
    width: "150px",
    color: "#000",
    margin: "5px",
  },
  Box: {
    //border: "1px solid "+theme.palette.primary.main,
    width: "80%",
  },
  dugmeFabFilter: {
    position: "absolute",
    top: "7px",
    left: window.innerWidth - 70,
  },
  dugmeFabSortr: {
    position: "absolute",
    top: "7px",
    left: window.innerWidth - 150,
  },
}));
export default useStyles;
