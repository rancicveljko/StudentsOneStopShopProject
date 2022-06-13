import { Autocomplete } from "@material-ui/lab";
import { TextField } from "@material-ui/core";
import { FetchAllOblastiLista } from "./fetch";
import { useEffect } from "react";

export default function ComboBox(
  oblastiSve: string[],
  setOblastiSve: (a: string[]) => void,
  oblastSelected: string[],
  setOblastSelected: (a: string[]) => void
) {
  if (oblastiSve.length === 0) FetchAllOblastiLista(setOblastiSve);//eventualno da se izbaci unapred s use effect

  return (
    <Autocomplete
      id="cb"
      options={oblastiSve}
      //value={selectedVal}mozda ce potreba
      onInputChange={(event, newInputValue) =>
        setOblastSelected([...oblastSelected, newInputValue])
      }
      getOptionLabel={(option) => option}
      renderInput={(params) => (
        <TextField {...params} label="Oblast" variant="outlined" required />
      )}
    />
  );
}
