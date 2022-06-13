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
import useStyles from "./accSelfUpdateStyles";
import PersonOutlineOutlinedIcon from "@material-ui/icons/PersonOutlineOutlined";
import { AzurirajSvojNalog, PribaviKorisnika } from "./fetches";
import { useHistory } from "react-router-dom";
import { IAzuriranjeSvogNalogaPodaci } from "./interfaces";
import React, { useEffect } from "react";

function Pom(trKorisnickoIme: string) {
  const [azuriranjeSvogNalogaPodaci, setAzuriranjeSvogNalogaPodaci] =
    React.useState<IAzuriranjeSvogNalogaPodaci>({
      korisnickoIme: trKorisnickoIme,
      lozinka: "",
      novaLozinka: "",
      email: "",
    });

  useEffect(() => {
    PribaviKorisnika(trKorisnickoIme, setAzuriranjeSvogNalogaPodaci);
  }, []);

  const history = useHistory();
  const formik = useFormik({
    initialValues: {
      KorisnickoIme: azuriranjeSvogNalogaPodaci.korisnickoIme,
      Lozinka: azuriranjeSvogNalogaPodaci.lozinka,
      NovaLozinka: azuriranjeSvogNalogaPodaci.novaLozinka,
      Email: azuriranjeSvogNalogaPodaci.email,
    },
    onSubmit: (values) => {
      alert(JSON.stringify(values, null, 2));

      AzurirajSvojNalog(
        {
          korisnickoIme: values.KorisnickoIme,
          lozinka: values.Lozinka,
          novaLozinka: values.NovaLozinka,
          email: values.Email,
        },
        history
      );
    },
  });

  const classes = useStyles();
  return (
    <form onSubmit={formik.handleSubmit}>
      <Box className={classes.containerTF}>
        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="korisnickoIme"
            label="Novo korisničko ime"
            name="KorisnickoIme"
            autoFocus
            value={formik.values.KorisnickoIme}
            onChange={formik.handleChange}
          />
        </Box>

        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            id="email"
            label="Email"
            name="Email"
            value={formik.values.Email}
            onChange={formik.handleChange}
          />
        </Box>

        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            name="NovaLozinka"
            label="Nova šifra"
            type="password"
            id="password"
            value={formik.values.NovaLozinka}
            onChange={formik.handleChange}
          />
        </Box>
        <Box className={classes.TF}>
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            name="Lozinka"
            label="Stara šifra"
            type="password"
            id="password"
            value={formik.values.Lozinka}
            onChange={formik.handleChange}
          />
        </Box>
      </Box>

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

export default function AccSelfUpdate(/*trKorisnickoIme:string proslediti kad se popziva*/) {
  let trKorisnickoIme = "SDTRghiorwkthbkiormergh";

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
            Izmena korisničkog naloga: {trKorisnickoIme}
            <Box>{Pom(trKorisnickoIme)}</Box>
          </Typography>
        </Box>
      </Container>
    </Box>
  );
}
