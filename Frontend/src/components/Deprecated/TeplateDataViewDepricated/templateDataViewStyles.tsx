import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    width: "100%",
  },
  nav: {
    backgroundColor: "#524e4e",
    padding: "3px",
    display: "flex",
    justifyContent: "space-around",
    alignItems: "center",
    paddingBottom: "10px",
  },
  combo: {
    width: "150px",
    paddingTop: "8px",
    //position: "absolute",
    //top: "50px",
  },
  filter: {
    width: "150px",
  },
  InsideContainer: {
    backgroundColor: theme.palette.background.paper,
  },
  Inside: {
    margin: "5px",
    padding: "5px",
  },
  AccordionRoot: {
    width: "100%",
  },
  AButton: {
    backgroundColor: theme.palette.primary.main,
    flex: "none",
    width: "150px",
    color: "#000",
  },
  AButtonBox: { margine: "15px", padding: "5px" },
  ADetailButtons: {
    width: "90vw",
    display: "flex",
    justifyContent: "flex-end",
    alignItems: "center",
  },
  Paging: {

    flex: "1",
    display: "flex",
    justifyContent: "center",
    alignItems: "center",

    backgroundColor:"#000",
    width:"100%",
    padding:"10px",
    "& > *": {
      margin: theme.spacing(1),
    },
  },
}));

export default useStyles;
