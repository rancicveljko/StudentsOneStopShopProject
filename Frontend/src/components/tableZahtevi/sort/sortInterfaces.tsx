export interface SimpleDialogProps {
  open: boolean;
  selectedValue: string;
  onClose: (value: string) => void;
}

export interface ISort{
    opis: string;
    num:number;
    icon: JSX.Element;
}

export enum SORT{
  KorisnickoImeAutoraRastuće=0,
  KorisnickoImeAutoraRastuceOpadajuće=1,
  KorisnickoImeSubjektaRastuce=2,
  KorisnickoImeSubjektaRastuceOpadajuce=3,
  DatumRastuce=4,
  DatumOpadajuće=5,
  TipZahteva=6,
}