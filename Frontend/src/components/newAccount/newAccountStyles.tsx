import { makeStyles } from "@material-ui/core/styles";

export const useStyles = makeStyles((theme) => ({
  root: {
    width: "100vw",
    height: "100%",
    backgroundSize: "cover",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "center",
    overflow: "hidden",
    backgroundAttachment: "fixed",
    minWidth: 300,
    minHeight: 700,
    flexGrow:0,
  },
  forma: {
    width: "30vw",
   //height: "50vh",
    borderRadius: "25px",
    backgroundColor: theme.palette.grey[800],
    opacity: "0.9",
    padding: "2%",
    //paddingBottom:"0%", dodato
    //marginBottom:"5%", dodato
    position: "relative",
    top: "7vh",
    minWidth: 300,
    minHeight: 550,//bilo 600
    flexGrow:0,
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
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  prijava: {
    textAlign: "center",
  },
  top:{
    flexDirection: 'column',
   justifyContent: 'space-between',
  },
  topButton:{
    marginTop:"10px",
  },

}));

export default useStyles;
