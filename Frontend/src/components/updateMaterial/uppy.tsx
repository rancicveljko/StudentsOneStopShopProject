import React from "react";
import Uppy from "@uppy/core";
import Tus from "@uppy/tus";
import { Box, Button } from "@material-ui/core";
import Webcam from "@uppy/webcam";
import GoogleDrive from "@uppy/google-drive";
import OneDrive from "@uppy/onedrive";
import DropTarget from "@uppy/drop-target";
import "@uppy/core/dist/style.css";
import "@uppy/drag-drop/dist/style.css";
import "@uppy/core/dist/style.css";
import "@uppy/dashboard/dist/style.css";
import GoldenRetriever from "@uppy/golden-retriever";
import DragDrop from "@uppy/drag-drop";
import Url from "@uppy/url";
import { URL } from "../konstante";
import { IOblast } from "./interface";

const { DashboardModal } = require("@uppy/react");

export default function Uppyy(
  naziv: string,
  opis: string,
  selectedVal: IOblast,
  opisZahteva:string
) {
  const uppy = Uppy({
    debug: true,
    meta: {
      Putanja: selectedVal.path,
      Naziv: naziv,
      TipZahteva: "1",//0 je za new file //1 je za update

      TekstZahteva:opisZahteva,//ko nema odobrenje// i da l je nadlezan
      //admin nema ""
      //napredni iz fetch za oblasti true/false   potrebnp odobrenje kad nije nadlezan
      //potrebnp odobrenje

      KratakOpis: opis,
     
      TrenutnaeEkstenzijaFajla:".jpg",//za update,
      VremeSlanja: new Date(Date.now()).toISOString(),  
    },
    autoProceed: true,
    restrictions: {
      maxNumberOfFiles: 1,
      allowedFileTypes: [
        "image/jpeg",
        "image/png",
        "application/pdf",
        "application/vnd.ms-powerpoint",
        "application/vnd.openxmlformats-officedocument.presentationml.presentation",
        "application/msword",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/vnd.ms-excel",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "application/zip",
        "application/x-rar-compressed",
        "video/mp4",
      ],
    },
  })
    /*.use(DashboardModal, {
      //id:"DbModal",
      trigger: ".UppyModalOpenerBtn",
      inline: true,
      target: ".DashboardContainer",
      replaceTargetContent: true,
      showProgressDetails: true,
      note: "Images and video only, 2–3 files, up to 1 MB",
      height: 470,
      metaFields: [
        { id: "name", name: "Name", placeholder: "file name" },
        {
          id: "caption",
          name: "Caption",
          placeholder: "describe what the image is about",
        },
      ],
      browserBackButtonClose: false,
    })*/
    .use(Tus, {
      endpoint: URL + "/fajlovi", //server
      withCredentials: true,
      retryDelays: [0, 1000, 3000, 5000], //mzd?
      //resume: true,//nece da prihvati /mzd zbog retriver
      removeFingerprintOnSuccess: true,
      autoRetry: true,
    })
    .use(Webcam)
    .use(GoogleDrive, { companionUrl: URL + "/fajlovi" })
    .use(OneDrive, { companionUrl: URL + "/fajlovi" })
    .use(Url, { companionUrl: URL + "/fajlovi" })
    .use(DragDrop)
    .use(GoldenRetriever)
    .on("complete", (result: any) => {
      const url = result.successful[0].uploadURL;
      console.log("successful files:", result.successful);
      console.log("failed files:", result.failed);
    });
  return (
    <Box>
      <DashboardModal
        uppy={uppy}
        open={false}
        target={document.body}
        showProgressDetails={true}
        showLinkToFileUploadResult={false}
        theme={"dark"}
        plugins={[
          "Tus",
          "Webcam",
          "GoogleDrive",
          "OneDrive",
          "Url",
          "DragDrop",
        ]}
        trigger="#dashboardmodal"
      />
    </Box>
  );
}
