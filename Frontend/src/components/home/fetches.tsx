import { IDetails, INode, IOblastSadrzaj, ITree } from "./homeInterfaces";
import { URL } from "../konstante";
import { IKomentar } from "./komentari/interfaces";

export function DodajKomentar(
  Tekst: string,
  val: INode,
  setListaKomentara: (x: IKomentar[]) => void
) {
  fetch(`${URL + "/materijal/dodajkomentar"}`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Tekst: Tekst,
      VremeSlanja: new Date().toISOString(),
      Naziv: val.naziv,
      Putanja: val.path,
      Ekstenzija: val.ekstenzija,
    }),
  })
    .then((response) => {
      if (response.ok) FetchKomentari(val,"","", setListaKomentara);//da l ""??????????????????
      else throw Error("Nije uspelo dodavanje komentara");
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function DodajOcenuUp(
  val: INode,
  setOcenaMaterijala: (x: number) => void,
  setMyVote: (x: number) => void
) {
  fetch(`${URL + "/materijal/oceni"}`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      TipOcene: "Palac_Gore",
      Naziv: val.naziv,
      Putanja: val.path,
      Ekstenzija: ".jpg",
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspelo dodavanje pozitivne ocene");
      FetchOcena(val, setOcenaMaterijala, setMyVote);
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function DodajOcenuDown(
  val: INode,
  setOcenaMaterijala: (x: number) => void,
  setMyVote: (x: number) => void
) {
  fetch(`${URL + "/materijal/oceni"}`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      TipOcene: "Palac_Dole",
      Naziv: val.naziv,
      Putanja: val.path,
      Ekstenzija: ".jpg",
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspelo dodavanje negativne ocene");
      FetchOcena(val, setOcenaMaterijala, setMyVote);
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export async function PribaviSadrzajOblast( ///testtttttirati
  //*********************************************************************************** */
  //                            da se promeni za od kog materijala i kolko materijala
  //
  //************************************************************************************* */ceka se back
  val: INode,
  setTreeOblasti: Function,
  // treeOblasti:ITree[],
  setListaMaterijal: Function,
  setselectedFile: Function
): Promise<any> {
  return fetch(`${URL}/oblasti/pregledajsadrzaj`, {
    method: "post",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
    body: JSON.stringify({
      Putanja: val.path, // + "/" + val.naziv,
    }),
  });
  //obrisati vrv!!!
  /*.then((response) => response.json())
    .then((x: IOblastSadrzaj) => {
      setListaMaterijal({
        path: val.path + "/" + val.naziv,
        files: x.materijali,
      });
      const pom: ITree[] = [];
      x.podoblasti.forEach((x) => {
        pom.push({
          name: x,
          path: val.path + "/" + val.naziv,
          children: [],
        });
      });
      //setTreeOblasti(pom); //odsece
      setselectedFile({
        naziv: x.materijali[0],
        path: val.path + "/" + val.naziv,
      });
      return pom; //vraca decu
    })
    .catch(() => alert("ne valja"));*/

  // setListaMaterijal({
  //   path: val.path + "/" + val.naziv,
  //   files: [
  //     "dfd0cccccccccccccccccccccccccccccc",
  //     "1dfdfddd",
  //     "2dddd",
  //     "3dfd",
  //     "4dfdfddd",
  //     "5dddd",
  //     "6dfd",
  //     "7dfdfddd",
  //     "9dddd",
  //     "+dfd",
  //     "11dfdfddd",
  //     "12dddd",
  //     "13dfd",
  //     "14dfdfddd",
  //     "15dddd",
  //     "16dfd",
  //     "17dfdfddd",
  //     "18dddd",
  //   ],
  // })

  //return [];

  /*alert("nije proso hadle click");
  setListaMaterijal({ path: "sdsd", files: ["dfdf", "Dfdfdfdf", "dfsdf"] });
  setselectedFile({ naziv: "dfdf", path: "sdsd" });
  return [
    {
      name: "simulation1",
      path: "error",
      children: [
        {
          name: "simulation11",
          path: "error",
          children: [
            {
              name: "simulation111",
              path: "error",
              children: [
                { name: "simulation1111", path: "error", children: [] },
              ],
            },
            { name: "simulation112", path: "error", children: [] },
          ],
        },
      ],
    },
    { name: "simulation2", path: "error", children: [] },
    {
      name: "simulation3",
      path: "error",
      children: [
        { name: "simulation31", path: "error", children: [] },
        { name: "simulation32", path: "error", children: [] },
      ],
    },
  ];*/
}

export function PribaviSadrzajOblastInit(
  setTreeOblasti: Function,
  setListaMaterijal: Function,
  setselectedFile: Function,
  setBrMaterijala: Function,
  selectedOblast: INode
) {
  fetch(`${URL}/oblasti/pregledajsadrzaj`, {
    method: "post",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
    body: JSON.stringify({
      Putanja: "",
    }),
  })
    .then((response) => response.json())
    .then((x: IOblastSadrzaj) => {
      setListaMaterijal({
        path: "",
        files: x.materijali,
      });
      const pom: ITree[] = [];
      x.podoblasti.forEach((pod) => {
        pom.push({
          name: pod,
          path: "",
          children: [],
        });
      });
      //setTreeOblasti(pom); //odsece
      setselectedFile({
        naziv: x.materijali[0],
        path: "",
      });
      setTreeOblasti([...pom]);
    })
    .catch(() => alert("ne valja"));
  FetchBrojMaterijala(selectedOblast);
}

export function fetchFileDetails(val: INode): IDetails {
  // alert("not implemented");
  return { PunNaziv: val.path + "/" + val.naziv, Opis: "ovo je fajl" }; //NIJE JOS IMPLEMENTIRANO NA BACKEND
}

export function FetchKomentari(
  val: INode,//autor predhodnog komentara+vreme slanja
  autorPredhodnog:string,
  vremeSlanjaPredhodnog:string,
  setListaKomentara: (x: IKomentar[]) => void
) {
 /* fetch(`${URL}/materijal/PribaviKomentare`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Putanja: val.path,
      Naziv: val.naziv,
      Ekstenzija: val.ekstenzija,
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch komentara");
      return response;
    })
    .then((response) => response.json())
    .then((x: IKomentar[]) => {
      setListaKomentara(x);
    })
    .catch((e) => {
      console.log(e.message);
    });*/
    setListaKomentara([{
      KorisnickoIme: "aaa2",
      Tekst: "aaaaaaaaaaa2",
      Vreme: new Date().toLocaleDateString(),
      Tip: "Napredni",
      //ImaOdgovore: true,
    },
    {
      KorisnickoIme: "dfdfdf",
      Tekst: "fdfdddddddddddddddddddd2",
      Vreme: "22:222:222",
      Tip: "Admin",
      //ImaOdgovore: false,
    },
    {
      KorisnickoIme: "dfdfdf",
      Tekst:
        "fdkldlkn 222dnkldknlfnkdd ddddddddddda ssaaaaaaaakkkkk kkkkkkkk uuuuuuuuu uuuuuuuu",
      Vreme: new Date().toLocaleDateString(),
      Tip: "Osnovni_Korisnik",
      //ImaOdgovore: true,
    },])
}

export function FetchOcena(
  val: INode,
  setOcenaMaterijala: (x: number) => void,
  setMyVote: (x: number) => void
) {
  fetch(`${URL}/materijal/pribaviukupnuocenuikorisnickuocenu`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Putanja: val.path,
      Naziv: val.naziv,
      Ekstenzija: ".jpg",
    }),
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch ukupne ocene materijala");
      return response;
    })
    .then((response) => response.json())
    .then((x: { ukupnaOcena: number; tipOcene?: number }) => {
      console.log(x.tipOcene);
      console.log(x.ukupnaOcena);

      setOcenaMaterijala(x.ukupnaOcena);
      setMyVote(x.tipOcene === undefined ? 0 : x.tipOcene); //ili null
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function FetchBrojMaterijala(oblast: INode): number {
  return 15;
  return -1; //za error
}

export function ObrisiSvojKomentar(
  komentar: IKomentar,
  materijal: INode,
  setListaKomentara: (x: IKomentar[]) => void
) {
  fetch(`${URL}/materijal/ObrisiSvojKomentar`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      VremeKomentarisanja: komentar.Vreme,
      Naziv: materijal.naziv,
      Putanja: materijal.path,
    }),
  })
    .then((response) => {
      if (response.ok) FetchKomentari(materijal,"","", setListaKomentara);
      else throw Error("Nije uspelo brisanje komentara");
    })
    .catch((e) => {
      console.log(e.message);
    });
}

export function ObrisiKomentar(
  komentar: IKomentar,
  materijal: INode,
  setListaKomentara: (x: IKomentar[]) => void //proveri
) {
  fetch(`${URL}/materijal/ObrisiKomentar`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: komentar.KorisnickoIme,
      VremeKomentarisanja: komentar.Vreme,
      Naziv: materijal.naziv,
      Putanja: materijal.path,
    }),
  })
    .then((response) => {
      if (response.ok) FetchKomentari(materijal,"","", setListaKomentara);
      else throw Error("Nije uspelo brisanje komentara");
    })
    .catch((e) => {
      console.log(e.message);
    });
}
export function FetchMaterijaliPoKriterijumu() {
  //za sortiranje i filtriranje
}

export function FetchMaterijal(fajl: INode): void {
  //jedan materijal na osnovu INode za download
}
