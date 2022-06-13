import {
  Box,
  Checkbox,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@material-ui/core";
import React from "react";

export default function Privilegija(
  classes: any,
  hadle: Function,
  tipNaloga: string, //iygleda ne treba
  disable: boolean,
  setDisable: Function,
  checked: boolean[],
  setChecked: Function,
  selectedValue: number,
  setSelectedValue: Function
) {
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    let tr: number = parseInt(event.target.value);
    if (tr === 1) {
      setSelectedValue(1);
      setChecked([false, false, false]);
      setDisable(true);
      event.target.value = "1";
      hadle(event);
    } else {
      setDisable(false);
      setSelectedValue(0);

      event.target.value = "0";
      hadle(event);
    }
  };

  const handleChangeCB = (event: React.ChangeEvent<HTMLInputElement>) => {
    let pom = checked;
    let i = parseInt(event.target.id);
    pom[i] = !pom[i];
    setChecked(pom);
    let val: number = pom.reduce((acc, curr, index) => {
      return (acc += curr === true ? Math.pow(2, index + 1) : 0);
    }, 0);

    setSelectedValue(val);
    let v: string = val.toString();

    event.target.name = "privilegije";
    ///console.log(v);
    ///console.log(event.target.value);
    //  event.target.value = pom.toString();
    ///console.log(event.target.value);

    hadle(event);
  };

  return (
    <Box>
      <FormControl component="fieldset" style={{ float: "left" }}>
        <FormLabel component="legend">Privilegije korisnika</FormLabel>
        <RadioGroup
          row
          onChange={handleChange}
          aria-label="position"
          name="privilegije"
          defaultValue="end"
        >
          <Box>
            <FormControlLabel
              checked={selectedValue === 1}
              control={<Radio color="primary" />}
              value={1}
              label="Bez zabrana"
              name="privilegije"
              //inputProps={{ "aria-label": "Aktivan" }}
            />
          </Box>
          <Box display="flex" flexDirection="column" justifyContent="start">
            <FormControlLabel
              checked={selectedValue !== 1}
              control={<Radio color="primary" />}
              value={0}
              label="Zabrane"
              name="privilegije"
              //inputProps={{ "aria-label": "Blokiran" }}
            />
            <Box
              display="flex"
              flexDirection="column"
              justifyContent="strech"
              justifySelf="start"
            >
              <Box className={classes.ZabraneCB}>
                <FormControlLabel
                  className={classes.ZabranaOneCB}
                  control={
                    <Checkbox
                      disabled={disable}
                      checked={checked[0]}
                      id="0"
                      onChange={handleChangeCB}
                      name="privilegije"
                      inputProps={{ "aria-label": "primary checkbox" }}
                      value={2}
                    />
                  }
                  label="Zabrana komentarisanja"
                />
              </Box>

              <Box className={classes.ZabraneCB}>
                <FormControlLabel
                  className={classes.ZabranaOneCB}
                  control={
                    <Checkbox
                      disabled={disable}
                      checked={checked[1]}
                      id="1"
                      onChange={handleChangeCB}
                      name="privilegije"
                      inputProps={{ "aria-label": "primary checkbox" }}
                      value={4}
                    />
                  }
                  label="Zabrana ocenjivanja"
                />
              </Box>
              <Box className={classes.ZabraneCB}>
                <FormControlLabel
                  className={classes.ZabranaOneCB}
                  control={
                    <Checkbox
                      disabled={disable}
                      checked={checked[2]}
                      id="2"
                      onChange={handleChangeCB}
                      name="privilegije"
                      inputProps={{ "aria-label": "primary checkbox" }}
                      value={8}
                    />
                  }
                  label="Zabrana dodavanja materijala"
                />
              </Box>
            </Box>
          </Box>
        </RadioGroup>
      </FormControl>
      <Box className={classes.TF}>
        <TextField
          variant="outlined"
          margin="normal"
          fullWidth
          id="IDBroj"
          label="IDBroj"
          name="IDBroj"
          //value={values.korisnickoIme}
          onChange={(e) => hadle(e)}
        />
      </Box>
    </Box>
  );
}
