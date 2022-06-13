import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      // display: "flex",
    },
    paper: {
      marginTop: theme.spacing(-5),
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
      width: "55vw",
    },
    avatar: {
      margin: theme.spacing(1),
      backgroundColor: theme.palette.secondary.main,
    },
    submit: {
      margin: theme.spacing(3, 0, 2),
    },
    forma: {
      width: "60vw",
      borderRadius: "25px",
      backgroundColor: theme.palette.grey[800],
      opacity: "0.9",
      padding: "3%",
      paddingBottom: "2%",
      position: "relative",
      top: "5vh",
      minWidth: 300,
      minHeight: 450,
    },
    prijava: {
      textAlign: "center",
    },
    TF: {
      width: "50%",
      height: "100%",
      minWidth: "200px",
      padding: "10px",
    },
    containerTF: {
      display: "flex",
      justifyContent: "space-between:",
      alignItems: "start",
      flexWrap: "wrap",
    },
    ZabraneCB: {

    },
    ZabranaOneCB:{
      float: "left",
    },
    treeComponent:{
      display: "flex",
      alignItems: "center"
    },
  })
);

export default useStyles;
