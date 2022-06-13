export interface IData {
  korisnickoImeAutora: string;
  korisnickoImeSubjekta: string;
  vremeSlanja: string;
  tip: number;
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
// Ukidanje_Privilegija_Komentarisanja = 1,
// Ukidanje_Privilegija_Ocenjivanja = 2,
// Ukidanje_Privilegija_Dodavanja_Materijala = 4,
// Blokiranje_Korisnickog_Naloga = 8,
// Deblokiranje_Korisnickog_Naloga = 16

export interface IZahtevID {
  vremeSlanja: string;
  korisnickoImeAutora: string;
  prihvacen?: string;
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
    id: "korisnickoImeSubjekta",
    numeric: false,
    disablePadding: false,
    label: "Korisničko ime subjekta",
  },
  { id: "vremeSlanja", numeric: false, disablePadding: false, label: "Datum" },
  {
    id: "tip",
    numeric: false,
    disablePadding: false,
    label: "Tip zahteva",
  },
];