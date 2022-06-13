import { Box } from "@material-ui/core";
import { URL } from "../konstante";

//import FileViewer from 'react-file-viewer';
//import { CustomErrorComponent } from 'custom-error';

const FileViewer = require("react-file-viewer");

//const file = 'http://localhost:3000/DrugaFaza.pdf'//mora http bez s i usrc za veliki pdf

//const file = 'http://localhost:3000/slika.jpg' //slika ok

//const file = 'http://localhost:3000/mp4.mp4' //video ok

//const file = 'http://loaclhost:3000/Drugafaza.docx'// ne moze direktno src nego samo download

//const file='https://upload.wikimedia.org/wikipedia/en/a/a9/Example.jpg'
//const file='http://png.pngitem.com/pimgs/s/505-5058955_sample-png-images-sample-png-transparent-png.png'
//const file='https://file-examples-com.github.io/uploads/2017/08/file_example_PPT_500kB.ppt' //radi sa drugi iframe za online
//const file = "https://file-examples-com.github.io/uploads/2017/02/file-sample_500kB.docx"; //radi sa drugi iframe
const file = URL + "/materijal/get";

//const type = 'pdf'
//const type = 'jpg'
//const type = "png";
//const type = "mp4";
const type = "docx";

//const file = "https://www.youtube.com/watch?v=ysz5S6PUM-U";//ni jedan yt

export default function ViewDoc() {
  //param.history.location.fullPath?.data
  //alert(param);
  return (
    <Box
      style={{ color: "#000000", backgroundColor: "#000", height: "1080px" }}
    >
      <FileViewer
        fileType={type}
        filePath={file}

        //errorComponent={CustomErrorComponent}
        //onError={this.onError}//bez error
      />
    </Box>
    /*<Box
      style={{
        width : "100vw",
        height : "100vh",
        margin: "0px",
        padding: "0px",
        overflow: "hidden",
      }}
    >
      <iframe
        className={type}
        width="100%"
        height="100%"
        frameBorder="0"
        style={{ overflow: "hidden", height: "100%", width: "100%" }}
        src={`https://docs.google.com/gview?url=${file}&embedded=true`}
      ></iframe>
    </Box>*/
    //<Box><iframe frameBorder="0" scrolling="no" width="100%" height="1080px"   src={file} >    <p>iframes are not supported by your browser.</p> </iframe></Box>

    //<iframe src={`http://view.officeapps.live.com/op/embed.aspx?src=${file}`} width='1366px' height='623px' frameBorder='0'>This is an embedded <a target='_blank' href='http://office.com'>Microsoft Office</a> document, powered by <a target='_blank' href='http://office.com/webapps'>Office Online</a>.</iframe>

    //videoo
    /* <Box>
  <video className="video-container video-container-overlay" autoPlay="" loop="" muted="" data-reactid=".0.1.0.0">
  <source type="video/mp4" data-reactid=".0.1.0.0.0" src="mov_bbb.mp4">
</video></Box>*/
  );
}
