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
import { IFilterTip, opcijeTip } from "./filterInterfaces";
import { TransitionProps } from "@material-ui/core/transitions";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

//status
//putanja
//ukupna ocena

export default function Filter(
  openFilter: boolean,
  setOpenFilter: (a: boolean) => void,
  selectedExtension: string,
  setSelectedExtension: (a: string) => void,
  selectedName: string,
  setSelectedName: (a: string) => void,
  selectedOcena:string[],
  setSelectedOcena:(a:string[])=>void
) {
  const handleClose = () => {
    setOpenFilter(false);
  };

  const handleCloseNot = () => {
    setSelectedExtension("");
    setSelectedName("");
    setSelectedOcena(["",""])
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
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="name"
              label="Naziv materijala"
              type="naziv"
              // fullWidth
              value={selectedName}
              onChange={(e) => setSelectedName(e.target.value)}
            />
            <Box>
            <TextField
              autoFocus
              margin="dense"
              id="od"
              label="Od ocene"
              type="number"
              // fullWidth
              value={selectedOcena[0]}
              onChange={(e) => setSelectedOcena([e.target.value,selectedOcena[1]])}
            />     <TextField
            autoFocus
            margin="dense"
            id="do"
            label="Do ocene"
            type="number"
            // fullWidth
            value={selectedOcena[1]}
            onChange={(e) => setSelectedOcena([selectedOcena[0],e.target.value])}
          />
            </Box>
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <Autocomplete
              // multiple
              fullWidth={false}
              id="tags-standard"
              options={opcijeTip}
              getOptionLabel={(option) =>
                `${option.name} (${option.extension})`
              }
              inputValue={selectedExtension}
              onInputChange={(event, newInputValue) => {
                setSelectedExtension(newInputValue);
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Tip materijala"
                />
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
      {selectedExtension + "" + selectedName}
    </Box>
  );
}
