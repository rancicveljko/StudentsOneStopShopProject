export interface IFilter {
  opis: string;
  value: number;
}

export const opcijeUloga: IFilter[] = [
  { opis: "Osnovni korisnik", value: 0 },
  { opis: "Napredni korisnik", value: 1 },
  { opis: "Administrator", value: 2 },

];

export const opcijeStatusNaloga: IFilter[] = [
  { opis: "Aktivan", value: 0 },
  { opis: "Blokiran", value: 1 },
  { opis: "Obrisan", value: 2 },

];