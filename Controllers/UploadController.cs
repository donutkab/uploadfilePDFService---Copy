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
    public class UploadController : ApiController
    {




        [HttpPost]
        [Route("api/UploadPdf")]

        public HttpResponseMessage UploadPdf()
        {
            string fileName = null;
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            fileName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ","-");
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + fileName);
            postedFile.SaveAs(filePath);

            //Save To database

            using (UploadFileEntities db = new UploadFileEntities())
            {
                Tbl_File file = new Tbl_File()
                {
                    FileCaption = httpRequest["ImageCaption"],
                    FileName = fileName
                };
                db.Tbl_File.Add(file);
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    } 
}
