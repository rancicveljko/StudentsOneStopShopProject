export interface IFilter {
  extension: string;
  name: string;
}

export const opcije: IFilter[] = [
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