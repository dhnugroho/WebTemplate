using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class CostVerifyController : Controller
    {
        // GET: CostVerify
        public ActionResult Index()
        {
            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "AC111", Name = "John", Age = 1, Amount = 1000000, City = "Surabaya" } ,
                            new Participant() { NoregId = "AC112", Name = "Steve",  Age = 21, Amount = 50000000, City = "Malang" } ,
                            new Participant() { NoregId = "AC113", Name = "Bill",  Age = 25, Amount = 6000000, City = "Situbondo" } ,
                            new Participant() { NoregId = "AC114", Name = "Ram" , Age = 1, Amount = 3000000, City = "Cirebon" } ,
                            new Participant() { NoregId = "AC115", Name = "Ron" , Age = 31, Amount = 2000000, City = "Indramayu" } ,
                            new Participant() { NoregId = "AC116", Name = "Chris" , Age = 17, Amount = 4000000, City = "Jepang" } ,
                            new Participant() { NoregId = "AC117", Name = "Rob" , Age = 1, Amount = 5000000, City = "Papua" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }
    }
}