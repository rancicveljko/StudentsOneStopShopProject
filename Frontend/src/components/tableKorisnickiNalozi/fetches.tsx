import { IData, IHeadCell, MoreInfo } from "./interfaces";
import { URL } from "../konstante";

function Sortiraj(nacinSortiranja: number, niz: IData[]) {
  if (nacinSortiranja === 0) {
  }
  switch (nacinSortiranja) {
    case 0:
      niz.sort((a, b) => (a.korisnickoIme > b.korisnickoIme ? 1 : -1));
      break;
    case 1:
      niz.sort((a, b) => (a.korisnickoIme < b.korisnickoIme ? 1 : -1));
      break;
    case 2:
      niz.sort((a, b) => (a.uloga < b.uloga ? 1 : -1));
      break;
    case 3:
      niz.sort((a, b) => (a.uloga > b.uloga ? 1 : -1));
      break;
    case 4:
      niz.sort((a, b) => (a.statusNaloga > b.statusNaloga ? 1 : -1));
      break;
    case 5:
      niz.sort((a, b) => (a.statusNaloga > b.statusNaloga ? 1 : -1));
      break;

    default:
      break;
  }
}

export function fetchKorisnici( //provera da l su dobre incijalne vrednosti u usestate
  //**** mozda je zgodno da se promeni DTO da se ne pribavlja ukupanbrzahteva u dodatni fetch
  setDatasArray: (erea: IData[]) => void, //setter
  rowsPerPage: number, //kolko vrednosti u fetch
  page: number, //redni br strabice krece od 0
  ukupanBrZahteva: number,
  setUkupanBrZahteva: (a: number) => void,
  selectedStatusNaloga: string, //filter
  selectedKorIme: string, //filter
  selectedUloga: string, //filter
  selectedSortValue: number //sortiranje enum
) {
  fetch(`${URL}/korisnici/PribaviSveKorisnickeNaloge`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: selectedKorIme,
      Uloga: selectedUloga,
      StatusNaloga: selectedStatusNaloga,
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch svih korisnika");
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

export function fetchDodatneInfo(KorisnickoIme: string, Uloga: string) {
  return fetch(`${URL}/korisnici/PribaviPodatkeOKorisniku`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: KorisnickoIme,
    }),
  });

  //tako bez then u tableZahtevi da se ne bi mnogo menjala struktura
}

export function FetchBrojNaloga(): number {
  //dodati DTO
  return 23;
}
