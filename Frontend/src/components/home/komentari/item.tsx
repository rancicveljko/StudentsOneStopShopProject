import React from "react";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import Divider from "@material-ui/core/Divider";
import ListItemText from "@material-ui/core/ListItemText";
import SupervisorAccountOutlinedIcon from "@material-ui/icons/SupervisorAccountOutlined";
import Tooltip from "@material-ui/core/Tooltip";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import { IKomentar } from "./interfaces";
import { Box, Button } from "@material-ui/core";
import TextsmsOutlinedIcon from "@material-ui/icons/TextsmsOutlined";
import AddCommentOutlinedIcon from "@material-ui/icons/AddCommentOutlined";
import { FetchKomentari } from "../fetches";

export function KomentarItems(
  listaSvih: IKomentar[],
  classes: any,
  listaRoditelja: IKomentar[],
  setListaRoditelja: (a: IKomentar[]) => void,
  openNewComment: boolean,
  setOpenNewComment: (a: boolean) => void,
  handlePodKomentari:(a:IKomentar)=>void
) {
  return (
    <List className={classes.root}>
      {listaSvih.map((x) =>
        KomentarItem(
          x,
          classes,
          false,
          listaRoditelja,
          setListaRoditelja,
          openNewComment,
          setOpenNewComment,
          handlePodKomentari
        )
      )}
    </List>
  );
}

export function KomentarItem(
  val: IKomentar,
  classes: any,
  tip: boolean,
  listaRoditelja: IKomentar[],
  setListaRoditelja: (a: IKomentar[]) => void,
  openNewComment: boolean,
  setOpenNewComment: (a: boolean) => void,
  handlePodKomentari:(a:IKomentar)=>void
) {
  return (
    <Box>
      <ListItem alignItems="flex-start">
        <ListItemText
          primary={
            <Box className={classes.korisnik}>
              {tip ? "Predhodni odgovor: " : ""}
              {val.KorisnickoIme}
              {val.Tip !== "Osnovni_Korisnik" && icon(val.Tip)}
            </Box>
          }
          secondary={
            <React.Fragment>
              <Box className={classes.tekst}>{val.Tekst}</Box>
              <Typography
                component="span"
                variant="body2"
                className={classes.inline}
                color="textPrimary"
              >
                <Box></Box>
                <Box className={classes.vreme}> {val.Vreme}</Box>
              </Typography>
              <Box display="flex" justifyContent="space-around">
                {(tip && (
                  <Box>
                    <Button
                      variant="outlined"
                      color="primary"
                      startIcon={<AddCommentOutlinedIcon />}
                      onClick={() => {
                        setOpenNewComment(true);
                      }}
                    >
                      Dodaj odgovor
                    </Button>
                  </Box>
                )) ||
                  ( 
                    <Box>
                      <Button
                        variant="outlined"
                        color="primary"
                        startIcon={<TextsmsOutlinedIcon />}
                        //type="submit"
                        onClick={() => {
                          handlePodKomentari(val);
                        }}
                      >
                        Pregledaj odgovore
                      </Button>
                    </Box>
                  )}
              </Box>
            </React.Fragment>
          }
        />
      </ListItem>
      <Divider component="li" />
    </Box>
  );
}

//i da nema odogovore bolje da se dodaju u praznu listu

function icon(tip: string) {
  return (
    <Tooltip title={tip}>
      <IconButton aria-label={tip}>
        <SupervisorAccountOutlinedIcon />
      </IconButton>
    </Tooltip>
  );
}
