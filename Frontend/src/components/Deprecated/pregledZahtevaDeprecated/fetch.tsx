import { URL } from "../../konstante";
import { IAdminZahtevFilteri, Info } from "./interfaces";

//DA LI SE PODACI U INTF AUTOMATSKI POPUNJAVAJU????
export default function PribaviZahteve(filteri: IAdminZahtevFilteri): Info[] {
  proveriPraznaPolja(filteri);
  fetch(`${URL}/zahtevi/PribaviSveAdministratorskeZahteve`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      OdIndeksa: filteri.odIndeksa,
      Koliko: filteri.koliko,
      KorisnickoImeAutora: filteri.korisnickoImeAutora,
      KorisnickoImeSubjekta: filteri.korisnickoImeSubjekta,
      OdVreme: filteri.odVreme,
      DoVreme: filteri.doVreme,
      Tip: filteri.tipZahteva,
    }),
  });
  return [{ id: "id", value: "value" }];//da ne baca exception
}

function proveriPraznaPolja(filteri: IAdminZahtevFilteri) {
  if (filteri.odIndeksa === "") filteri.odIndeksa = undefined;
  if (filteri.koliko === "") filteri.koliko = undefined;
  if (filteri.korisnickoImeAutora === "")
    filteri.korisnickoImeAutora = undefined;
  if (filteri.korisnickoImeSubjekta === "")
    filteri.korisnickoImeSubjekta = undefined;
  if (filteri.odVreme === "") filteri.odVreme = undefined;
  if (filteri.doVreme === "") filteri.doVreme = undefined;
  if (filteri.tipZahteva === "") filteri.tipZahteva = undefined;
}
