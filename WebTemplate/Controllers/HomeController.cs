using System.Web.Mvc;
using System.Web;
using WebTemplate.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebTemplate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}