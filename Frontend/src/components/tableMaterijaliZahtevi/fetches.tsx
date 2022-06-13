import { IData, IHeadCell, IZahtevID, MoreInfo } from "./interfaces";
import { URL } from "../konstante";
import { TipZahtevaObrada } from "./tableZahtevi";

function RazresiVrednostTipaMaterijalZahteva(nazivZahteva: string) {
  switch (nazivZahteva) {
    case "Ukidanje privilegija komentarisanja":
      return "Ukidanje_Privilegija_Komentarisanja";
      break;
    case "Ukidanje privilegija ocenjivanja":
      return "Ukidanje_Privilegija_Ocenjivanja";
      break;
    case "Ukidanje privilegija dodavanja materijala":
      return "Ukidanje_Privilegija_Dodavanja_Materijala";
      break;
    case "Blokiranje korisničkog naloga":
      return "Blokiranje_Korisnickog_Naloga";
      break;
    case "Deblokiranje korisničkog naloga":
      return "Deblokiranje_Korisnickog_Naloga";
      break;

    default:
      return "greska";
      break;
  }
}

export function fetchZahtevi( //provera da l su dobre incijalne vrednosti u usestate
  //**** mozda je zgodno da se promeni DTO da se ne pribavlja ukupanbrzahteva u dodatni fetch
  setDatasArray: (erea: IData[]) => void, //setter
  rowsPerPage: number, //kolko vrednosti u fetch
  page: number, //redni br strabice krece od 0
  ukupanBrZahteva: number,
  setUkupanBrZahteva: (a: number) => void,
  selectedTip: string, //filter
  selectedNameAutor: string, //filter
  selectedPutanja: string, //filter
  selectedNaziv: string, //filter
  selectedEkstenzija: string, //filter
  selectedDate1: Date | null, //filter datum od
  selectedDate2: Date | null, //filter datum do
  selectedSortValue: number //sortiranje enum
) {
  fetch(`${URL}/zahtevi/PribaviSveZahteveZaDodavanjeIliAzuriranjeMaterijala`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      TipZahteva: selectedTip,
      KorisnickoIme: selectedNameAutor,
      Naziv: selectedNaziv,
      Ekstenzija: selectedEkstenzija,
      Putanja: selectedPutanja,
      //TREBA DA SE POSALJI PREKO CEGA DA SORTIRA
      //selectedSortValue ima vrednosti koje oznacavaju tipove sortiranja
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch svih zahteva");
      return response;
    })
    .then((response) => response.json())
    .then((x: IData[]) => {
      setDatasArray(x);
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function fetchZahtevTekst(idPodaci: IZahtevID) {
  return fetch(
    `${URL}/zahtevi/PribaviTekstZahtevaZaDodavanjeIliAzuriranjeMaterijala`,
    {
      method: "post",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        VremeSlanja: idPodaci.vremeSlanja,
        KorisnickoIme: idPodaci.korisnickoIme,
        Naziv: idPodaci.naziv,
        Ekstenzija: idPodaci.ekstenzija,
        Putanja: idPodaci.putanja,
      }),
    }
  );
}

export function ObradiZahtev(idPodaci: IZahtevID, fetchZaRender: Function) {
  fetch(`${URL}/zahtevi/ObradiZahtevZaDodavanjeIliAzuriranjeMaterijala`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      VremeSlanja: idPodaci.vremeSlanja,
      KorisnickoIme: idPodaci.korisnickoIme,
      Prihvacen: idPodaci.prihvacen,
      Naziv: idPodaci.naziv,
      Ekstenzija: idPodaci.ekstenzija,
      Putanja: idPodaci.putanja,
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspela obrada zahteva");
      fetchZaRender();
    })
    .catch((e) => {
      console.log(e.message);
    });
}
export function FetchBrojZahteva(): number {
  //dodati DTO
  return 23;
}
