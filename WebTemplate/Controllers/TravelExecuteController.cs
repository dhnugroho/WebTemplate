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
            //List Travel On Going , one travel
            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "TE111", Name = "John", Age = 18, Amount = 1000000, City = "Surabaya" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }

        public ActionResult Executed()
        {
            dbFilesEntities1 db = new dbFilesEntities1();
            return View();
        }

        public JsonResult ImageUpload(ImageViewModel model)
        {
            dbFilesEntities1 db = new dbFilesEntities1();
            int ImgId = 0;
            var Lat = "Latitude";
            var Lon = "Longitude";
            var file = model.ImageFile;
            byte[] Imagebyte = null;

            if (file != null)
            {

                //var fileName = Path.GetFileName(file.FileName);
                //var extention = Path.GetExtension(file.FileName);
                //var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/UploadImage/" + file.FileName));

                BinaryReader reader = new BinaryReader(file.InputStream);

                Imagebyte = reader.ReadBytes(file.ContentLength);

                StoreImage img = new StoreImage();
                img.Lat = Lat;
                img.Lon = Lon;
                img.ImgTitle = file.FileName;
                img.ImgByte = Imagebyte;
                img.ImgPath = "/UploadedImage/" + file.FileName;
                img.IsDelete = 0;
                db.StoreImages.Add(img);
                db.SaveChanges();

                ImgId = img.ImgId;

            }

            return Json(ImgId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ImageRetrieve(int imgID)
        {
            dbFilesEntities1 db = new dbFilesEntities1();
            var img = db.StoreImages.SingleOrDefault(x => x.ImgId == imgID);
            return File(img.ImgByte, "image/jpg");
        }
    }
}