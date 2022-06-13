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
import { IData, MoreInfo, headCells } from "./interfaces";

import {
  fetchMaterijali,
  fetchDodatneInfo,
  FetchBrojMaterijala,
} from "./fetches";
import { useEffect } from "react";

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
  const classes = useStyles();

  useEffect(() => {
    if (row.history.length === 0) setOpen(false); //patch
  }, [row]);

  return (
    <React.Fragment>
      <TableRow
        className={classes.root}
        tabIndex={-1}
        key={row.path + row.naziv}
        hover
      >
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={(event) => {
              setOpen(!open);
              if (!isFetched) {
                // setOpen(false);
                // fetchZahtevTekst({
                //   vremeSlanja: row.datum,
                //   korisnickoImeAutora: row.KorisnckoImeAutora,
                // })
                //   .then((response) => response.json())
                //   .then((x: string) => {
                //     row.history = [
                //       {
                //         data: x,
                //       },
                //     ];
                //     setIsFetched(true);
                //   })
                //   .catch(() => {
                //     row.history = [
                //       {
                //         data: "greska",
                //       },
                //     ];
                //   });
                setTimeout(() => {
                  //test
                  row.history = [
                    {
                      data: "delayyy",
                    },
                  ];
                  setIsFetched(true);
                }, 2000);
              }
            }}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell>{row.path}</TableCell>
        <TableCell>{row.naziv}</TableCell>
        <TableCell>{row.odobrenje}</TableCell>
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
              {/* <Box className={classes.buttonBox}>//prosirenje dugmici rename!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!...
                <Box>
                  <Button
                    className={classes.button}
                    onClick={() =>
                      PrihvatiZahtev({
                        vremeSlanja: row.datum,
                        korisnickoImeAutora: row.KorisnckoImeAutora,
                      })
                    }
                  >
                    Prihvati zahtev
                  </Button>
                </Box>
                <Box>
                  <Button
                    className={classes.button}
                    onClick={() =>
                      OdbijZahtev({
                        vremeSlanja: row.datum,
                        korisnickoImeAutora: row.KorisnckoImeAutora,
                      })
                    }
                  >
                    Odbij zahtev
                  </Button>
                </Box>
              </Box> */}
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </React.Fragment>
  );
}

export default function TableOblasti() {
  const classes = useStyles();
  const [page, setPage] = React.useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = React.useState<number>(10);
  const [ukupanBrZahteva, setUkupanBrZahteva] = React.useState<number>(0);

  const [datasArray, setDatasArray] = React.useState<IData[]>([
    {
      path: "error",
      naziv: "",
      odobrenje: "",
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
  const [selectedExtension, setSelectedExtension] = React.useState(""); //za fetch ako je "" ide null
  const [selectedName, setSelectedName] = React.useState(""); //za fetch ako je "" ide null
  const [selectedStatus, setSelectedStatus] = React.useState(""); //za fetch ako je "" ide null
  const [selectedPotrebnoOdobrenje, setSelectedPotrebnoOdobrenje] =
    React.useState("");
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
    fetchMaterijali(
      setDatasArray,
      rowsPerPage,
      page,
      ukupanBrZahteva,
      setUkupanBrZahteva,
      selectedExtension,
      selectedName,
      selectedStatus,
      selectedSortValue
    );
  }, [rowsPerPage, selectedExtension, selectedName, selectedSortValue]); //mozda samo na open close filter sort

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
                    key={(rowa.path + rowa.naziv).toString()}
                    row={{
                      path: rowa.path,
                      naziv: rowa.naziv,
                      odobrenje: rowa.odobrenje,
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
        selectedExtension,
        setSelectedExtension,
        selectedName,
        setSelectedName,
        selectedPotrebnoOdobrenje,
        setSelectedPotrebnoOdobrenje
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
