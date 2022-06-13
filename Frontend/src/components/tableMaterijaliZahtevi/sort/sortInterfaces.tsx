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
  KorisnickoImeAutoraRastuće = 0,
  KorisnickoImeAutoraOpadajuće = 1,
  PutanjaOblastiRastuce = 2,
  PutanjaOblastiOpadajuce = 3,
  NazivMaterijalaRastuce = 4,
  NazivMaterijalaOpadajuce = 5,
  EkstenzijaMaterijalaRastuce = 6,
  EkstenzijaMaterijalaOpadajuce = 7,
  DatumRastuce = 8,
  DatumOpadajuće = 9,
  TipZahteva = 10,
}
