import { IAzuriranjeSvogNalogaPodaci } from "./interfaces";
import { URL } from "../konstante";

export function PribaviKorisnika(
  korisnickoIme: string,
  setKorisnikInfo: (x: IAzuriranjeSvogNalogaPodaci) => void
) {
  fetch(`${URL}/korisnici/PribaviPodatkeOKorisniku`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: korisnickoIme,
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspelo pribavljanje korisnika");
      return response;
    })
    .then((response) => response.json())
    .then((obj: IAzuriranjeSvogNalogaPodaci) => {
      setKorisnikInfo(obj);
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function AzurirajSvojNalog(
  podaci: IAzuriranjeSvogNalogaPodaci,
  history:any
) {
  fetch(`${URL}/korisnici/azurirajsvojnalog`, {
    method: "patch",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: podaci.korisnickoIme !== "" ? podaci.korisnickoIme : null,
      Lozinka: podaci.lozinka, //ne sme nul????
      Email: podaci.email !== "" ? podaci.email : null,
      NovaLozinka: podaci.novaLozinka !== "" ? podaci.novaLozinka : null,
    }),
  })
    .then((response) => {
      if (!response.ok)
        throw Error("Nije uspelo azuriranje korisnickog naloga");
      history.push("/Home");
    })
    .catch((e) => {
      console.log(e.message);
    });
}
