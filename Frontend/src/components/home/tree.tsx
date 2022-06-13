import { TreeItem, TreeView } from "@material-ui/lab";
import React from "react";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import useStyles from "./homeStyles";
import { INode, IOblastSadrzaj, ITree } from "./homeInterfaces";
import { Button } from "@material-ui/core";

export default function TreeFunction(
  tree: ITree[],
  selectedOblast:INode,
  handleOblastClick: (a: INode) => Promise<any>,
  setTree: Function,
  setListaMaterijal: Function,
  setselectedFile: Function
) {
  const classes = useStyles();
  return (
    <TreeView
      key="treeView"
      className={classes.tree}
      defaultCollapseIcon={<ExpandMoreIcon />}
      defaultExpandIcon={<ChevronRightIcon />}
    >
      {Tree(
        tree,
        selectedOblast,
        handleOblastClick,
        classes.treeItem,
        setTree,
        tree,
        setListaMaterijal,
        setselectedFile
      )}
    </TreeView>
  );
}

function Tree(
  tree: ITree[],
  selectedOblast:INode,
  handleOblastClick: (a: INode) => Promise<any>,
  treeItem: any,
  setTree: Function,
  fullTree: ITree[],
  setListaMaterijal: Function,
  setselectedFile: Function
) {
  return tree.map((x) => (
    <TreeItem
      className={treeItem}
      onMouseDown={() => {
        {
          if (x.children.length === 0) {
            handleOblastClick({ path: x.path, naziv: x.name })
              .then((response) => response.json())
              .then((val: IOblastSadrzaj) => {
                setListaMaterijal({
                  path: x.path + "/" + x.name,
                  files: val.materijali,
                });
                const pom: ITree[] = [];
                val.podoblasti.forEach((p) => {
                  pom.push({
                    name: p,
                    path: x.path + "/" + x.name,
                    children: [],
                  });
                });
                alert(
                  pom.reduce((acc, curr) => {
                    return (acc += curr.name);
                  }, "in:")
                );
                setselectedFile({
                  naziv: val.materijali[0],
                  path: x.path + "/" + x.name,
                });
                x.children = pom;
                setTree([...fullTree]);
                alert(
                  x.children.reduce((acc, curr) => {
                    return (acc += curr.name);
                  }, "unutra tree:")
                );
              })
              .catch((e) => alert(e + "ne valja"));
          }
        }
      }}
      color={x.path===selectedOblast.path&&x.name===selectedOblast.naziv?"#ff3c64":"#ffffff"}//provera???????????
    
      key={x.path + "/" + x.name}
      nodeId={x.path + "/" + x.name}
      label={x.name}
    >
      {Tree(
        x.children,
        selectedOblast,
        handleOblastClick,
        treeItem,
        setTree,
        fullTree,
        setListaMaterijal,
        setselectedFile
      )}
    </TreeItem>
  ));
}
