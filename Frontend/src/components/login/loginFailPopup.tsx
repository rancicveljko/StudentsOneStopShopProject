import React from "react";
import Button from "@material-ui/core/Button";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import { TransitionProps } from "@material-ui/core/transitions";
import { Box, CircularProgress } from "@material-ui/core";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});
//mozda da se zameni sa error snackbar
export default function AlertDialogSlide(
  lozinkaErrorMsg: string,
  korisnickoImeErrorMsg: string,
  open: boolean,
  setOpen: Function,
  loading: boolean
) {
  //   const [open, setOpen] = React.useState(false);

  //   const handleClickOpen = () => {
  //     setOpen(true);
  //   };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Dialog
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={() => handleClose()} //mozda ne treba
        aria-labelledby="alert-dialog-slide-title"
        aria-describedby="alert-dialog-slide-description"
      >
        <Box style={{ minWidth: 81, minHeight: 80 }}>
          {(loading && (
            <Box>
              <CircularProgress
                style={{ width: 80, height: 80, margin: "20px" }}
              />
            </Box>
          )) || (
            <Box>
              <DialogContent>
                <DialogContentText id="alert-dialog-slide-description">
                  {lozinkaErrorMsg + "\n" + korisnickoImeErrorMsg}
                </DialogContentText>
              </DialogContent>
              <DialogActions>
                <Button onClick={() => handleClose()} color="primary">
                  Ok
                </Button>
              </DialogActions>
            </Box>
          )}
        </Box>
      </Dialog>
    </div>
  );
}
