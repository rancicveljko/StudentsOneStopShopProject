import React from "react";
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
import { IData, IZahtevID, MoreInfo, headCells } from "./interfaces";

import {
  fetchZahtevi,
  fetchZahtevTekst,
  ObradiZahtev,
  FetchBrojZahteva,
} from "./fetches";
import { useEffect } from "react";

export function TipZahtevaObrada(val: number) {
  let a: string;
  switch (val) {
    case 1:
      a = "Ukidanje privilegija komentarisanja";
      break;
    case 2:
      a = "Ukidanje privilegija ocenjivanja";
      break;
    case 4:
      a = "Ukidanje privilegija dodavanja materijala";
      break;
    case 8:
      a = "Blokiranje korisničkog naloga";
      break;
    case 16:
      a = "Deblokiranje korisničkog naloga";
      break;
    default:
      a = "greska";
      break;
  }
  return a;
}

function PrihvatiZahtev(idPodaci: IZahtevID, fetchZaRender: Function) {
  idPodaci.prihvacen = "true";
  ObradiZahtev(idPodaci, fetchZaRender);
  alert(idPodaci.vremeSlanja + idPodaci.korisnickoImeAutora);
}

function OdbijZahtev(idPodaci: IZahtevID, fetchZaRender: Function) {
  idPodaci.prihvacen = "false";
  ObradiZahtev(idPodaci, fetchZaRender);
  alert(idPodaci.vremeSlanja + idPodaci.korisnickoImeAutora);
}

function Row(prop: { row: IData; fetchZaRender: Function }) {
  const row = prop.row;
  const fetchZaRender = prop.fetchZaRender;
  const [open, setOpen] = React.useState(false);
  const [isFetched, setIsFetched] = React.useState(false);
  const classes = useStyles();

  useEffect(() => {
    if (row.history.length === 0) setOpen(false); //patch
  }, [row]);

  return (
    <React.Fragment>
      <TableRow
        className={classes.root}
        tabIndex={-1}
        key={row.vremeSlanja + row.korisnickoImeAutora}
        hover
      >
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={(event) => {
              setOpen(!open);
              if (!isFetched) {
                //setOpen(false);
                fetchZahtevTekst({
                  vremeSlanja: row.vremeSlanja,
                  korisnickoImeAutora: row.korisnickoImeAutora,
                })
                  .then((response) => response.json())
                  .then((x: { tekst: string }) => {
                    row.history = [
                      {
                        data: x.tekst,
                      },
                    ];
                    setIsFetched(true);
                  })
                  .catch(() => {
                    row.history = [
                      {
                        data: "greska",
                      },
                    ];
                  });
              }
            }}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>

        <TableCell>{row.korisnickoImeAutora}</TableCell>
        <TableCell>{row.korisnickoImeSubjekta}</TableCell>
        <TableCell>{row.vremeSlanja}</TableCell>
        <TableCell>{TipZahtevaObrada(row.tip)}</TableCell>
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
                Tekst zahteva
              </Typography>
              <Table size="small" aria-label="purchases">
                {/* <TableHead></TableHead> */}
                <TableBody>
                  {!isFetched && <CircularProgress />}
                  {isFetched &&
                    row.history.map((historyRow) => (
                      <TableRow key={historyRow.data}>
                        <TableCell component="th" scope="row">
                          <Typography
                            style={{
                              wordWrap: "break-word",
                              width: "80%",
                              whiteSpace: "pre-wrap",
                              overflow: "hidden",
                            }}
                          >
                            {historyRow.data}
                          </Typography>
                        </TableCell>
                      </TableRow>
                    ))}
                </TableBody>
              </Table>
              <Box className={classes.buttonBox}>
                <Box>
                  <Button
                    className={classes.button}
                    onClick={() =>
                      PrihvatiZahtev(
                        {
                          vremeSlanja: row.vremeSlanja,
                          korisnickoImeAutora: row.korisnickoImeAutora,
                        },
                        fetchZaRender
                      )
                    }
                  >
                    Prihvati zahtev
                  </Button>
                </Box>
                <Box>
                  <Button
                    className={classes.button}
                    onClick={() =>
                      OdbijZahtev(
                        {
                          vremeSlanja: row.vremeSlanja,
                          korisnickoImeAutora: row.korisnickoImeAutora,
                        },
                        fetchZaRender
                      )
                    }
                  >
                    Odbij zahtev
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

export default function TableZahtevi() {
  const classes = useStyles();
  const [page, setPage] = React.useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = React.useState<number>(10);
  const [ukupanBrZahteva, setUkupanBrZahteva] = React.useState<number>(0);

  const [datasArray, setDatasArray] = React.useState<IData[]>([
    {
      korisnickoImeAutora: "error",
      korisnickoImeSubjekta: "",
      vremeSlanja: "",
      tip: 1,
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
  const [selectedTip, setSelectedTip] = React.useState(""); //u enum u fetch
  const [selectedNameAutor, setSelectedNameAutor] = React.useState(""); //za fetch ako je "" ide null
  const [selectedNameSubject, setSelectedNameSubject] = React.useState("");
  const [selectedDate1, setSelectedDate1] = React.useState<Date | null>(
    new Date()
  );
  const [selectedDate2, setSelectedDate2] = React.useState<Date | null>(
    new Date()
  );

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
    fetchZahtevi(
      setDatasArray,
      rowsPerPage,
      page,
      ukupanBrZahteva,
      setUkupanBrZahteva,
      selectedTip,
      selectedNameAutor,
      selectedNameSubject,
      selectedDate1,
      selectedDate2,
      selectedSortValue
    );
  }, [
    rowsPerPage,
    primeniFilterPotvrda,
    selectedSortValue, 
  ]);

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
                    key={rowa.korisnickoImeAutora + rowa.vremeSlanja}
                    row={{
                      korisnickoImeAutora: rowa.korisnickoImeAutora,
                      korisnickoImeSubjekta: rowa.korisnickoImeSubjekta,
                      vremeSlanja: rowa.vremeSlanja,
                      tip: typeof rowa.tip === "number" ? rowa.tip : 0,
                      history:
                        typeof rowa.history === "object" ? rowa.history : [],
                    }}
                    fetchZaRender={() =>
                      fetchZahtevi(
                        setDatasArray,
                        rowsPerPage,
                        page,
                        ukupanBrZahteva,
                        setUkupanBrZahteva,
                        selectedTip,
                        selectedNameAutor,
                        selectedNameSubject,
                        selectedDate1,
                        selectedDate2,
                        selectedSortValue
                      )
                    }
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
        selectedTip,
        setSelectedTip,
        selectedNameAutor,
        setSelectedNameAutor,
        selectedNameSubject,
        setSelectedNameSubject,
        selectedDate1,
        setSelectedDate1,
        selectedDate2,
        setSelectedDate2,
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
