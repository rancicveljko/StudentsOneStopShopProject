export interface ITree {
  key: string;
  name: string;
  path: string;
  children: ITree[];
}

export interface IAzuriranjeNalogaPodaci {
  ime: string;
  prezime: string;
  novoKorisnickoIme: string;
  postojeceKorisnickoIme: string;
  email: string;
  statusNaloga: string;
  idBroj: string;
  uloga: string;
  privilegije: string;
  nadlezanZaOblasti: string[];
}
