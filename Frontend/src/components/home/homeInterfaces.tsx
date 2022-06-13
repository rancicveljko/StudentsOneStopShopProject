export interface ITree {
  name: string;
  path: string;
  children: ITree[];
}

// export interface IKomentar {
//   KorisnickoIme: string;
//   Tekst: string;
//   VremeKomentarisanja: string;
// }

export interface ISadrzaj {
  path: string;
  files: string[];
}

export interface IOblastSadrzaj {
  materijali: string[];
  podoblasti: string[];
}

export interface IDetails {
  PunNaziv: string;
  Opis: string;
}

export interface INode {//mozda ne
  path: string;
  naziv: string;
  ekstenzija?:string;
}
