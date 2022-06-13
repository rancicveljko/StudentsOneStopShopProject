import { IData, IHeadCell, IZahtevID, MoreInfo } from "./interfaces";
import { URL } from "../konstante";
import { TipZahtevaObrada } from "./tableZahtevi";

function RazresiVrednostTipaAdminZahteva(nazivZahteva: string) {
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

function Sortiraj(nacinSortiranja: number, niz: IData[]) {
  if (nacinSortiranja === 0) {
  }
  switch (nacinSortiranja) {
    case 0:
      niz.sort((a, b) =>
        a.korisnickoImeAutora > b.korisnickoImeAutora ? 1 : -1
      );
      break;
    case 1:
      niz.sort((a, b) =>
        a.korisnickoImeAutora < b.korisnickoImeAutora ? 1 : -1
      );
      break;
    case 2:
      niz.sort((a, b) =>
        a.korisnickoImeSubjekta < b.korisnickoImeSubjekta ? 1 : -1
      );
      break;
    case 3:
      niz.sort((a, b) =>
        a.korisnickoImeSubjekta > b.korisnickoImeSubjekta ? 1 : -1
      );
      break;
    case 4:
      break;
    case 5:
      break;
    case 6:
      niz.sort((a, b) =>
        TipZahtevaObrada(a.tip) < TipZahtevaObrada(b.tip) ? 1 : -1
      );
      break;

    default:
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
  selectedNameSubject: string, //filter
  selectedDate1: Date | null, //filter datum od
  selectedDate2: Date | null, //filter datum do
  selectedSortValue: number //sortiranje enum
) {
  console.log(selectedDate1);

  fetch(`${URL}/zahtevi/PribaviSveAdministratorskeZahteve`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoImeAutora: selectedNameAutor,
      KorisnickoImeSubjekta: selectedNameSubject,
      /* OdVreme:selectedDate1?.toString(),
      DoVreme:selectedDate2?.toString(), */
      Tip:
        selectedTip !== ""
          ? RazresiVrednostTipaAdminZahteva(selectedTip)
          : selectedTip,
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch svih zahteva");
      return response;
    })
    .then((response) => response.json())
    .then((x: IData[]) => {
      Sortiraj(selectedSortValue, x);
      setDatasArray(x);
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function fetchZahtevTekst(idPodaci: IZahtevID) {
  console.log(idPodaci.vremeSlanja);
  return fetch(`${URL}/zahtevi/PribaviTekstAdministratorskogZahteva`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      VremeSlanja: idPodaci.vremeSlanja,
      KorisnickoImeAutora: idPodaci.korisnickoImeAutora,
    }),
  });
}

export function ObradiZahtev(idPodaci: IZahtevID, fetchZaRender: Function) {
  fetch(`${URL}/zahtevi/ObradiAdministratorskiZahtev`, {
    method: "put",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      VremeSlanja: idPodaci.vremeSlanja,
      KorisnickoImeAutora: idPodaci.korisnickoImeAutora,
      Prihvacen: idPodaci.prihvacen,
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
