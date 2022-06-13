import { URL } from "../konstante";

export default function PrijaviSe(
  korisnickoIme: string,
  lozinka: string,
  zapamtiMe: boolean,
  history: any,
  handleErrorPopupClickOpen: Function,
  setErrorPopupOpen: Function,
  setLoading: (a: boolean) => void
) {
  setLoading(true);
  setErrorPopupOpen(true);
  fetch(`${URL + "/korisnici/prijava"}`, {
    method: "post",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: korisnickoIme,
      Lozinka: lozinka,
      ZapamtiMe: zapamtiMe,
    }),
  })
    .then((response) => {
      if (response.ok) {
        setLoading(false);
        setErrorPopupOpen(false);
        response.text().then(function (text) {
          history.push({ pathname: "/home", state: text });
        });
      } else {
        response
          .json()
          .then((e: { Lozinka: string[]; KorisnickoIme: string[] }) => {
            setLoading(false);
            setErrorPopupOpen(false);
            handleErrorPopupClickOpen(
              e.KorisnickoIme === undefined ? "" : e.KorisnickoIme[0],
              e.Lozinka === undefined ? "" : e.Lozinka[0]
            );
          });
      }
    })
    .catch((e) => {
      setLoading(false);
      handleErrorPopupClickOpen("Ne postoji veza sa serverom", "");
    });
}

export function ProveraCookie(
  history: any,
  handleErrorPopupClickOpen: Function,
  setErrorPopupOpen: Function,
  setLoading: (a: boolean) => void
) {
  setLoading(true);
  setErrorPopupOpen(true);
  fetch(`${URL + "/korisnici/proveristatusprijave"}`, {
    method: "get",
    credentials: "include",
  })
    .then((response) => {
      if (response.ok) {
        setLoading(false);
        setErrorPopupOpen(false);
        response.text().then(function (text) {
          history.push({ pathname: "/home", state: text });
        });
      } else {
        setLoading(false);
        setErrorPopupOpen(false);
      }
    })
    .catch((e) => {
      setLoading(false);
      handleErrorPopupClickOpen("Ne postoji veza sa serverom", "");
    });
}
