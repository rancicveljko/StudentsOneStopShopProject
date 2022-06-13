import { URL } from "../konstante";
import { IOblast } from "./interface";

export function FetchAllOblastiLista(setData:(a:IOblast[])=>void) {//then catch
  //ima je u acc update
  //ime je u new acc
  //i u table oblasti
  //alert("test fetch")
  /*fetch(`${URL}/oblasti/pribavisve`, {
    method: "get",
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
    },
  })
    .then((response) => {
      if (!response.ok) throw Error("Nije uspeo fetch svih oblasti");
      return response;
    })
    .then((response) => response.json())
    .then((x: { putanja: string,odobrenje:boolean,naziv:string}[]) => {
      setData(x.map((val) => {return {   
        path: val.putanja,
        naziv: val.naziv,
        odobrenje: val.odobrenje,
      }}));
    })
    .catch((e) => {
      alert(e);
    });*/
    setData([{path:"neeee",odobrenje:false},{path:"dddddd",odobrenje:true}])
}
