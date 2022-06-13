import { ISadrzaj, ITree } from "./homeInterfaces";

export const dataTree: ITree[] = [
  {
    name: "Parent1",
    path: "root",
    children: [
      {
        name: "Child - 1",
        path: "root/Parent1",
        children: [],
      },
      {
        name: "Child - 2",
        path: "root/Parent1",
        children: [],
      },
    ],
  },
  {
    name: "Parent2",
    path: "root",
    children: [
      {
        name: "Child - 1",
        path: "root/Parent2",
        children: [],
      },
      {
        name: "Child - 2",
        path: "root/Parent2",
        children: [],
      },
      {
        name: "Child - 3",
        path: "root/Parent2",
        children: [],
      },
    ],
  },
];

export const sadrzaj1: ISadrzaj = {
  path: "root",
  files: [
    "aaa",
    "aaaaaaaaaaa",
    "dfdfdf",
    "fdfdddddddddddddddddddd",
    "Dfdfdsss",
  ],
};

export const sadrzaj2: ISadrzaj = {
  path: "root/dfdfdfdf",
  files: [
    "aaa",
    "aaaaaaaaaaa",
    "dfdfdf",
    "fdfdddddddddddddddddddd",
    "55Dfdfdsss",
    "666666dfdfdf",
    "7fdfdddddddddddddddddddd",
    "888888Dfdfdsss",
  ],
};
