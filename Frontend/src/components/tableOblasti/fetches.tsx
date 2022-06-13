import { IData, IHeadCell, MoreInfo } from "./interfaces";

export function fetchMaterijali( //provera da l su dobre incijalne vrednosti u usestate
  //**** mozda je zgodno da se promeni DTO da se ne pribavlja ukupanbrzahteva u dodatni fetch
  setDatasArray: (erea: IData[]) => void, //setter
  rowsPerPage: number, //kolko vrednosti u fetch
  page: number, //redni br strabice krece od 0
  ukupanBrZahteva: number,
  setUkupanBrZahteva: (a: number) => void,
  selectedExtension: string, //filter
  selectedName: string, //filter
  selectedStatus: string,
  selectedSortValue: number //sortiranje enum
) {
  //fetch all
  setDatasArray([
    {
      path: "string",
      naziv: "string",
      odobrenje: "ok",
      history: [], //default history je []
    },
    {
      path: "Toma1",
      naziv: "aAlo13",
      odobrenje: "virus!!!",
      history: [{ data: "toma11111" }],
    },
    {
      path: "Toma221",
      naziv: "aAlo13eee",
      odobrenje: "undefined",
      history: [{ data: "toma11111" }],
    },
  ]);
}

export function fetchDodatneInfo(KorisnickoIme: string) {
  return; /*fetch(`${URL}/zahtevi/PribaviTekstAdministratorskogZahteva`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      VremeSlanja: idPodaci.vremeSlanja,
      KorisnickoImeAutora: idPodaci.korisnickoImeAutora,
    }),
  })*/

  //tako bez then u tableZahtevi da se ne bi mnogo menjala struktura
}

export function FetchBrojMaterijala(): number {
  //dodati DTO
  return 23;
}

export function FetchAllOblastiLista(setData: Function) {
  //then catch
  //ima je u acc update
  //ime je u new acc
  /*fetch(`${URL}/oblasti/pribavisve`, {
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
    });*/

  setData([
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
