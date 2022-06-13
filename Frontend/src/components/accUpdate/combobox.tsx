import { TextField } from "@material-ui/core";
import { Autocomplete, TreeItem, TreeView } from "@material-ui/lab";
import { FetchAllOblastiLista } from "./fetch";

export default function ComboB(
  style: any,
  hadleSetValues: (pom: string[]) => void,
  values: string[],
  handle: Function,
  tr: { val: string[]; all: string[] },
  setTr: Function
) {
  if (tr.all.length === 0) FetchAllOblastiLista(tr, setTr);
  return (
    <Autocomplete
      multiple
      id="oblast"
      options={tr.all}
      getOptionLabel={(option) => option}
      filterSelectedOptions
      fullWidth
      onChange={(event, newInputValue) => hadleSetValues(newInputValue)}
      renderInput={(params) => (
        <TextField {...params} variant="outlined" label="Oblasti" />
      )}
    />
  );
}
