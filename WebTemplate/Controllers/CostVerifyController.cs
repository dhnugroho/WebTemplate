using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using WebTemplate.Models;

namespace WebTemplate.Controllers
{
    public class CostVerifyController : Controller
    {
        private dbFilesEntities1 db = new dbFilesEntities1();

        // GET: CostVerify
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
    }
}