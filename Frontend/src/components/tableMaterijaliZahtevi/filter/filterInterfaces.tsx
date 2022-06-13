export interface IFilter {
  val: string;
  name: string;
}
export const opcije: IFilter[] = [
  { name: "Dodavanje novog materijala", val: "0" },
  { name: "Azuriranje postojeceg materijala", val: "1" },
  { name: "Dodavanje ili azuriranje sa greskom antivirusa", val: "2" },
  { name: "Dodavanje ili azuriranje sa nepoznatim statusom skeniranja na viruse", val: "3" },
];
