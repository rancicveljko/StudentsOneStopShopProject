export interface IFilterOdobrenje {
  name: string;
  val: boolean;
}

export const opcijeOdobrenje: IFilterOdobrenje[] = [
  { name: "Da", val: true },
  { name: "Ne", val: false }
];
