import React from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { classicNameResolver } from 'typescript';
import { Box } from '@material-ui/core';

export default function ComboBox(values:number[],classes:any,pagenum:Function) {
    const handleChange= (event: any,value:any) => {
        pagenum(value);
      };
    return (
    <Autocomplete
      id="combo-box-demo"
      className={classes.combo}
      options={values}
      defaultValue={values[1]}
      onChange={handleChange}
      getOptionLabel={(option) => option.toString()}
      renderInput={(params) => <TextField {...params} label="Broj prikaza" variant="outlined" />}
    />
  );
}