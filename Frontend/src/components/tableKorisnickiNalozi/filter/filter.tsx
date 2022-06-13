import React from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import { Box, Grid, Slide } from "@material-ui/core";
import { TransitionProps } from "@material-ui/core/transitions";
import { Autocomplete } from "@material-ui/lab";
import { IFilter, opcijeStatusNaloga, opcijeUloga } from "./filterInterfaces";
import DateFnsUtils from "@date-io/date-fns";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

export default function Filter(
  openFilter: boolean,
  setOpenFilter: (a: boolean) => void,

  selectedUsername: string,
  setSelectedUsername: Function,
  selectedUloga: string,
  setSelectedUloga: Function,
  selectedStatusNaloga: string,
  setSelectedStatusNaloga: Function,
  primeniFilterPotvrda: boolean,
  setPrimeniFilterPotvrda: Function
) {
  const handleClose = () => {
    setOpenFilter(false);
  };

  const handleCloseNot = () => {
    setSelectedUloga("");
    setSelectedStatusNaloga("");
    setSelectedUsername("");
    setOpenFilter(false);
  };
  return (
    <Box>
      <Dialog
        TransitionComponent={Transition}
        open={openFilter}
        onClose={handleCloseNot}
        aria-labelledby="form-dialog-titleF"
      >
        <DialogTitle
          style={{ paddingBottom: "0px", marginBottom: "0px" }}
          id="form-dialog-titleF"
        >
          Filter
        </DialogTitle>
        <DialogContent>
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="username"
              label="Korisničko ime"
              type="KorisnickoIme"
              fullWidth
              value={selectedUsername}
              onChange={(e) => setSelectedUsername(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <Autocomplete //po tipu zahteva
              // multiple
              fullWidth={false}
              id="tags-standard"
              options={opcijeUloga}
              getOptionLabel={(option) => `${option.opis}`}
              inputValue={selectedUloga}
              onInputChange={(event, newInputValue) => {
                setSelectedUloga(newInputValue);
              }}
              renderInput={(params) => (
                <TextField {...params} variant="standard" label="Tip naloga" />
              )}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <Autocomplete //po tipu zahteva
              // multiple
              fullWidth={false}
              id="tags-standard"
              options={opcijeStatusNaloga}
              getOptionLabel={(option) => `${option.opis}`}
              inputValue={selectedStatusNaloga}
              onInputChange={(event, newInputValue) => {
                setSelectedStatusNaloga(newInputValue);
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Status naloga"
                />
              )}
            />
          </Box>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseNot} color="primary">
            Otkaži
          </Button>
          <Button
            onClick={() => {
              setPrimeniFilterPotvrda(!primeniFilterPotvrda);
              handleClose();
            }}
            color="primary"
          >
            Primeni filter
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
}
