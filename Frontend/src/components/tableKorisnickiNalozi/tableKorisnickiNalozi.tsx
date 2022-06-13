import React from "react";
import { useHistory } from "react-router-dom";
import Box from "@material-ui/core/Box";
import Collapse from "@material-ui/core/Collapse";
import IconButton from "@material-ui/core/IconButton";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Typography from "@material-ui/core/Typography";
import Paper from "@material-ui/core/Paper";
import KeyboardArrowDownIcon from "@material-ui/icons/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@material-ui/icons/KeyboardArrowUp";
import FilterListOutlinedIcon from "@material-ui/icons/FilterListOutlined";
import SortOutlinedIcon from "@material-ui/icons/SortOutlined";
import Sort from "./sort/sort";
import Filter from "./filter/filter";
import useStyles from "./tableStyles";
import {
  Button,
  CircularProgress,
  Fab,
  TablePagination,
} from "@material-ui/core";
import { IData, MoreInfo, headCells } from "./interfaces";

import { fetchKorisnici, fetchDodatneInfo, FetchBrojNaloga } from "./fetches";
import { useEffect } from "react";

export function PrivilegijeBrojUString(priv: number): string {
  switch (priv) {
    case 1:
      return "Bez zabrana";
      break;
    case 2:
      return "Zabrana komentarisanja";
      break;
    case 4:
      return "Zabrana ocenjivanja";
      break;
    case 8:
      return "Zabrana dodavanja materijala";
      break;
    default:
      return "";
  }
}

export function StatusNalogaBrojUString(statusNaloga: number) {
  switch (statusNaloga) {
    case 0:
      return "Aktivan";
      break;
    case 1:
      return "Blokiran";
      break;
    case 2:
      return "Obrisan";
      break;
    default:
      return "";
  }
}
export function UlogaObrada(val: number) {
  let a: string;
  switch (val) {
    case 0:
      a = "Osnovni korisnik";
      break;
    case 1:
      a = "Napredni korisnik";
      break;
    case 2:
      a = "Administrator";
      break;
    default:
      a = "greska";
      break;
  }
  return a;
}

// function PrihvatiZahtev(idPodaci: IZahtevID) {
//   idPodaci.prihvacen = "true";
//   ObradiZahtev(idPodaci);
//   alert(idPodaci.vremeSlanja + idPodaci.korisnickoImeAutora);
// }

// function OdbijZahtev(idPodaci: IZahtevID) {
//   idPodaci.prihvacen = "false";
//   ObradiZahtev(idPodaci);
//   alert(idPodaci.vremeSlanja + idPodaci.korisnickoImeAutora);
// }

function Row(prop: { row: IData }) {
  const { row } = prop;
  const [open, setOpen] = React.useState(false);
  const [isFetched, setIsFetched] = React.useState(false);
  const [isNapredniKor, setIsNapredniKor] = React.useState(false);
  const [isOsnovniKori, setIsOsnovniKor] = React.useState(false);
  const classes = useStyles();
  const [napredniKorProvera, setNapredniKorProvera] = React.useState(false);
  const history = useHistory();

  useEffect(() => {
    if (row.history.length === 0) setOpen(false); //patch
  }, [row]);

  return (
    <React.Fragment>
      <TableRow
        className={classes.root}
        tabIndex={-1}
        key={row.korisnickoIme}
        hover
      >
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={(event) => {
              setOpen(!open);

              row.uloga === 1
                ? setNapredniKorProvera(true)
                : setNapredniKorProvera(false);

              if (!isFetched) {
                //setOpen(false);
                let Uloga: string = UlogaObrada(row.uloga);
                fetchDodatneInfo(row.korisnickoIme, Uloga)
                  .then((response) => response.json())
                  .then(
                    (x: {
                      idBroj: string;
                      ime: string;
                      prezime: string;
                      email: string;
                      privilegije: number;
                      nadlezanZaOblasti: string[];
                    }) => {
                      let tmp: MoreInfo[] = [];
                      row.ime = x.ime;
                      row.prezime = x.prezime;
                      row.email = x.email;
                      if (Uloga.includes("Osnovni")) {
                        setIsOsnovniKor(true);
                        tmp.push({ data: x.idBroj });
                        tmp.push({
                          data: PrivilegijeBrojUString(x.privilegije),
                        });
                      } else if (Uloga.includes("Napredni")) {
                        setIsNapredniKor(true);
                        x.nadlezanZaOblasti.forEach((x) =>
                          tmp.push({ data: x })
                        );
                      } else if (Uloga === "Administrator") {
                        tmp.push({
                          data: "Nema dodatnih informacija za administratorske naloge",
                        });
                      }
                      row.history = tmp;
                      setIsFetched(true);
                    }
                  )
                  .catch(() => {
                    row.history = [
                      {
                        data: "greska",
                      },
                    ];
                  });
                // setTimeout(() => {
                //   //test
                //   row.history = [
                //     {
                //       data: "delayyy",
                //     },
                //   ];
                //   setIsFetched(true);
                // }, 2000);
              }
            }}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>

        <TableCell>{row.korisnickoIme}</TableCell>
        <TableCell>{UlogaObrada(row.uloga)}</TableCell>
        <TableCell>{StatusNalogaBrojUString(row.statusNaloga)}</TableCell>
      </TableRow>

      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box margin={1} className={classes.Box}>
              <Typography
                variant="h6"
                gutterBottom
                component="div"
                align="center"
              >
                Dodatne informacije
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableCell>Ime</TableCell>
                  <TableCell>Prezime</TableCell>
                  <TableCell>Email</TableCell>
                  {isOsnovniKori && (
                    <React.Fragment>
                      <TableCell>IDBroj</TableCell>
                      <TableCell>Privilegije</TableCell>
                    </React.Fragment>
                  )}
                  {isNapredniKor && <TableCell>Nadlezan za oblasti</TableCell>}
                </TableHead>

                <TableBody>
                  {!isFetched && <CircularProgress />}
                  {isFetched && (
                    <TableRow>
                      <TableCell>{row.ime}</TableCell>
                      <TableCell>{row.prezime}</TableCell>
                      <TableCell>{row.email}</TableCell>
                      {isOsnovniKori && (
                        <React.Fragment>
                          <TableCell>{row.history[0].data}</TableCell>
                          <TableCell>{row.history[1].data}</TableCell>
                        </React.Fragment>
                      )}
                      {isNapredniKor &&
                        row.history.map((x) => <TableCell>{x.data}</TableCell>)}
                    </TableRow>
                  )}
                </TableBody>
              </Table>
              <Box className={classes.buttonBox}>
                <Box>
                  <Button
                    className={classes.button}
                    onClick={() => {
                      history.push({
                        pathname: "/AccUpdate",
                        state: row,
                      });
                    }}
                  >
                    Izmeni nalog
                  </Button>
                </Box>
              </Box>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </React.Fragment>
  );
}

export default function TableKorisnickiNalozi() {
  const classes = useStyles();
  const [page, setPage] = React.useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = React.useState<number>(10);
  const [ukupanBrZahteva, setUkupanBrZahteva] = React.useState<number>(0);

  const [datasArray, setDatasArray] = React.useState<IData[]>([
    {
      ime: "error1",
      prezime: "a",
      korisnickoIme: "s",
      uloga: 1,
      statusNaloga: 0,
      email: "@",
      history: [{ data: "greska" }],
    },
  ]);

  /////sort
  const [openSort, setOpenSort] = React.useState(false);
  const handleClickSortOpen = () => {
    setOpenSort(true);
  };
  //
  const [selectedSortValue, setSelectedSortValue] = React.useState(0);
  /////

  ///////filter
  const [openFilter, setOpenFilter] = React.useState(false);
  const handleClickFilterOpen = () => {
    setOpenFilter(true);
  };
  //
  const [selectedStatusNaloga, setSelectedStatusNaloga] = React.useState(""); //u enum u fetch
  const [selectedUloga, setSelectedUloga] = React.useState(""); //za fetch ako je "" ide null
  const [selectedUsername, setSelectedUsername] = React.useState("");
  const [primeniFilterPotvrda, setPrimeniFilterPotvrda] = React.useState(false);
  ///////

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  useEffect(() => {
    //setRowsPerPage
    fetchKorisnici(
      setDatasArray,
      rowsPerPage,
      page,
      ukupanBrZahteva,
      setUkupanBrZahteva,
      selectedStatusNaloga,
      selectedUsername,
      selectedUloga,
      selectedSortValue
    );
  }, [rowsPerPage, primeniFilterPotvrda, selectedSortValue]); //mozda samo na open close filter sort

  return (
    <Paper className={classes.rootMain}>
      <TableContainer component={Paper}>
        <Table aria-label="collapsible table">
          <TableHead className={classes.header}>
            <TableRow>
              <TableCell />
              {headCells.map((headCell) => (
                <TableCell
                  key={headCell.id}
                  align={headCell.numeric ? "right" : "left"}
                  padding={headCell.disablePadding ? "none" : "default"}
                >
                  {headCell.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {datasArray
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((rowa, index) => {
                return (
                  <Row
                    key={rowa.korisnickoIme}
                    row={{
                      ime: rowa.ime,
                      prezime: rowa.prezime,
                      korisnickoIme: rowa.korisnickoIme,
                      email: rowa.email,
                      uloga: typeof rowa.uloga === "number" ? rowa.uloga : 0,
                      statusNaloga:
                        typeof rowa.statusNaloga === "number"
                          ? rowa.statusNaloga
                          : 0,
                      history:
                        typeof rowa.history === "object" ? rowa.history : [],
                    }}
                  />
                );
              })}
          </TableBody>
        </Table>
      </TableContainer>
      <Fab
        variant="round"
        size="small"
        color="primary" //mozda secondary
        className={classes.dugmeFabSortr}
        onMouseDown={() => {
          handleClickSortOpen();
        }}
      >
        {<SortOutlinedIcon />}
      </Fab>

      <Fab
        variant="round"
        size="small"
        color="primary"
        className={classes.dugmeFabFilter}
        onMouseDown={() => {
          handleClickFilterOpen();
        }}
      >
        {<FilterListOutlinedIcon />}
      </Fab>
      {Sort(openSort, setOpenSort, selectedSortValue, setSelectedSortValue)}
      {Filter(
        openFilter,
        setOpenFilter,
        selectedUsername,
        setSelectedUsername,
        selectedUloga,
        setSelectedUloga,
        selectedStatusNaloga,
        setSelectedStatusNaloga,
        primeniFilterPotvrda,
        setPrimeniFilterPotvrda
      )}
      <TablePagination
        rowsPerPageOptions={[5, 10, 15, 20]}
        component="div"
        count={ukupanBrZahteva}
        rowsPerPage={rowsPerPage}
        page={page}
        onChangePage={handleChangePage}
        onChangeRowsPerPage={handleChangeRowsPerPage}
      />
    </Paper>
  );
}
