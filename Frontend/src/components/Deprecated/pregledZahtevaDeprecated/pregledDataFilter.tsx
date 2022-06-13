import React from "react";
import Autocomplete from "@material-ui/lab/Autocomplete";
import { TextField } from "@material-ui/core";
import { Typography } from "@material-ui/core";

export default function Filter(values: string[], classes: any, cb: Function) {
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    cb([event.target.id.toString(),event.target.value.toString()],values.length);
  };
  let svi = [];
  svi.push(<Typography>Filtriranje:</Typography>)
  for (let i = 0; i < values.length; i++) {
    svi.push(
      <TextField
      className={classes.filter}
        variant="outlined"
        margin="normal"
        fullWidth
        id={i.toString()}
        label={values[i]}
        name={i.toString()}
        onChange={handleChange}
        // error={formik.touched.email && Boolean(formik.errors.email)}
        //helperText={formik.touched.email && formik.errors.email}
      />
    );
  }
  return svi;
}
