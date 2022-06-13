import {
  AppBar,
  Box,
  makeStyles,
  Tabs,
  Theme,
  Typography,
} from "@material-ui/core";
import { TabPanelProps, Info } from "./interfaces";
import React, { MouseEventHandler } from "react";
import useStyles from "./pregledDataViewStyles";
import ComboBox from "./pregledDataComboBox";
import Filter from "./pregledDataFilter";
import { useFormik } from "formik";
import ActionsInAccordion from "./pregledAccordion";
import AllTabs from "./pagination";
import PribaviZahteve from "./fetch";

function BrojZahteva() {
  return 23;
}

function FilterData() {
  return ["ime", "prezime", "indeks"];
}
//sooortttttttttttttttttt

function fetchOneValue(pageLen: number, offset: number, index: number) {
  const data: string[] = ["1efefe", "2fdfdfd", "3dfdfdfdf", "lol"];
  //return data[offset*pageLen+index];
  return data[index];

  /* fetch(`${USERS_API_URL}`, {
    method: "post",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      KorisnickoIme: values.email,
      Lozinka: values.password,
      ZapamtiMe: values.ZapamtiMe,
    }),
  });*/
}

function ComboBoxValues() {
  return [5, 10, 15, 20];
}

export default function PregledZahtevaDepricated() {////ne koristi se
  {
    const formik = useFormik({
      initialValues: {
        email: "",
        password: "",
        ZapamtiMe: false,
      },
      onSubmit: (values) => {
        alert(JSON.stringify(values, null, 2));
        /* fetch(`${USERS_API_URL}`, {
          method: "post",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            KorisnickoIme: values.email,
            Lozinka: values.password,
            ZapamtiMe: values.ZapamtiMe,
          }),
        });*/
      },
    });

    const [filters, setFilters] = React.useState(["0"]);

    const handleFilter = (val: string[], num: number) => {
      if (filters[0] === "" && filters.length === 1) {
        filters[0] = "";
        for (let i = 0; i < num - 1; i++) {
          filters.push("");
        }
      }
      filters.splice(parseInt(val[0]), 1, val[1]);
    };

    const [pagenum, setPagenum] = React.useState(10); //deafult prikaza po strani

    const handlePagenum = (val: number) => {
      setPagenum(val);
    };

    const [value, setValue] = React.useState(0); //redni broj taba
    const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
      setValue(newValue);
    };

    const FetchData = () => {
      return PribaviZahteve(
        {
          odIndeksa: "",
          koliko: "",
          korisnickoImeAutora: "",
          korisnickoImeSubjekta: "",
          odVreme: "",
          doVreme: "",
          tipZahteva: "",
        }
        /* pagenum * value + 1,
        pagenum * (value + 1) > BrojZahteva()
          ? pagenum * (value + 1)
          : BrojZahteva()
      */
      );
    };

    const classes = useStyles();

    return (
      <form onSubmit={formik.handleSubmit}>
        <div className={classes.root}>
          <AppBar position="static" color="default">
            <Tabs
              value={value}
              onChange={handleChange}
              indicatorColor="primary"
              textColor="primary"
              variant="scrollable"
              scrollButtons="auto"
              aria-label="scrollable auto tabs example"
            >
              {AllTabs(classes, Math.ceil(BrojZahteva() / pagenum))}
            </Tabs>
            <Box className={classes.nav}>
              <Box>{ComboBox(ComboBoxValues(), classes, handlePagenum)}</Box>
              {Filter(FilterData(), classes, handleFilter)}
            </Box>
          </AppBar>
          {}
          <TabPanel value={value} index={value}>
            <Box>
              {ActionsInAccordion(FetchData, fetchOneValue, pagenum, value)}
            </Box>
          </TabPanel>
        </div>
      </form>
    );
  }

  function TabPanel(props: TabPanelProps) {
    const { children, value, index, ...other } = props;

    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`nav-tabpanel-${index}`}
        aria-labelledby={`nav-tab-${index}`}
        {...other}
      >
        {value === index && (
          <Box p={3}>
            <Typography>{children}</Typography>
          </Box>
        )}
      </div>
    );
  }
}

/*backup  <TabPanel value={value} index={1}>
            Item Two
          </TabPanel>
          <TabPanel value={value} index={2}>
            Item Three
          </TabPanel>
          <TabPanel value={value} index={3}>
            Item Four
          </TabPanel>
          <TabPanel value={value} index={4}>
            Item Five
          </TabPanel>
          <TabPanel value={value} index={5}>
            Item Six
          </TabPanel>
          <TabPanel value={value} index={6}>
            Item Seven
          </TabPanel>*/
