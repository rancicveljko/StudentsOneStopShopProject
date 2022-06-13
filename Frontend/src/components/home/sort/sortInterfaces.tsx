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
  { opis: "Naziv materijala rastuće", icon: <SortByAlphaIcon /> },
  { opis: "Naziv materijala opadajuće", icon: <SortByAlphaIcon /> },
  { opis: "Tip materijala opadajuće", icon: <SortByAlphaIcon /> },
  { opis: "Tip materijala opadajuće", icon: <SortByAlphaIcon /> },
];