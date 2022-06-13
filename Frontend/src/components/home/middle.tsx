import { Box, List, ListItem, Typography } from "@material-ui/core";
import useStyles from "./homeStyles";
import InsertDriveFileOutlinedIcon from "@material-ui/icons/InsertDriveFileOutlined";
import { INode, ISadrzaj } from "./homeInterfaces";

const element = <InsertDriveFileOutlinedIcon />;

export default function Middle(
  data: ISadrzaj,
  selectedFile: INode,
  setselectedFile: (x: INode) => void
) {
  const classes = useStyles();

  return (
    <Box >
      <List key="root" className={classes.Middle}>
        {data.files.map((x) => (
          <Box className={classes.MiddleItem}>
            <ListItem
              key={data.path + x}
              onMouseDown={() => {
                setselectedFile({ path: data.path, naziv: x });
              }}
            >
              <InsertDriveFileOutlinedIcon
                className={
                  selectedFile.naziv === x
                    ? classes.FileClicked
                    : classes.FileNotClicked
                }
              ></InsertDriveFileOutlinedIcon>
              <span>&nbsp;&nbsp;</span>
              <Typography
                className={
                  selectedFile.naziv === x
                    ? classes.FileClicked
                    : classes.FileNotClicked
                }
              >
                {x}
              </Typography>
            </ListItem>
          </Box>
        ))}
      </List>
    </Box>
  );
}
