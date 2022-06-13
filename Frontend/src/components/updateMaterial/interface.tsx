export interface ITree {
  key: string;
  name: string;
  path: string;
  children: ITree[];
}
export interface IOblast {
  path: string;
  odobrenje: boolean;
  //zaduzen
}

export interface IEkstenzija {
  extension: string;
  name: string;
}

export const opcijeEkstenzija: IEkstenzija[] = [
  { name: "Video", extension: ".mp4" },
  { name: "Pdf", extension: ".pdf" },
  { name: "Dokument", extension: ".doc" },
  { name: "Dokument", extension: ".docx" },
  { name: "Prezentacija", extension: ".ppt" },
  { name: "Prezentacija", extension: ".pptx" },
  { name: "Slika", extension: ".jpg" },
  { name: "Slika", extension: ".png" },
  { name: "Arhiva", extension: ".zip" },
  { name: "Arhiva", extension: ".rar" },
  { name: "Tabela", extension: ".xls" },
  { name: "Tabela", extension: ".xlsx" },
];

export const dataTree: ITree[] = [
  {
    key: "root",
    name: "Parent1",
    path: "root",
    children: [
      {
        key: "1",
        name: "Child - 1",
        path: "root/Parent1",
        children: [],
      },
      {
        key: "2",
        name: "Child - 2",
        path: "root/Parent1",
        children: [],
      },
      {
        key: "88",
        name: "Child - 3",
        path: "root/Parent1",
        children: [],
      },
      {
        key: "11",
        name: "Child - 4",
        path: "root/Parent1",
        children: [],
      },
      {
        key: "21",
        name: "Child - 5",
        path: "root/Parent1",
        children: [],
      },
      {
        key: "881",
        name: "Child - 6",
        path: "root/Parent1",
        children: [],
      },
    ],
  },
  {
    key: "root1",
    name: "Parent2",
    path: "root",
    children: [
      {
        key: "3",
        name: "Child - 77",
        path: "root/Parent2",
        children: [],
      },
      {
        key: "4",
        name: "Child - 88",
        path: "root/Parent2",
        children: [],
      },
      {
        key: "5",
        name: "Child - 99",
        path: "root/Parent2",
        children: [],
      },
    ],
  },
];
