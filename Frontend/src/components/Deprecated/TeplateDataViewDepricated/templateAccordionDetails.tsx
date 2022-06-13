import { Box, Button, Typography } from "@material-ui/core";
import React, { useState } from "react";
import useStyles from "./templateDataViewStyles";

export default function TemplateAccordionDetails(value: string) {
  const classes = useStyles();
  const [vidljiv, setVidljiv] = useState("visible");
  return (
    <Box visibility={vidljiv}>
      <Typography>{value}</Typography>
      <Box className={classes.ADetailButtons}>
        <Box className={classes.AButtonBox}>
          <Button
            className={classes.AButton}
            onClick={() => {
              setVidljiv("hidden");
            }}
          >
            Prihvati
          </Button>
        </Box>
        <Box className={classes.AButtonBox} >
          <Button
            className={classes.AButton}
            onClick={() => {
              setVidljiv("hidden");
            }}
          >
            Odbij
          </Button>
        </Box>
      </Box>
    </Box>
  );
}
