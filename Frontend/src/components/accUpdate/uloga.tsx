import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  Typography,
} from "@material-ui/core";
import React from "react";
import { IAzuriranjeNalogaPodaci } from "./interfaces";
import Privilegija from "./privilegija";
import ComboB from "./combobox";

export default function Uloga(
  classes: any,
  handle: Function,
  par: IAzuriranjeNalogaPodaci,
  tr: { val: string[]; all: string[] },
  setTr: Function
) {
  console.log(par.uloga);
  const [selectedValue, setSelectedValue] = React.useState(par.uloga);
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSelectedValue(event.target.value);
    handle(event);
    if (event.target.value !== "Napredni_Korisnik") tr.val = [];
  };

  /////za privilegiju
  const [disable, setDisable] = React.useState(true);
  const [checked, setChecked] = React.useState([false, false, false]);
  const [selectedValuePriv, setSelectedValuePriv] = React.useState(1);
  /////
  ///za oblasti
  const [values, setValues] = React.useState([""]);
  tr.val = values;
  ////

  return (
    <Box display="flex">
      <Box className={classes.TF}>
        <Box display="flex" alignItems="center">
          <Radio
            checked={selectedValue === "Osnovni_Korisnik"}
            color="primary"
            value="Osnovni_Korisnik"
            onChange={handleChange}
            name="uloga"
            inputProps={{ "aria-label": "Osnovni korisnik" }}
          />
          <Typography>Osnovni korisnik</Typography>
        </Box>
        <Box display="flex" alignItems="center">
          <Radio
            checked={selectedValue === "Napredni_Korisnik"}
            color="primary"
            value="Napredni_Korisnik"
            onChange={handleChange}
            name="uloga"
            inputProps={{ "aria-label": "Napredni korisnik" }}
          />
          <Typography>Napredni korisnik</Typography>
        </Box>
        <Box display="flex" alignItems="center">
          <Radio
            checked={selectedValue === "Administrator"}
            color="primary"
            value="Administrator"
            onChange={handleChange}
            name="uloga"
            inputProps={{ "aria-label": "Administrator" }}
          />
          <Typography>Administrator</Typography>
        </Box>
      </Box>
      <Box width="30vw" padding="3%" marginLeft="0.5vw">
        {selectedValue === "Osnovni_Korisnik"
          ? Privilegija(
              classes,
              handle,
              par.uloga,
              disable,
              setDisable,
              checked,
              setChecked,
              selectedValuePriv,
              setSelectedValuePriv
            )
          : selectedValue === "Napredni_Korisnik"
          ? ComboB(classes, setValues, values, handle, tr, setTr)
          : null}
      </Box>
    </Box>
  );
}
