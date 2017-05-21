using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FKM_Diagnostic_Center.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        public ActionResult Create()
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                ViewBag.Tests = new SelectList(context.Tests.ToList(), "testId", "testName");
                return View();
            }
            else
            {
                return View("error");
            }

        }

        [HttpPost]
        public ActionResult Create(Patient p)
        {
            return View();
        }

      
        public ActionResult Index()
        {
            if (Session["Usertype"].ToString() == "admin")
            {

                UserDBContext context = new UserDBContext();
                if (Session["Usertype"].ToString() == "admin")
                {
                    return View(context.Patients.Include("Test").ToList());
                }
                else
                {
                    return View("error");
                }
            }
            else
            {
                return View("error");
            }
        }
        public ActionResult Search(string names)
        {

            if (!string.IsNullOrWhiteSpace(names))
            {
                UserDBContext context = new UserDBContext();
                Patient pnt = context.Patients.Include("Test").SingleOrDefault(p => p.PName == names);

                return View(pnt);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int Id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                Patient pnt = context.Patients.Include("Test").SingleOrDefault(p => p.PId == Id);
                return View(pnt);
            }
            else
            {
                return View("error");
            }
        }

           


    }
}
