import {
  Avatar,
  Box,
  Button,
  Container,
  CssBaseline,
  TextField,
  Typography,
} from "@material-ui/core";
import { useFormik } from "formik";
import useStyles from "./accUpdateStyles";
import PersonOutlineOutlinedIcon from "@material-ui/icons/PersonOutlineOutlined";
import Status from "./status";
import Uloga from "./uloga";
import { IAzuriranjeNalogaPodaci } from "./interfaces";
import { IData, MoreInfo } from "../tableKorisnickiNalozi/interfaces";
import { AzurirajNalog, PribaviKorisnika } from "./fetch";
import React, { useEffect } from "react";
import { useLocation } from "react-router-dom";
import {
  PrivilegijeBrojUString,
  StatusNalogaBrojUString,
} from "../tableKorisnickiNalozi/tableKorisnickiNalozi";

function Pom(postojeciKorisnickiPodaci: IData) {
  const [korisnickiPodaci, setKorisnickiPodaci] =
    React.useState<IAzuriranjeNalogaPodaci>({
      ime: "",
      prezime: "",
      novoKorisnickoIme: "",
      postojeceKorisnickoIme: "tome",
      email: "",
      statusNaloga: "",
      idBroj: "",
      uloga: "",
      privilegije: "",
      nadlezanZaOblasti: [],
    });

  useEffect(() => {
    setKorisnickiPodaci({
      ime: postojeciKorisnickiPodaci.ime,
      prezime: postojeciKorisnickiPodaci.prezime,
      novoKorisnickoIme: "",
      postojeceKorisnickoIme: postojeciKorisnickiPodaci.korisnickoIme,
      email: postojeciKorisnickiPodaci.email,
      statusNaloga: StatusNalogaBrojUString(
        postojeciKorisnickiPodaci.statusNaloga
      ),
      idBroj:
        postojeciKorisnickiPodaci.uloga === 0
          ? postojeciKorisnickiPodaci.history[0].data
          : "",
      uloga: UlogaObrada(postojeciKorisnickiPodaci.uloga),
      privilegije:
        postojeciKorisnickiPodaci.uloga === 0
          ? postojeciKorisnickiPodaci.history[1].data
          : "",
      nadlezanZaOblasti:
        postojeciKorisnickiPodaci.uloga === 1
          ? postojeciKorisnickiPodaci.history.map((x: MoreInfo) => x.data)
          : [],
    });
  }, []);

  function handler() {
    console.log("proslednjeno:");
    console.log(postojeciKorisnickiPodaci);
    console.log("dobijeni:");
    console.log(korisnickiPodaci);
  }

  const [tr, setTr] = React.useState<{ val: string[]; all: string[] }>({
    val: [],
    all: [],
  });

  const formik = useFormik({
    initialValues: {
      ime: postojeciKorisnickiPodaci.ime,
      prezime: postojeciKorisnickiPodaci.prezime,
      korisnickoIme: "",
      postojeceKorisnickoIme: postojeciKorisnickiPodaci.korisnickoIme,
      email: postojeciKorisnickiPodaci.email,
      IDBroj:
        postojeciKorisnickiPodaci.uloga === 0
          ? postojeciKorisnickiPodaci.history[0].data
          : "",
      statusNaloga: StatusNalogaBrojUString(
        postojeciKorisnickiPodaci.statusNaloga
      ),
      uloga: UlogaObrada(postojeciKorisnickiPodaci.uloga),
      privilegije:
        postojeciKorisnickiPodaci.uloga === 0
          ? postojeciKorisnickiPodaci.history[1].data
          : "", //ako je niz pom.reduce((acc, curr, index) => { return (acc += curr === true ? Math.pow(2, index + 1) : 0);      }, 0);
      oblasti:
        postojeciKorisnickiPodaci.uloga === 1
          ? postojeciKorisnickiPodaci.history.map((x: MoreInfo) => x.data)
          : [],
    },
    onSubmit: (values) => {
      AzurirajNalog({
        ime: values.ime,
        prezime: values.prezime,
        novoKorisnickoIme: values.korisnickoIme,
        postojeceKorisnickoIme: values.postojeceKorisnickoIme,
        email: values.email,
        statusNaloga: values.statusNaloga,
        idBroj: values.IDBroj,
        uloga: values.uloga,
        privilegije:
          typeof values.privilegije === "string"
            ? "1" //(values.privilegije===0)?1: uvek ako je str je 1
            : ObradaNiza(values.privilegije),
        nadlezanZaOblasti: tr.val !== [] ? ObradiOblasti(tr.val, tr.all) : [],
      });
    },
  });

  const classes = useStyles();
  return (
    <form onSubmit={formik.handleSubmit}>
      <Button onClick={() => handler()}>dugme</Button>

      <Box className={classes.containerTF}>
        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="ime"
            label="Ime"
            name="ime"
            autoFocus
            value={formik.values.ime}
            onChange={formik.handleChange}
          />
        </Box>

        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="prezime"
            label="Prezime"
            name="prezime"
            value={formik.values.prezime}
            onChange={formik.handleChange}
          />
        </Box>
        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="korisnickoIme"
            label="Korisničko ime"
            name="korisnickoIme"
            value={formik.values.korisnickoIme}
            onChange={formik.handleChange}
          />
        </Box>
        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="email"
            label="email"
            name="email"
            value={formik.values.email}
            onChange={formik.handleChange}
          />
        </Box>
        {Status(classes, formik.handleChange)}
      </Box>
      {Uloga(classes, formik.handleChange, korisnickiPodaci, tr, setTr)}

      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        className={classes.submit}
      >
        Izmeni nalog
      </Button>
    </form>
  );
}

export default function AccUpdate() {
  const location = useLocation();
  const postojeciKorisnickiPodaci = location.state as IData;
  const classes = useStyles();

  return (
    <Box className={classes.root}>
      <Container component="main" className={classes.forma}>
        <CssBaseline />
        <Box className={classes.paper}>
          <Avatar className={classes.avatar}>
            <PersonOutlineOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5" className={classes.prijava}>
            Izmena korisničkog naloga: {postojeciKorisnickiPodaci.ime}
            <Box>{Pom(postojeciKorisnickiPodaci)}</Box>
          </Typography>
        </Box>
      </Container>
    </Box>
  );
}
function ObradiOblasti(val: string[], all: string[]): string[] {
  const pom: string[] = all.filter((x) => {
    let pom = false;
    val.forEach((el) => {
      const duzina = el.length;
      if (duzina <= x.length)
        if (x.slice(0, duzina) === el) {
          pom = true;
        }
      return;
    });
    return pom;
  });
  return pom.map((x) => x.substring(0, x.length - 1));
}

function ObradaNiza(privilegije: any): string {
  const val = Array.isArray(privilegije)
    ? privilegije.reduce((acc, curr, index) => {
        return (acc += Number(curr));
      }, 0)
    : 1;
  return (val === 0 ? 1 : val).toString();
}

function UlogaObrada(val: number) {
  let a: string;
  switch (val) {
    case 0:
      a = "Osnovni_Korisnik";
      break;
    case 1:
      a = "Napredni_Korisnik";
      break;
    case 2:
      a = "Administrator";
      break;
    default:
      a = "greska";
      break;
  }
  return a;
}