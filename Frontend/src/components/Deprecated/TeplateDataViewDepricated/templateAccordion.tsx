import useStyles from "./templateDataViewStyles";
import React from "react";
import Accordion from "@material-ui/core/Accordion";
import AccordionSummary from "@material-ui/core/AccordionSummary";
import AccordionDetails from "@material-ui/core/AccordionDetails";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import TemplateAccordionDetails from "./templateAccordionDetails";
import { Info } from "./templateDataViewInterfaces";
import { Box } from "@material-ui/core";

function genStates(st: string[], ex: boolean[], len: number) {
  if (st[0] === "starter" && st.length === 1) {
    st[0] = "null";
    for (let i = 0; i < len - 2; i++) {
      st.push("null");
      ex.push(false);
    }
  }
}

export default function ActionsInAccordion(
  cbAll: Function,
  cbOneValue: Function,
  pagelen: number,
  offset: number
) {
  function fetchState(
    offset: number,
    pageLen: number,
    index: number,
    cb: Function
  ) {
    const val = cb(offset, pageLen, index);
    if (val !== state[index]) {
      const niz = state.map((x: string, i) => (i === index ? (x = val) : x));
      setState(niz);
      expand[index] = !expand[index];
    }
  }

  const classes = useStyles();
  const [state, setState] = React.useState(["starter"]);
  const [expand, setExpand] = React.useState([false]);
  return cbAll().map((x: Info[], index: number) => {
    genStates(state, expand, x.length);
    return (
      <Accordion expanded={expand[index]}>
        <AccordionSummary
          expandIcon={<ExpandMoreIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
          onClick={(event) => {
            event.stopPropagation();
            fetchState(pagelen, offset, index, cbOneValue); //mozda sa usestate
            // alert("click on expand");
          }}
        >
          <Typography className={classes.AccordionRoot}>
            Zahtev {index + 1}
          </Typography>
        </AccordionSummary>
        <AccordionDetails>
          {TemplateAccordionDetails(state[index])}
        </AccordionDetails>
      </Accordion>
    );
  });
}
