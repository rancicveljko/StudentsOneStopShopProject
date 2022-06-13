import { Box, createMuiTheme, CssBaseline } from "@material-ui/core";
import React from "react";
import Home from "./components/home/home";
import Login from "./components/login/login";
import ViewDoc from "./components/view/viewDoc";
import ViewPlayer from "./components/view/viewPlayer";
import NewAccount from "./components/newAccount/newAccount";
import Upload from "./components/uploadMaterial/upload";
import UpdateMaterial from "./components/updateMaterial/updateMaterial";
import AccUpdate from "./components/accUpdate/accUpdate";
import AccSelfUpdate from "./components/accSeflUpdate/accSelfUpdate"; //<AccSelfUpdate trKorisnickoIme="Mika" />
import TableZahtevi from "./components/tableZahtevi/tableZahtevi";
import TableKorisnickiNalozi from "./components/tableKorisnickiNalozi/tableKorisnickiNalozi";
import TableMaterijali from "./components/tableMaterijali/tableMaterijali";
import TableMaterijaliZahtevi from './components/tableMaterijaliZahtevi/tableZahtevi';
import TableOblasti from "./components/tableOblasti/tableOblasti";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
const App = () => {
  return (
    <Router>
      <React.StrictMode>
        <CssBaseline />
      </React.StrictMode>

      <Switch>
        <Route path="/NewAccount" component={NewAccount} />
        <Route path="/Home" component={Home} />
        <Route path="/Login" component={Login} />
        <Route path="/AccUpdate" component={AccUpdate} />
        <Route path="/AccSelfUpdate" component={AccSelfUpdate} />
        <Route path="/ViewDoc" component={ViewDoc} />
        <Route path="/ViewDoc/:fullPath" component={ViewDoc} />
        <Route path="/Upload" component={Upload} />
        <Route path="/UpdateMaterial" component={UpdateMaterial} />
        <Route path="/TableZahtevi" component={TableZahtevi} />
        <Route path="/TableOblasti" component={TableOblasti} />
        //nista nema
        <Route
          path="/TableKorisnickiNalozi"
          component={TableKorisnickiNalozi}
        />
        <Route path="/TableMaterijali" component={TableMaterijali} />
        <Route path="/TableMaterijaliZahtevi" component={TableMaterijaliZahtevi}/>
        //nista nema
        <Route path="/">
          <TableMaterijali />
        </Route>
      </Switch>
    </Router>
  );
};
//strnicenje za foldere

//table materijali ??

//table korisnicki nalozi za admina popup

//svi tabel su isti (da se usaglase)                        // softfilter styles ako su prazni delete
///tabele oblasti (ce sacekaju)
///table dodavanje materijala

//table (komentarti) low priority

///table korisnicki i materijali na button funkcionalnosi

//table korisnici acc(da se proslede vrednosti) update delete acc
//table materijali za prosirenje (potpuna istorija izmena)

//osnovni korisnik moze da azurira materijal

//sve komponente u Simple Popover ili dialog

//komentri i odgovori na komentare

// dodaj zahtev od profesora za ban itd

//uppy skloniti ? a da izlazi snackbar

//SPEED DIAL koje akcije?

//mozda da se zameni  broj prikaza i stranice u home zbof speed dial

//loginfailpopup transparency
export default App;
