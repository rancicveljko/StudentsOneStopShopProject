import {
  Box,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
} from "@material-ui/core";
import React from "react";

export default function Status(classes: any, handle: Function) {
  const [selectedValue, setSelectedValue] = React.useState("Aktivan");
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSelectedValue(event.target.value);
    handle(event);
  };
  return (
    <Box className={classes.TF}>
      <FormControl component="fieldset" style={{ float: "left" }}>
        <FormLabel component="legend">Status korisnika</FormLabel>
        <RadioGroup
          row={false}
          onChange={handleChange}
          aria-label="position"
          name="position"
          defaultValue="end"
        >
          <Box display="flex">
            <FormControlLabel
              checked={selectedValue === "Aktivan"}
              control={<Radio color="primary" />}
              value="Aktivan"
              label="Aktivan"
              name="statusNaloga"
              //inputProps={{ "aria-label": "Aktivan" }}
            />

            <FormControlLabel
              checked={selectedValue === "Blokiran"}
              control={<Radio color="primary" />}
              value="Blokiran"
              label="Blokiran"
              name="statusNaloga"
              //inputProps={{ "aria-label": "Blokiran" }}
            />

            <FormControlLabel
              checked={selectedValue === "Obrisan"}
              control={<Radio color="primary" />}
              value="Obrisan"
              label="Obrisan"
              name="statusNaloga"
              // inputProps={{ "aria-label": "Obrisan" }}
            />
          </Box>
        </RadioGroup>
      </FormControl>
    </Box>
  );
}
