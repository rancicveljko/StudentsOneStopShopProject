export interface IFilterTip {
  extension: string;
  name: string;
}

export const opcijeTip: IFilterTip[] = [
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
//status
//dostupan sakrivan
export interface IFilterStatus {
  name: string;
  val: number;
}

export const opcijeStatus: IFilterStatus[] = [
  { name: "proveren", val: 0 },
  { name: "Virus", val: 1 },
  { name: "Nije moguca provera", val: 2 },
  { name: "Greska antivirusa", val: 3 },
  { name: "Sakriven", val: 4 },
];
