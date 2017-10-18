using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Participant
        public ActionResult Index()
        {
            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "TS111", Name = "John", Age = 1, Amount = 1000000, City = "Surabaya" } ,
                            new Participant() { NoregId = "TS112", Name = "Steve",  Age = 21, Amount = 50000000, City = "Malang" } ,
                            new Participant() { NoregId = "TS113", Name = "Bill",  Age = 25, Amount = 6000000, City = "Situbondo" } ,
                            new Participant() { NoregId = "TS114", Name = "Ram" , Age = 1, Amount = 3000000, City = "Cirebon" } ,
                            new Participant() { NoregId = "TS115", Name = "Ron" , Age = 31, Amount = 2000000, City = "Indramayu" } ,
                            new Participant() { NoregId = "TS116", Name = "Chris" , Age = 17, Amount = 4000000, City = "Jepang" } ,
                            new Participant() { NoregId = "TS117", Name = "Rob" , Age = 1, Amount = 5000000, City = "Papua" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }

        [HttpPost]
        public ActionResult Edit(Participant std)
        {
            // update Participant to the database

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // delete Participant from the database whose id matches with specified id

            return RedirectToAction("Index");
        }

        public ActionResult ParticipantDesktop()
        {
            ViewBag.Message = "Hello MVC!";
            return View();
        }
    }
}