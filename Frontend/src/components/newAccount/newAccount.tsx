import { useFormik } from "formik";
import AccountCircleOutlinedIcon from "@material-ui/icons/AccountCircleOutlined";
import {
  Box,
  Container,
  TextField,
  AppBar,
  Button,
  CssBaseline,
  Avatar,
  Typography,
  FormControlLabel,
  Checkbox,
} from "@material-ui/core";
import useStyles from "./newAccountStyles";
import TipNaloga from "./TipNaloga";
import { dataTree } from "./interface";
import React from "react";
import { KreirajKorisnika } from "./fetch";

function Pom() {
  const [valueTip, setValueTip] = React.useState("OsnovniKorisnik");
  const [oblastSelected, setOblastSelected] = React.useState([""]);
  const [oblastiSve, setOblastiSve] = React.useState<string[]>([]);
  const [idBroj, setIdBroj] = React.useState("");

  const formik = useFormik({
    initialValues: {
      ime: "",
      prezime: "",
      email: "",
      idBroj: "",
      data: [],
    },
    onSubmit: (values) => {

      KreirajKorisnika({
        ime: values.ime,
        prezime: values.prezime,
        email: values.email,
        uloga: valueTip,
        idBroj: idBroj,
        PutanjeOblasti: oblastSelected.length!==0?ObradiOblasti(oblastSelected,oblastiSve):[],
      });
    },
  });

  const classes = useStyles();
  return (
    <form onSubmit={formik.handleSubmit} className={classes.top}>
      <Box>
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          id="ime"
          name="ime"
          label="Ime"
          autoFocus
          value={formik.values.ime}
          onChange={formik.handleChange}
        />

        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          id="prezime"
          name="prezime"
          label="Prezime"
          value={formik.values.prezime}
          onChange={formik.handleChange}
        />

        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          id="email"
          label="Email"
          name="email"
          value={formik.values.email}
          onChange={formik.handleChange}
        />
        {TipNaloga(
          valueTip,
          setValueTip,
          oblastiSve,
          setOblastiSve,
          oblastSelected,
          setOblastSelected,
          idBroj,
          setIdBroj
        )}
      </Box>
      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        className={classes.topButton}
      >
        Kreiraj nalog
      </Button>
    </form>
  );
}

export default function NewAccount() {
  const classes = useStyles();
  return (
    <Box className={classes.root}>
      <Container component="main" maxWidth="xs" className={classes.forma}>
        <CssBaseline />
        <Box className={classes.paper}>
          <Avatar className={classes.avatar}>
            <AccountCircleOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5" className={classes.prijava}>
            Novi nalog
            {Pom()}
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