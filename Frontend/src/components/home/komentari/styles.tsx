import { createStyles, Theme, makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme: Theme) =>
createStyles({
  root: {
    width: '100%',
    minWidth:"300px",
    maxWidth: '50vw',
    backgroundColor: theme.palette.background.paper,
  },
  inline: {
    display: 'inline',
  },
  korisnik:{
      fontWeight:600,
      fontSize:25,
  },
  tekst:{
    fontSize:19,
  },
  vreme:{
    fontSize:13,
  },
  NewComment:{
    minWidth:"350px",
    maxWidth: '45vw',

  }
}),
);
export default useStyles;