import { ITree } from "../home/homeInterfaces";
import { URL } from "../konstante";
import { IKorisnickiNalogPodaci } from "./interface";

export function PribaviOblasti(setListaOblasti: (x: ITree) => void) {
  //TREBA DA SE PRIKAZE OBLAST TREE
  fetch(`${URL}/oblasti/pribavisve`, {
    method: "get",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
  });
}

export function KreirajKorisnika(
  korisnickiNalog: IKorisnickiNalogPodaci
) {
  //TREBA DA SE ISPITA KOJI TIP KORISNIKA SE DODAJE
  //PROVERI KAKAV STRING VRACA RADIO BUTTON ZA ULOGU
  //to do: tip u zavisnosti dal je putanje [] ili idbroj ""
  //catch ako greska
  if (korisnickiNalog.uloga === "Osnovni_Korisnik") {
    fetch(`${URL}/korisnici/kreiraj`, {
      method: "post",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Ime: korisnickiNalog.ime !== "" ? korisnickiNalog.ime : null,
        Prezime:
          korisnickiNalog.prezime !== "" ? korisnickiNalog.prezime : null,
        Email: korisnickiNalog.email !== "" ? korisnickiNalog.email : null,
        Uloga: korisnickiNalog.uloga,
        IDBroj: korisnickiNalog.idBroj !== "" ? korisnickiNalog.idBroj : null,
      }),
    })
      .then((response) => {
        if (!response.ok)
          throw Error("Nije uspelo kreiranje osnovnog korisnika");
      })
      .catch((e) => {
        console.log(e.message);
      });
  } else if (korisnickiNalog.uloga === "Napredni_Korisnik") {
    fetch(`${URL}/korisnici/kreiraj`, {
      method: "post",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Ime: korisnickiNalog.ime !== "" ? korisnickiNalog.ime : null,
        Prezime:
          korisnickiNalog.prezime !== "" ? korisnickiNalog.prezime : null,
        Email: korisnickiNalog.email !== "" ? korisnickiNalog.email : null,
        Uloga: korisnickiNalog.uloga,
        PutanjeOblasti:
          korisnickiNalog.PutanjeOblasti !== []
            ? korisnickiNalog.PutanjeOblasti
            : null,
      }),
    })
      .then((response) => {
        if (!response.ok)
          throw Error("Nije uspelo kreiranje naprednog korisnika");
      })
      .catch((e) => {
        console.log(e.message);
      });
  }
}

export function FetchAllOblastiLista( setOblastiSve: (a: string[]) => void){
  //ima je uploadmaterijal
  //ime je u acc update
  setOblastiSve( [
    /// PribaviInfoOblastiDTO za sve
    //mora da se zavrsava sam / !!!!! iskoriti npr .map((x) => x + "/")
    "DVdvdv/d/",
    "DVdvdv/dd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/",
    "DVdvdv/ddd/dwdw/",
    "DVdvdv/ddd/dwdws/",
    "DVdv/aa/",
    "D/",
    "DVdvdv/a/",
  ]);
}
