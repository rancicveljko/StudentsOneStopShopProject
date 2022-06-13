import SortByAlphaIcon from "@material-ui/icons/SortByAlpha";
import DateRangeOutlinedIcon from "@material-ui/icons/DateRangeOutlined";

export interface SimpleDialogProps {
  open: boolean;
  selectedValue: string;
  onClose: (value: string) => void;
}

export interface ISort {
  opis: string;
  num: number;
  icon: JSX.Element;
}

export enum SORT {
  KorisnickoImeRastuće = 0,
  KorisnickoImeOpadajuće = 1,
  UlogaRastuce = 2,
  UlogaOpadajuce = 3,
  StatusNalogaRastuce = 4,
  StatusNalogaOpadajuće = 5,
}

export const sorting: ISort[] = [
  { opis: "Korisničko ime rastuće", num: 0, icon: <SortByAlphaIcon /> },
  { opis: "Korisničko ime opadajuće", num: 1, icon: <SortByAlphaIcon /> },

  { opis: "Uloga rastuće", num: 2, icon: <SortByAlphaIcon /> },
  { opis: "Uloga opadajuće", num: 3, icon: <SortByAlphaIcon /> },

  { opis: "Status naloga rastuće", num: 4, icon: <DateRangeOutlinedIcon /> },
  { opis: "Status naloga opadajuće", num: 5, icon: <DateRangeOutlinedIcon /> },
];
