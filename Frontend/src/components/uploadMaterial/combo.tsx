import { Autocomplete, TreeItem, TreeView } from "@material-ui/lab";
import React from "react";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import { IOblast, ITree } from "./interface";
import { Box, Checkbox, Radio, TextField } from "@material-ui/core";
import { FetchAllOblastiLista } from "./fetches";

export default function ComboBox(
  style: any,
  selectedVal: IOblast,
  setSelectedVal: (a:IOblast)=>void,
  oblastiData: IOblast[],
  setOblastiData: (a:IOblast[])=>void
) {
  return (
    <Autocomplete
      id="cb"
      options={oblastiData}
      value={selectedVal}
      onInputChange={(event, newInputValue) => setSelectedVal(findINode(oblastiData,newInputValue))}
      getOptionLabel={(option) => option.path}
      renderInput={(params) => (
        <TextField {...params} label="Oblast" variant="outlined" required />
      )}
    />
  );
}

function findINode(all:IOblast[],target:string):IOblast{
    for(let i=0;i<all.length;i++){
      const x=all[i];
      if(x.path===target) {alert(x.path);return x;}
    }
    return{    path: "",
    odobrenje: true,}
}