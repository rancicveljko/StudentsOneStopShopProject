import React from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import { Box, Divider, Typography } from "@material-ui/core";

import AddCommentOutlinedIcon from "@material-ui/icons/AddCommentOutlined";
import CancelOutlinedIcon from "@material-ui/icons/CancelOutlined";

export function NewComment(
  openNewComment: boolean,
  setOpenNewComment: (a: boolean) => void,
  tekstNewComment: string,
  setTekstNewComment: (a: string) => void, //eventualno da ide u new komenata
  handleNewComment: (a: void) => void,
  classes: any
) {
  const handleClose = () => {
    setOpenNewComment(false);
    setTekstNewComment("");
  };

  return (
    <div>
      <Dialog
        open={openNewComment}
        onClose={handleClose}
        aria-labelledby="form-dialog-title"
      >
        <Box className={classes.NewComment}>
          <Box padding="15px" paddingBottom="10px">
            <Typography variant="h6">Nov komentar</Typography>
            {/* <Divider /> */}

            <Divider />
          </Box>
          <DialogContent>
            <TextField
              autoFocus
              margin="dense"
              id="name"
              label="Tekst komentara"
              type="text"
              value={tekstNewComment}
              onChange={(e) => {
                setTekstNewComment(e.target.value);
              }}
              fullWidth
            />
          </DialogContent>
          <DialogActions>
            <Box display="flex" justifyContent="space-around" width="100%">
              <Button
                variant="outlined"
                color="primary"
                startIcon={<AddCommentOutlinedIcon />}
                onClick={() => {
                  handleNewComment();
                  setOpenNewComment(false);
                }}
              >
                Komentariši
              </Button>
            </Box>

            <Box>
              <Button
                variant="outlined"
                color="primary"
                startIcon={<CancelOutlinedIcon />}
                //type="submit"
                onClick={() => {
                  handleClose();
                }}
              >
                Odustani
              </Button>
            </Box>
          </DialogActions>
        </Box>
      </Dialog>
    </div>
  );
}
