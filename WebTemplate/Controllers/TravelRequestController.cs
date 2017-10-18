using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class TravelRequestController : Controller
    {
        // GET: TravelRequest
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "BCA", Name = "Steve",  Age = 21, Amount = 337556412, City = "Malang" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }
    }
}