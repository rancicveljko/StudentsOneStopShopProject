export interface IData {
  path: string;
  naziv: string;
  tip: string;
  status: string;
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
    id: "naziv",
    numeric: false,
    disablePadding: false,
    label: "Naziv",
  },
  {
    id: "path",
    numeric: false,
    disablePadding: true,
    label: "Putanja",
  },

  {
    id: "tip",
    numeric: false,
    disablePadding: false,
    label: "Tip",
  },
  {
    id: "status",
    numeric: false,
    disablePadding: false,
    label: "Status",
  },
];
