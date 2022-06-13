export interface IData {
  korisnickoImeAutora: string;
  putanjaOblasti: string;
  nazivMaterijala: string;
  ekstenzijaMaterijala: string;
  vremeSlanja: string;
  tipZahteva: number;
  history: MoreInfo[];
}
export interface IHeadCell {
  disablePadding: boolean;
  id: keyof IData;
  label: string;
  numeric: boolean;
}

export interface MoreInfo {
  data: string;
}

export interface IZahtevID {
  vremeSlanja: string;
  korisnickoIme: string;
  prihvacen?: string;
  naziv: string;
  ekstenzija: string;
  putanja: string;
}

export const headCells: IHeadCell[] = [
  //settings
  {
    //definisati header
    id: "korisnickoImeAutora",
    numeric: false,
    disablePadding: true,
    label: "Korisničko ime autora",
  },
  {
    id: "putanjaOblasti",
    numeric: false,
    disablePadding: false,
    label: "Korisničko ime subjekta",
  },
  {
    id: "vremeSlanja",
    numeric: false,
    disablePadding: false,
    label: "Vreme slanja",
  },
  {
    id: "tipZahteva",
    numeric: false,
    disablePadding: false,
    label: "Tip zahteva",
  },
];
