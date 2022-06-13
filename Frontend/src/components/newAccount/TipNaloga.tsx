import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@material-ui/core";
import useStyles from "./newAccountStyles";
import ComboBox from "./comboBox";
import { useEffect } from "react";
import { FetchAllOblastiLista } from "./fetch";

function Tip(valueTip: string,oblastiSve:string[], setOblastiSve: (a: string[]) => void,oblastSelected:string[], setOblastSelected: (a: string[]) => void,idBroj:string,setIdBroj: (a: string) => void) {
  const classes = useStyles();

  return (<Box >
    {(valueTip === "OsnovniKorisnik" && Osnovni(idBroj,setIdBroj)) || Napredni(oblastiSve, setOblastiSve,oblastSelected, setOblastSelected)}</Box>
  );
}

function Osnovni(idBroj:string,setIdBroj: (a: string) => void) {
  return (
    <Box>
      <TextField
        variant="outlined"
        required
        fullWidth
        id="id"
        label="ID korisnika"
        name="id"
        onChange={(event)=>setIdBroj(event.target.value)}
        value={idBroj}
      />
    </Box>
  );
}

function Napredni(oblastiSve:string[], setOblastiSve: (a: string[]) => void,oblastSelected:string[], setOblastSelected: (a: string[]) => void) {
  return <Box>{ComboBox(oblastiSve, setOblastiSve,oblastSelected, setOblastSelected)}</Box>;
}

export default function TipNaloga(
  valueTip: string,
  setValueTip: (a: string) => void,
  oblastiSve: string[],
  setOblastiSve: (a: string[]) => void,
  oblastSelected: string[],
  setOblastSelected: (a: string[]) => void,
  idBroj:string,
   setIdBroj:(a: string) => void
) {
  // const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
  //   setValueTip((event.target as HTMLInputElement).value);
  // };

  return (
    <Box>
      <FormControl component="fieldset">
        <FormLabel component="legend">Tip naloga</FormLabel>
        <RadioGroup aria-label="Nalog" value={valueTip} onChange={(e)=>setValueTip(e.target.value)}>
          <FormControlLabel
            value="OsnovniKorisnik"
            control={<Radio />}
            label="Osnovni nalog"
          />
          <FormControlLabel
            value="NapredniKorisnik"
            control={<Radio />}
            label="Napredni nalog"
          />
        </RadioGroup>
      </FormControl>
      <Box>{Tip(valueTip,oblastiSve, setOblastiSve,oblastSelected, setOblastSelected,idBroj,setIdBroj)}</Box>
    </Box>
  );
}
