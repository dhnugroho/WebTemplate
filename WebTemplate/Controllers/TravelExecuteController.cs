using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class TravelExecuteController : Controller
    {
        // GET: TravelExecute
        public ActionResult Index()
        {
            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "TE111", Name = "John", Age = 18, Amount = 1000000, City = "Surabaya" } ,
                            new Participant() { NoregId = "TE112", Name = "Steve",  Age = 21, Amount = 50000000, City = "Malang" } ,
                            new Participant() { NoregId = "TE113", Name = "Bill",  Age = 25, Amount = 6000000, City = "Situbondo" } ,
                            new Participant() { NoregId = "TE114", Name = "Ram" , Age = 20, Amount = 3000000, City = "Cirebon" } ,
                            new Participant() { NoregId = "TE115", Name = "Ron" , Age = 31, Amount = 2000000, City = "Indramayu" } ,
                            new Participant() { NoregId = "TE116", Name = "Chris" , Age = 17, Amount = 4000000, City = "Jepang" } ,
                            new Participant() { NoregId = "TE117", Name = "Rob" , Age = 19, Amount = 5000000, City = "Papua" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }

        public ActionResult Executed()
        {
            dbFilesEntities1 db = new dbFilesEntities1();
            return View();
        }

        public ActionResult ImageUpload(ImageViewModel model)
        {
            dbFilesEntities1 db = new dbFilesEntities1();
            int imgId = 0;
            var file = model.ImageFile;
            var Lat = "Latitude";
            var Lon = "Longitude";
            byte[] imagebyte = null;
            if(file != null)
            {
                file.SaveAs(Server.MapPath("/UploadImage/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                StoreImage img = new StoreImage();
                img.Lat = Lat;
                img.Lon = Lon;
                img.ImgTitle = file.FileName;
                img.ImgByte = imagebyte;
                img.ImgPath = "/UploadImage/" + file.FileName;
                db.StoreImages.Add(img);
                db.SaveChanges();
                imgId = img.ImgId;
            }
            return Json(imgId, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayingImage(int imgID)
        {
            dbFilesEntities1 db = new dbFilesEntities1();

            var img = db.StoreImages.SingleOrDefault(x => x.ImgId == imgID);
            return File(img.ImgByte, "image/jpg");
        }
    }
}