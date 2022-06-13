export interface IFilter {
  val: string;
  name: string;
}
export const opcije: IFilter[] = [
  { name: "Ukidanje privilegija komentarisanja", val: "1" },
  { name: "Ukidanje privilegija ocenjivanja", val: "2" },
  { name: "Ukidanje privilegija dodavanja materijala", val: "4" },
  { name: "Blokiranje korisničkog naloga", val: "8" },
  { name: "Deblokiranje korisničkog naloga", val: "16" },
];
