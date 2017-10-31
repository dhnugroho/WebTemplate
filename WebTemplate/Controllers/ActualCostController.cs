using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTemplate.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq.Dynamic;

namespace WebTemplate.Controllers
{
    public class ActualCostController : Controller
    {
        private dbFilesEntities1 db = new dbFilesEntities1();
        // GET: ActualCost
        public ActionResult Index(int page = 1, string sort = "Name", string sortdir = "asc", string search = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetData(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<tbl_registration> GetData(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using (dbFilesEntities1 dc = new dbFilesEntities1())
            {
                var v = (from a in dc.tbl_registration
                         where
                                 a.Email.Contains(search) ||
                                 a.Name.Contains(search) ||
                                 a.City.Contains(search)
                         select a
                                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if (pageSize > 0)
                {
                    v = v.Skip(skip).Take(pageSize);
                }
                return v.ToList();
            }
        }

        public ActionResult Cost()
        {
            var ParticipantList = new List<Participant>{
                            new Participant() { NoregId = "ID111", Name = "John", Age = 1, Amount = 1000000, City = "Surabaya" } ,
                            new Participant() { NoregId = "ID112", Name = "Steve",  Age = 21, Amount = 50000000, City = "Malang" } ,
                            new Participant() { NoregId = "ID113", Name = "Bill",  Age = 25, Amount = 6000000, City = "Situbondo" } ,
                            new Participant() { NoregId = "ID114", Name = "Ram" , Age = 1, Amount = 3000000, City = "Cirebon" } ,
                            new Participant() { NoregId = "ID115", Name = "Ron" , Age = 31, Amount = 2000000, City = "Indramayu" } ,
                            new Participant() { NoregId = "ID116", Name = "Chris" , Age = 17, Amount = 4000000, City = "Jepang" } ,
                            new Participant() { NoregId = "ID117", Name = "Rob" , Age = 1, Amount = 5000000, City = "Papua" }
                        };
            // Get the Participants from the database in the real application

            return View(ParticipantList);
        }
    }
}