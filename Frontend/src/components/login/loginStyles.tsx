import { makeStyles} from "@material-ui/core/styles";
import Image from ".//..//..//resources/slika.jpg";

const useStyles = makeStyles((theme) => ({
  root: {
    backgroundImage: `url(${Image})`,
    width: "100vw",
    height: "100vh",
    backgroundSize: "cover",
    backgroundRepeat: "no-repeat",
    backgroundPosition: "center",
    overflow: "hidden",
    backgroundAttachment: "fixed",
    minWidth: 300,
    minHeight: 600,
  },
  forma: {
    width: "30vw",
    height: "50vh",
    borderRadius: "25px",
    backgroundColor: theme.palette.grey[800],
    opacity: "0.9",
    padding: "3%",
    position: "relative",
    top: "20vh",
    minWidth: 300,
    minHeight: 450,
  },

  naslov: {
    width: "100%",
    color: "#fff",
    fontSize: "3vw",
    textAlign: "center",
    textTransform: "uppercase",
    background: "rgba(0,0,0,0.8)",
    padding: "10px",
    position: "absolute",
    top: "5%",
    left: "50%",
    transform: "translate(-50%,-50%)",
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
}));

export default useStyles;