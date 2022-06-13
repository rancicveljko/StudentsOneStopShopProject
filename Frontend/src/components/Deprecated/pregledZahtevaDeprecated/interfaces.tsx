export interface TabPanelProps {
  children?: React.ReactNode;
  index: any;
  value: any;
}

export interface Info {
  id: string;
  value: string;
}

export interface IAdminZahtevFilteri {
  odIndeksa?: string;
  koliko?: string;
  korisnickoImeAutora?: string;
  korisnickoImeSubjekta?: string;
  odVreme?: string;
  doVreme?: string;
  tipZahteva?: string;
}
