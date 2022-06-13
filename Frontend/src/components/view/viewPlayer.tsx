import { Box } from "@material-ui/core";
import React from "react";
import ReactPlayer from "react-player";
import { useStyles } from "./viewStyles";
import { URL } from "../konstante";

export default function ViewPlayer() {
  const classes = useStyles();
  return (
    <Box
      width="auto" // Reset width
      height="auto"
    >
      <ReactPlayer
        padding-top="56.25%"
        position="relative"
        width="100%"
        height="99vh"
        playing={true}
        controls={true}
        url={URL + "/materijal/get"} ///izgleda bolje ne
      />
    </Box>
  );
}
/** style={{
          position: "absolute",
          top: "0",
          left: "0",
          padding: "0",
          margin: "0",
          width:"100vw",
          height:"100vh",
        }} */
