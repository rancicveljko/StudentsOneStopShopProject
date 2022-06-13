import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({

    Button: {
      backgroundColor: theme.palette.primary.main,
      color: "#000",
      //margine:"10px",
      //padding:"10px",
      width: "150px",
    },
    ButtonBox: { margine: "15px", padding: "5px" },
    Buttons: {
      width: "25vw",
      paddingTop: "15px",

      display: "flex",
      justifyContent: "space-around",
      alignItems: "center",
    },
    paper: {
      marginTop: theme.spacing(-2),
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
    },
    avatar: {
      margin: theme.spacing(1),
      backgroundColor: theme.palette.secondary.main,
    },
    forma: {
      width: "30vw",
      //height: "50vh",
      borderRadius: "25px",
      backgroundColor: theme.palette.grey[800],
      opacity: "0.9",
      padding: "3%",
      position: "relative",
      top: "7vh",
      minWidth: 300,
      minHeight: 200,
    },
    prijava: {
      textAlign: "center",
    },
    treeComponent: { display: "flex", alignItems: "center" },
  })
);

export default useStyles;
