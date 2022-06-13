import {
  Box,
  Container,
  TextField,
  Button,
  CssBaseline,
  Avatar,
  Typography,
} from "@material-ui/core";
import InsertDriveFileOutlinedIcon from "@material-ui/icons/InsertDriveFileOutlined";
import useStyles from "./uploadStyles";
import React from "react";
import { useEffect } from "react";
import ComboBox from "./combo";
import Uppyy from "./uppy";
import PublishOutlinedIcon from "@material-ui/icons/PublishOutlined";
import AddCircleOutlineOutlinedIcon from "@material-ui/icons/AddCircleOutlineOutlined";
import { FetchAllOblastiLista } from "./fetches";
import { useLocation } from "react-router-dom";
import { IOblast } from "./interface";

function Pom(tipNaloga: string) {
  const [naziv, setNaziv] = React.useState("");
  const [opis, setOpis] = React.useState("");
  const [opisZahteva, setOpisZahteva] = React.useState("");

  const [selectedVal, setSelectedVal] = React.useState<IOblast>({
    path: "",
    odobrenje: false,
  }); //izabrana oblast

  const [oblastiData, setOblastiData] = React.useState<IOblast[]>([
    { path: "", odobrenje: true },
  ]); //oblasti

  useEffect(() => {
    FetchAllOblastiLista(setOblastiData);
  }, []);

  const classes = useStyles();
  return (
    <Box>
      <Box>
        <Box height="10px"></Box>
        <TextField
          variant="outlined"
          margin="normal"
          fullWidth
          required
          id="naziv"
          name="naziv"
          label="Željeni naziv materijala"
          autoFocus
          value={naziv}
          onChange={(e) => setNaziv(e.target.value)}
        />
        <TextField
          variant="outlined"
          margin="normal"
          fullWidth
          required
          id="opis"
          name="opis"
          label="Opis materijala"
          value={opis}
          onChange={(e) => setOpis(e.target.value)}
        />
        {!(tipNaloga === "Administrator" || !selectedVal.odobrenje) && (
          <TextField
            variant="outlined"
            margin="normal"
            fullWidth
            required
            id="opisZahtevae"
            name="opisZahreva"
            label="Opis zahteva"
            value={opisZahteva}
            onChange={(e) => setOpisZahteva(e.target.value)}
          />
        )}
      </Box>
      <Box marginTop="10px">
        {ComboBox(
          classes,
          selectedVal,
          setSelectedVal,
          oblastiData,
          setOblastiData
        )}
      </Box>
      <Box className={classes.Buttons}>
        <Box className={classes.ButtonBox}>
          <Button
            disabled={
              selectedVal.path === "" ||
              naziv === "" ||
              opis === "" ||
              (!(tipNaloga === "Administrator" || !selectedVal.odobrenje) &&
                opisZahteva === "")
            }
            className={classes.Button}
            id="dashboardmodal"
            startIcon={<PublishOutlinedIcon />}
          >
            Izaberite fajl
          </Button>
        </Box>
      </Box>
      <Box>{Uppyy(naziv, opis, selectedVal, opisZahteva)}</Box>
    </Box>
  );
}

export default function Upload() {
  const tipNaloga: string =useLocation().state as string;
  const classes = useStyles();
  return (
    <Box>
      <Container component="main" className={classes.forma}>
        <CssBaseline />
        <Box className={classes.paper}>
          <Avatar className={classes.avatar}>
            <InsertDriveFileOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5" className={classes.prijava}>
            Postavite novi materijal
            {Pom(tipNaloga)}
          </Typography>
        </Box>
      </Container>
    </Box>
  );
}
