import { Box } from "@material-ui/core";
import { Pagination } from "@material-ui/lab";

export default function AllTabs(classes:any,num: number) {
  return (
    <Box className={classes.Paging}>
      <Pagination count={num} variant="outlined" color="primary" size="large" />
    </Box>
  );
}