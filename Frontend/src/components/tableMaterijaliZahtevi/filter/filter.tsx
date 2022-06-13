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
import { IFilter, opcije } from "./filterInterfaces";
import DateFnsUtils from "@date-io/date-fns";
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
  KeyboardTimePicker,
} from "@material-ui/pickers";
import "date-fns";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

export default function Filter(
  openFilter: boolean,
  setOpenFilter: (a: boolean) => void,
  selectedTip: string,
  setSelectedTip: Function,
  selectedNameAutor: string,
  setSelectedNameAutor: Function,
  selectedPutanja: string,
  setSelectedPutanja: Function,
  selectedNazivMaterijala: string,
  setSelectedNazivMaterijala: Function,
  selectedEkstenzijaMaterijala: string,
  setSelectedEkstenzijaMaterijala: Function,
  selectedDate1: Date | null,
  setSelectedDate1: Function,
  selectedDate2: Date | null,
  setSelectedDate2: Function,
  primeniFilterPotvrda: boolean,
  setPrimeniFilterPotvrda: Function
) {
  const handleClose = () => {
    setOpenFilter(false);
  };

  const handleCloseNot = () => {
    setSelectedTip("");
    setSelectedNameAutor("");
    setSelectedPutanja("");
    setSelectedNazivMaterijala("");
    setSelectedEkstenzijaMaterijala("");
    setSelectedDate1(null);
    setSelectedDate2(null);
    setOpenFilter(false);
  };
  //////////

  const handleDateChange1 = (date: Date | null) => {
    setSelectedDate1(date);
  };

  const handleDateChange2 = (date: Date | null) => {
    setSelectedDate2(date);
  };
  ////////

  return (
    <Box>
      <Dialog
        TransitionComponent={Transition} //dodati u HOME!!!!
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
              id="name"
              label="Korisničko ime autora"
              type="naziv"
              fullWidth
              value={selectedNameAutor}
              onChange={(e) => setSelectedNameAutor(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="putanja"
              label="Putanja oblasti"
              type="naziv"
              fullWidth
              value={selectedPutanja}
              onChange={(e) => setSelectedPutanja(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="naziv"
              label="Naziv materijala"
              type="naziv"
              fullWidth
              value={selectedNazivMaterijala}
              onChange={(e) => setSelectedNazivMaterijala(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <TextField
              autoFocus
              margin="dense"
              id="ekstenzija"
              label="Ekstenzija materijala"
              type="naziv"
              fullWidth
              value={selectedEkstenzijaMaterijala}
              onChange={(e) => setSelectedEkstenzijaMaterijala(e.target.value)}
            />
          </Box>
          <Box padding="5px" paddingLeft="0px">
            <Autocomplete //po tipu zahteva
              // multiple
              fullWidth={false}
              id="tags-standard"
              options={opcije}
              getOptionLabel={(option) => `${option.name}`}
              inputValue={selectedTip}
              onInputChange={(event, newInputValue) => {
                setSelectedTip(newInputValue);
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Tip materijala"
                />
              )}
            />
            {MaterialUIPickers(
              handleDateChange1,
              handleDateChange2,
              selectedDate1,
              selectedDate2
            )}
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

function MaterialUIPickers(
  handleDateChange1: any,
  handleDateChange2: any,
  selectedDate1: any,
  selectedDate2: any
) {
  // The first commit of Material-UI

  return (
    <MuiPickersUtilsProvider utils={DateFnsUtils}>
      <Grid container>
        <KeyboardDatePicker
          disableToolbar
          variant="inline"
          format="MM/dd/yyyy"
          margin="normal"
          id="date-picker-inline"
          label="Date picker inline"
          value={selectedDate1}
          onChange={handleDateChange1}
          KeyboardButtonProps={{
            "aria-label": "change date",
          }}
        />
        <KeyboardDatePicker
          margin="normal"
          id="date-picker-dialog"
          label="Date picker dialog"
          format="MM/dd/yyyy"
          value={selectedDate2}
          onChange={handleDateChange2}
          KeyboardButtonProps={{
            "aria-label": "change date",
          }}
        />
      </Grid>
    </MuiPickersUtilsProvider>
  );
}
