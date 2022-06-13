import { HeadCell } from "./interfaces";

export function dataBody(createData: Function) {
  //fetch all
  return [
    createData("Frozen yoghurt", 159, 6.0, 24, 4.0, 3.99, [
      { date: "2020-01-05", customerId: "11091700", amount: 3 },
      { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
    ]),
    createData("Ice cream sandwich", 237, 9.0, 37, 4.3, 4.99, [
      { date: "2020-01-05", customerId: "11091700", amount: 3 },
      { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
    ]),
    createData("Eclair", 262, 16.0, 24, 6.0, 3.79, [
      { date: "2020-01-05", customerId: "11091700", amount: 3 },
      { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
    ]),
    createData("Cupcake", 305, 3.7, 67, 4.3, 2.5, [
      { date: "2020-01-05", customerId: "11091700", amount: 3 },
      { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
    ]),
    createData("Gingerbread", 356, 16.0, 49, 3.9, 1.5, [
      { date: "2020-01-05", customerId: "11091700", amount: 3 },
      { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
    ]),
  ];
}

export const headCells: HeadCell[] = [
  {//definisati header
    id: "name",
    numeric: false,
    disablePadding: true,
    label: "Dessert (100g serving)",
  },
  { id: "calories", numeric: true, disablePadding: false, label: "Calories" },
  { id: "fat", numeric: true, disablePadding: false, label: "Fat (g)" },
  { id: "carbs", numeric: true, disablePadding: false, label: "Carbs (g)" },
  { id: "protein", numeric: true, disablePadding: false, label: "Protein (g)" },
];
