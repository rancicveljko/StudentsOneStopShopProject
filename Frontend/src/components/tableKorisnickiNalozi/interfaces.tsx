export interface IData {
  ime: string;
  prezime: string;
  email: string;
  korisnickoIme: string;
  uloga: number;
  statusNaloga: number;
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
// OsnovniKorisnik = 0,
// NapredniKorisnik = 1,
// Administrator = 2,

export const headCells: IHeadCell[] = [
  {
    id: "korisnickoIme",
    numeric: false,
    disablePadding: true,
    label: "Korisničko ime",
  },
  {
    id: "uloga",
    numeric: false,
    disablePadding: false,
    label: "Uloga",
  },
  {
    id: "statusNaloga",
    numeric: false,
    disablePadding: false,
    label: "Status naloga",
  },
];
