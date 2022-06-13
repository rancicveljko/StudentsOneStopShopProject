import { makeStyles} from "@material-ui/core/styles";
import Image from ".//..//..//resources/slika.jpg";

export const useStyles = makeStyles((theme) => ({
    playerWrapper:{
        width: "auto",
        height: "auto",
    },
    reactPlayer: {
        paddingTop: "56.25%", // Percentage ratio for 16:9
        position: "relative", // Set to relative
    },
   // reactPlayer: > div: {//https://stackoverflow.com/questions/49393838/how-to-make-reactplayer-scale-with-height-and-width
    //    position: "absolute"//https://stackoverflow.com/questions/60569919/is-it-ok-to-define-nested-component-with-react-hooks
   // },
}))