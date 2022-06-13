import React from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";
import { classicNameResolver } from "typescript";
import { Box } from "@material-ui/core";

const values=[10, 15, 20,25];


export default function ComboBox(classes: any, pagenum: Function) {
  const handleChange = (event: any, value: any) => {
    pagenum(value);
  };
  return (
    <Autocomplete
      id="combo-box-demo"
      className={classes.combo}
      options={values}
      defaultValue={values[0]}
      onChange={handleChange}
      getOptionLabel={(option) => option.toString()}
      renderInput={(params) => (
        <TextField {...params} label="Broj prikaza" variant="outlined" />
      )}
    />
  );
}
