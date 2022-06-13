import React, { useEffect } from "react";
import Button from "@material-ui/core/Button";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import useMediaQuery from "@material-ui/core/useMediaQuery";
import { useTheme } from "@material-ui/core/styles";
import { KomentarItem, KomentarItems } from "./item";
import useStyles from "./styles";
import { Box, IconButton, Typography } from "@material-ui/core";
import ArrowBackIosOutlinedIcon from "@material-ui/icons/ArrowBackIosOutlined";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import AddCommentOutlinedIcon from "@material-ui/icons/AddCommentOutlined";
import Divider from "@material-ui/core/Divider";
import { IKomentar } from "./interfaces";
import { FetchKomentari, DodajKomentar } from "../fetches";
import { INode } from "../homeInterfaces";
import { NewComment } from "./newKomentar";

export default function Komentari(
  materijal: INode,
  openKomentare: boolean,
  setOpenKomentare: (a: boolean) => void
) {
  const classes = useStyles();
  const theme = useTheme();
  const fullScreen = useMediaQuery(theme.breakpoints.down("xs"));

  const [openNewComment, setOpenNewComment] = React.useState(false);
  const [tekstNewComment, setTekstNewComment] = React.useState("");

  function handleNewComment() {
    if (tekstNewComment !== ""){
      DodajKomentar(tekstNewComment, materijal, setListaKomentara);
      setTekstNewComment("");
    }
  }

  function handlePodKomentari(trenutni:IKomentar){
    setListaRoditelja([...listaRoditelja,trenutni]);
    FetchKomentari(materijal,trenutni.KorisnickoIme,trenutni.Vreme,setListaKomentara)
  }

  const [listaRoditelja, setListaRoditelja] = React.useState<IKomentar[]>([
    {
      KorisnickoIme: "aaa",
      Tekst: "aaaaaaaaaaa",
      Vreme: new Date().toLocaleDateString(),
      Tip: "Napredni",
     // ImaOdgovore: true,
    },
  ]);
  const [listaKomentara, setListaKomentara] = React.useState<IKomentar[]>([
    {
      KorisnickoIme: "aaa",
      Tekst: "aaaaaaaaaaa",
      Vreme: new Date().toLocaleDateString(),
      Tip: "Napredni",
     // ImaOdgovore: true,
    },
    {
      KorisnickoIme: "dfdfdf",
      Tekst: "fdfdddddddddddddddddddd",
      Vreme: "22:222:222",
      Tip: "Admin",
     // ImaOdgovore: false,
    },
    {
      KorisnickoIme: "dfdfdf",
      Tekst:
        "fdkldlkn dnkldknlfnkdd ddddddddddda ssaaaaaaaakkkkk kkkkkkkk uuuuuuuuu uuuuuuuu",
      Vreme: new Date().toLocaleDateString(),
      Tip: "Osnovni_Korisnik",
     // ImaOdgovore: true,
    },
  ]);

  useEffect(()=>{
    FetchKomentari(materijal,"","",setListaKomentara);
  },[])

  const handleClose = () => {
    setOpenKomentare(false);
  };

  return (
    <div>
      <Dialog
        fullScreen={fullScreen}
        open={openKomentare}
        onClose={handleClose}
        aria-labelledby="responsive-dialog-title"
      >
        <Box padding="15px" paddingBottom="10px">
          <Typography variant="h6">Komentari</Typography>
          <Divider />
          {listaRoditelja.length !== 0 &&
            KomentarItem(
              listaRoditelja[listaRoditelja.length - 1],
              classes,
              true,
              listaRoditelja,
              setListaRoditelja,
              openNewComment,
              setOpenNewComment,
              handlePodKomentari
            )}
          <Divider />
        </Box>
        <DialogContent>
          <DialogContentText>
            {KomentarItems(
              listaKomentara,
              classes,
              listaRoditelja,
              setListaRoditelja,
              openNewComment,
              setOpenNewComment,
              handlePodKomentari
            )}
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Divider />

          <Box display="flex" justifyContent="space-between" width="100%">
            <Box padding="10px" paddingTop="0px">
              {listaRoditelja.length !== 0 && (
                <IconButton
                  aria-label="Vrati se nazad"
                  onClick={() => {
                    if (listaRoditelja.length !== 0) {
                      const pom: IKomentar =
                        listaRoditelja[listaRoditelja.length - 1];
                      listaRoditelja.pop();
                      FetchKomentari(
                        materijal,
                        pom.KorisnickoIme,
                        pom.Vreme,
                        setListaKomentara
                      );
                    }
                    {
                      alert("lenght 0");
                    }
                  }}
                >
                  <ArrowBackIosOutlinedIcon />
                </IconButton>
              )}
            </Box>
            <Box padding="10px" paddingTop="0px">
              <IconButton
                aria-label="Zatvori"
                onClick={() => {
                  setOpenKomentare(false);
                }}
              >
                <CloseOutlinedIcon />
              </IconButton>
            </Box>
          </Box>
        </DialogActions>
      </Dialog>
      {NewComment(openNewComment, setOpenNewComment,tekstNewComment, setTekstNewComment, handleNewComment,classes)}
    </div>
  );
}
