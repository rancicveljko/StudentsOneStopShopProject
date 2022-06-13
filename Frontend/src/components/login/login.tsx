import { useFormik } from "formik";
import {
  Box,
  Container,
  TextField,
  AppBar,
  Button,
  CssBaseline,
  Avatar,
  Typography,
  Checkbox,
} from "@material-ui/core";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import useStyles from "./loginStyles";
import PrijaviSe, { ProveraCookie } from "./fetch";
import { useHistory } from "react-router-dom";
import React from "react";
import AlertDialogSlide from "./loginFailPopup";
import { useEffect } from "react";

function Pom(history: any) {
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
      ZapamtiMe: false,
    },
    onSubmit: (values) => {
      PrijaviSe(
        values.email,
        values.password,
        values.ZapamtiMe,
        history,
        handleErrorPopupClickOpen,
        setErrorPopupOpen,
        setLoading
      );
    },
  });

  useEffect(() => {
    ProveraCookie(
      history,
      handleErrorPopupClickOpen,
      setErrorPopupOpen,
      setLoading
    );
  }, []);

  const [popUpData, setPopUpData] = React.useState<string[]>(["", ""]);
  //////popup
  const [errorPopupOpen, setErrorPopupOpen] = React.useState(false);
  function handleErrorPopupClickOpen(KorisnickoIme: string, Lozinka: string) {
    setPopUpData([KorisnickoIme, Lozinka]);
    setErrorPopupOpen(true);
  }
  /////
  ///////////////////////////////treba fju za proveru da l ima cookie ako ima odma na home

  //loader
  const [loading, setLoading] = React.useState(false);
  ///

  const classes = useStyles();
  return (
    <form onSubmit={formik.handleSubmit}>
      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        id="email"
        label="Korisničko ime"
        name="email"
        autoFocus
        value={formik.values.email}
        onChange={formik.handleChange}
        // error={formik.touched.email && Boolean(formik.errors.email)}
        helperText={formik.touched.email && formik.errors.email}
      />

      <TextField
        variant="outlined"
        margin="normal"
        required
        fullWidth
        name="password"
        label="Šifra"
        type="password"
        id="password"
        autoComplete="current-password"
        value={formik.values.password}
        onChange={formik.handleChange}
        //error={formik.touched.password && Boolean(formik.errors.password)}
        helperText={formik.touched.password && formik.errors.password}
      />

      <Typography variant="body2">
        <Checkbox
          name="ZapamtiMe"
          id="Zapamti me"
          checked={formik.values.ZapamtiMe}
          onChange={formik.handleChange}
          inputProps={{ "aria-label": "primary checkbox" }}
        />
        Zapamti me
      </Typography>

      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        className={classes.submit}
      >
        Prijavi se
      </Button>

      {AlertDialogSlide(
        popUpData[0],
        popUpData[1],
        errorPopupOpen,
        setErrorPopupOpen,
        loading
      )}
    </form>
  );
}

function Login() {
  const history = useHistory();
  //alert("popup pogresna sifra")
  const classes = useStyles();
  return (
    <Box className={classes.root}>
      <AppBar position="sticky" className={classes.naslov}>
        DOBRODOŠLI!
      </AppBar>
      <Container component="main" maxWidth="xs" className={classes.forma}>
        <CssBaseline />
        <Box className={classes.paper}>
          <Avatar className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5" className={classes.prijava}>
            Prijava
            {Pom(history)}
          </Typography>
        </Box>
      </Container>
    </Box>
  );
}
export default Login;
