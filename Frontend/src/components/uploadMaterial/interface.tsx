export interface ITree {
    key: string;
    name: string;
    path: string,
    children: ITree[];
  }
    export interface IOblast {
    path: string;
    odobrenje: boolean;
    //zaduzen
  }
  
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

