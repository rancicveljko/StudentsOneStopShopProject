import {
  Box,
  Button,
  Divider,
  Grid,
  IconButton,
  TextField,
  Typography,
} from "@material-ui/core";
import useStyles from "./homeStyles";

import ChatOutlinedIcon from '@material-ui/icons/ChatOutlined';

import ThumbUpOutlinedIcon from "@material-ui/icons/ThumbUpOutlined";
import ThumbDownOutlinedIcon from "@material-ui/icons/ThumbDownOutlined";
import ThumbUpRoundedIcon from "@material-ui/icons/ThumbUpRounded";
import ThumbDownRoundedIcon from "@material-ui/icons/ThumbDownRounded";

import OpenInBrowserOutlinedIcon from "@material-ui/icons/OpenInBrowserOutlined";
import GetAppOutlinedIcon from "@material-ui/icons/GetAppOutlined";
import { IDetails, INode } from "./homeInterfaces";
import Komentari from "./komentari/komentari";
import {
  DodajKomentar,
  DodajOcenuDown,
  DodajOcenuUp,
  fetchFileDetails,
  FetchKomentari,
  FetchMaterijal,
  FetchOcena,
} from "./fetches"; ///////////////////////////dodajkimenatr
import { useFormik } from "formik";
import React, { useEffect } from "react";

export default function DrawerRight(val: INode, history: any) {
  const [vote, setVote] = React.useState<number>();
  const [myVote, setMyVote] = React.useState(0);
  const [openKomentare, setOpenKomentare] = React.useState(false);

  const classes = useStyles();

  useEffect(() => {
    //FetchKomentar(val, setListaKomentara);
    FetchOcena(val, setVote, setMyVote);
  }, []); //mozda da se stavi val

  return (
    <Box>
      <Box style={{ height: "40vh" }}>{Detalji(val, history)}</Box>
      <Divider />
      <Box>
        <Grid container justify="space-around" alignItems="center">
          <Grid item>
            <Button
              variant="outlined"
              color="primary"
              className={classes.dugmeKomentar}
              startIcon={<ChatOutlinedIcon/>}
              //type="submit"
              onClick={() => {
                setOpenKomentare(true);
              }}
            >
              Komentari
            </Button>
          </Grid>
          <Grid item>
            <IconButton
              color="primary"
              onClick={() => {
                DodajOcenuUp(val, setVote, setMyVote);
              }}
            >
              {myVote !== 1 ? <ThumbUpOutlinedIcon /> : <ThumbUpRoundedIcon />}
            </IconButton>
          </Grid>
          <Grid item>
            <Typography variant="h5" color="primary">
              {vote}
            </Typography>
          </Grid>
          <Grid item>
            <IconButton
              color="secondary" //da l ce ostane
              onClick={() => {
                DodajOcenuDown(val, setVote, setMyVote);
              }}
            >
              {myVote !== -1 ? (
                <ThumbDownOutlinedIcon />
              ) : (
                <ThumbDownRoundedIcon />
              )}
            </IconButton>
          </Grid>
        </Grid>
      </Box>
      {Komentari(val,openKomentare, setOpenKomentare)}
    </Box>
  );
}

function Detalji(val: INode, history: any) {
  const [detalji, setDetelji] = React.useState<IDetails>({
    PunNaziv: "",
    Opis: "",
  });

  useEffect(() => {
    fetchFileDetails(val);
  }, [val]); //mzda val

  const classes = useStyles();
  return (
    <Box>
      <Box display="flex" className={classes.naslov}>
        <Typography variant="h6">Detalji</Typography>
      </Box>
      <Divider />
      <Box className={classes.komentarBox}>
        <Box>
          <Typography>Pun naziv fajla:</Typography>
          <Divider />
          <Typography>{detalji.PunNaziv}</Typography>
        </Box>
        <Box height="15px"></Box>

        <Typography>Opis fajla:</Typography>
        <Divider />

        <Typography>{detalji.Opis}</Typography>

        <Box height="15px"></Box>
        <Box display="flex" justifyContent="space-around">
          <Box>
            <Button
              variant="outlined"
              color="primary"
              className={classes.dugmeKomentar}
              startIcon={<OpenInBrowserOutlinedIcon />}
              onClick={() =>
                history.push(`/ViewDoc/${val.path + "/" + val.naziv}`)
              }
            >
              Pregled
            </Button>
          </Box>
          <Box>
            <Button
              variant="outlined"
              color="primary"
              className={classes.dugmeKomentar}
              startIcon={<GetAppOutlinedIcon />}
              onClick={() => FetchMaterijal(val)}
            >
              Preuzmimanje
            </Button>
          </Box>
        </Box>
      </Box>
    </Box>
  );
}
