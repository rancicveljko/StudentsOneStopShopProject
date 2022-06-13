import SortByAlphaIcon from "@material-ui/icons/SortByAlpha";

export interface SimpleDialogProps {
  open: boolean;
  selectedValue: string;
  onClose: (value: string) => void;
}

export interface ISort{
    opis: string;
    icon: JSX.Element;
}

export const sorting: ISort[] = [
  { opis: "Naziv oblasti rastuće", icon: <SortByAlphaIcon /> },
  { opis: "Naziv oblasti opadajuće", icon: <SortByAlphaIcon /> },
  // { opis: "Status materijala rastuće", icon: <SortByAlphaIcon /> },mozda sort po odobrenju il path al vrv ne
  // { opis: "Status materijala opadajuće", icon: <SortByAlphaIcon /> },
];