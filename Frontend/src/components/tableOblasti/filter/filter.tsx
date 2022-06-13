import React from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import { Box, Slide } from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import { opcijeOdobrenje } from "./filterInterfaces";
import { TransitionProps } from "@material-ui/core/transitions";
import { useEffect } from "react";
import { FetchAllOblastiLista } from "../fetches";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

export default function Filter(
  openFilter: boolean,
  setOpenFilter: (a: boolean) => void,
  selectedPutanja: string,
  setSelectedPutanja: (a: string) => void,
  selectedName: string,
  setSelectedName: (a: string) => void,
  selectedPotrebnoOdobrenje: string,
  setSelectedPotrebnoOdobrenje: (a: string) => void
) {
  const handleClose = () => {
    setOpenFilter(false);
  };

  const [sveOblasti, setSveOblasti] = React.useState([""]);

  useEffect(() => {
    FetchAllOblastiLista(setSveOblasti);
  }, []);

  const handleCloseNot = () => {
    setSelectedPutanja("");
    setSelectedName("");
    setSelectedPotrebnoOdobrenje("");
    setOpenFilter(false);
  };

  return (
    <Box>
      <Dialog
        TransitionComponent={Transition}
        open={openFilter}
        onClose={handleCloseNot}
        aria-labelledby="form-dialog-title"
      >
        <DialogTitle id="form-dialog-title">Filter</DialogTitle>
        <DialogContent>
          <Box padding="5px" paddingLeft="0px" width="300px">
            <Autocomplete
              id="cb"
              options={sveOblasti}
              //value={selectedVal}mozda ce potreba
              onInputChange={(event, newInputValue) =>
                setSelectedPutanja(newInputValue)
              }
              getOptionLabel={(option) => option}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label="Oblast za filter"
                  variant="outlined"
                  fullWidth
                />
              )}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="name"
              label="Naziv oblasti"
              type="naziv"
              fullWidth
              value={selectedName}
              onChange={(e) => setSelectedName(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <Autocomplete
              // multiple
              fullWidth={false}
              id="tags-standard"
              options={opcijeOdobrenje}
              getOptionLabel={(option) => `${option.name}`}
              inputValue={selectedPotrebnoOdobrenje}
              onInputChange={(event, newInputValue) => {
                setSelectedPotrebnoOdobrenje(newInputValue);
              }}
              renderInput={(params) => (
                <TextField {...params} variant="standard" label="Odobrenje" />
              )}
            />
          </Box>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseNot} color="primary">
            Otkaži
          </Button>
          <Button onClick={handleClose} color="primary">
            Primeni filter
          </Button>
        </DialogActions>
      </Dialog>
      {selectedPutanja + "" + selectedName}
    </Box>
  );
}
