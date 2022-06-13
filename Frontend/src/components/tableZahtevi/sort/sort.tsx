import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import Avatar from "@material-ui/core/Avatar";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemAvatar from "@material-ui/core/ListItemAvatar";
import ListItemText from "@material-ui/core/ListItemText";
import DialogTitle from "@material-ui/core/DialogTitle";
import Dialog from "@material-ui/core/Dialog";
import { ISort, SimpleDialogProps } from "./sortInterfaces";
import useStyles from "./sortStyles";
import SortByAlphaIcon from "@material-ui/icons/SortByAlpha";
import DateRangeOutlinedIcon from "@material-ui/icons/DateRangeOutlined";
import { Box, Slide } from "@material-ui/core";
import { TransitionProps } from "@material-ui/core/transitions";

const sorting: ISort[] = [
  { opis: "Korisničko ime autora rastuće",num:0, icon: <SortByAlphaIcon /> },
  { opis: "Korisničko ime autora opadajuće",num:1, icon: <SortByAlphaIcon /> },

  { opis: "Korisničko ime subjekta rastuće",num:2, icon: <SortByAlphaIcon /> },
  { opis: "Korisničko ime subjekta opadajuće",num:3, icon: <SortByAlphaIcon /> },

  { opis: "Datum rastuće",num:4, icon: <DateRangeOutlinedIcon /> },
  { opis: "Datum opadajuće",num:5, icon: <DateRangeOutlinedIcon /> },

  { opis: "Tip zahteva",num:6, icon: <SortByAlphaIcon /> },
];

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & { children?: React.ReactElement<any, any> },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

function SimpleDialog(props: SimpleDialogProps) {
  const classes = useStyles();
  const { onClose, selectedValue, open } = props;

  const handleClose = () => {
    onClose(selectedValue);
  };

  const handleListItemClick = (value: number) => {
    onClose(value.toString());
  };

  return (
    <Dialog
      onClose={handleClose}
      TransitionComponent={Transition}
      aria-labelledby="simple-dialog-title"
      open={open}
    >
      <DialogTitle id="simple-dialog-title">Kriterijum sortiranja</DialogTitle>
      <List>
        {sorting.map((x: ISort) => (
          <ListItem
            button
            onClick={() => handleListItemClick(x.num)}
            key={x.opis}
          >
            <ListItemAvatar>
              <Avatar className={classes.avatar}>{x.icon}</Avatar>
            </ListItemAvatar>
            <ListItemText primary={x.opis} />
          </ListItem>
        ))}
      </List>
    </Dialog>
  );
}

export default function Sort(
  openSort: boolean,
  setOpenSort: (a: boolean) => void,
  selectedValue:Number, setSelectedValue:(a:number)=>void
) {

  const handleClose = (value: string) => {
    setOpenSort(false);
    setSelectedValue(Number(value));
  };

  return (
    <Box>
      {selectedValue}
      <SimpleDialog
        selectedValue={selectedValue.toString()}
        open={openSort}
        onClose={handleClose}
      />
    </Box>
  );
}
