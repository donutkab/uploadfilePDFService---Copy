using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using uploadfilePDFService.Models;

namespace uploadfilePDFService.Controllers
{
    public class WFHController : ApiController
    {

        [HttpPost]
        [Route("api/WFHUpload")]

        public HttpResponseMessage WFHUpload()
        {
            string file_name1 = null;
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            file_name1 = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            file_name1 = file_name1 + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + file_name1);
            postedFile.SaveAs(filePath);

            //Save To database

            using (FDA_DROPBOXEntities db = new FDA_DROPBOXEntities())
            {
                tbl_fileinfo file = new tbl_fileinfo()
                {
                    //FileCaption = httpRequest["ImageCaption"],
                    file_name = file_name1

                };
                db.tbl_fileinfo.Add(file);
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}

