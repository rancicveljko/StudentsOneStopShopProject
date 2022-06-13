import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import {} from "@material-ui/core/colors/blue";
import { createMuiTheme, MuiThemeProvider } from "@material-ui/core";
import CssBaseline from "@material-ui/core/CssBaseline";

const theme = createMuiTheme({
  palette: {
    primary: {
      light: "#e6ffff",
      main: "#98ccfc",
      dark: "#82b3c9",
      contrastText: "#000",
    },
    secondary: {
      light: "#ff7961",
      main: "#f88cb4",
      dark: "#ba6b6c",
      contrastText: "#000",
    },
    type: "dark",
  },
  typography: {
    //fontFamily: `"Roboto", "Helvetica", "Arial", sans-serif`,
    //fontSize: 16,
  },
});

ReactDOM.render(
  <React.StrictMode>
    <MuiThemeProvider theme={theme}>
      <CssBaseline />
      <App />
    </MuiThemeProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
