import { IAzuriranjeNalogaPodaci } from "./interfaces";
import { URL } from '../konstante';

//TREBA DA SE UCITAJU U SVA POLJA ODGOVARAJUCI PODACI
export function PribaviKorisnika(
  korisnickoIme: string,
  setKorisnikInfo: (x: IAzuriranjeNalogaPodaci) => void
) {
  // fetch(`${URL}/Korisnici/PribaviPodatkeOKorisniku`, {
  //   method: "post",
  //   credentials: "include",
  //   headers: {
  //     "Content-Type": "application/json",
  //   },
  //   body: JSON.stringify({
  //     KorisnickoIme: korisnickoIme,
  //   }),
  // })
  //   .then((response) => {
  //     if (!response.ok) throw Error("Neuspeli fetch korisnika");
  //     return response;
  //   })
  //   .then((response) => response.json())
  //   .then((obj: IAzuriranjeNalogaPodaci) => {
  //     setKorisnikInfo(obj);
  //   })
  //   .catch((e) => {
  //     console.log(e.message);
  //   });
}

export function AzurirajNalog(podaci: IAzuriranjeNalogaPodaci): boolean {
  let provera: boolean = false;
  fetch(`${URL}/korisnici/azurirajnalog`, {
    method: "put",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Ime: podaci.ime !== "" ? podaci.ime : null,
      Prezime: podaci.prezime !== "" ? podaci.prezime : null,
      KorisnickoIme:
        podaci.novoKorisnickoIme !== "" ? podaci.novoKorisnickoIme : null,
      PostojeceKorisnickoIme:
        podaci.postojeceKorisnickoIme !== ""
          ? podaci.postojeceKorisnickoIme
          : null,
      Email: podaci.email !== "" ? podaci.email : null,
      StatusNaloga: podaci.statusNaloga !== "" ? podaci.statusNaloga : null,
      IDBroj: podaci.idBroj !== "" ? podaci.idBroj : null,
      Uloga: podaci.uloga !== "" ? podaci.uloga : null,
      Privilegije: podaci.privilegije !== "" ? podaci.privilegije : null,
      PutanjeOblasti:
        podaci.nadlezanZaOblasti !== [] ? podaci.nadlezanZaOblasti : null,
    }),
  })
    .then((response) => {
      if (!response.ok)
        throw Error("Nije uspelo azuriranje korisnickog naloga");
      provera = true;
    })
    .catch((e) => {
      console.log(e.message);
    });
  return provera;
}

export function FetchAllOblastiLista(tr:{ val: string[]; all: string[] },setData:Function) {
  //ima je uploadmaterijal
  //ime je u new acc
  /**  fetch(`${URL}/oblasti/pribavisve`, {
    method: "get",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
    },
  })
    .then((response) => response.json())
    .then((x: { putanja: string }[]) => {
      setData(x.map((val) => val.putanja));
    })
    .catch((e) => {
      alert(e);
    }); */
  
    /// PribaviInfoOblastiDTO za sve
    //mora da se zavrsava sam / !!!!! iskoriti npr .map((x) => x + "/")
    setData( {all:["DVdvdv/d/",
    "DVdvdv/dd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/dwdw/",
    "DVdvdv/ddd/dwdws/",
    "DVdv/aa/",
    "D/",
    "DVdvdv/a/",
  ],val:[...tr.val]});
}
