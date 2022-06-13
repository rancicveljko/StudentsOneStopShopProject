export interface IData {
  path: string;
  naziv: string;
  odobrenje: string;
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
} //nadlezni napredni korisnici
//potrebno odobrenje

export const headCells: IHeadCell[] = [
  {
    id: "path",
    numeric: false,
    disablePadding: true,
    label: "Putanja",
  },
  {
    id: "naziv",
    numeric: false,
    disablePadding: false,
    label: "Naziv",
  },
  {
    id: "odobrenje",
    numeric: false,
    disablePadding: false,
    label: "Odobrenje",
  },
];
