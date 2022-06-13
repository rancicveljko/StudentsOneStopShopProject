import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import { blue } from '@material-ui/core/colors';///bolje primary


const useStyles = makeStyles((theme: Theme) => createStyles({
    avatar: {
        backgroundColor: theme.palette.primary.main,
        color: blue[800],
      },
}));
export default useStyles;
