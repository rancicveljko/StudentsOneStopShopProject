export interface Data {
  name: string;
  calories: number;
  fat: number;
  carbs: number;
  protein: number;
  price: number;
  history: MoreInfo[];
}
export interface HeadCell {
  disablePadding: boolean;
  id: keyof Data;
  label: string;
  numeric: boolean;
}

export interface MoreInfo{
  date: string;
  customerId: string;
  amount: number;
}