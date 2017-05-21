using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FKM_Diagnostic_Center.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

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
           
 
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Usertype"].ToString() == "admin") {
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
            if (Session["Usertype"].ToString() == "admin")
            {
                if (ModelState.IsValid)
                {
                    UserDBContext context = new UserDBContext();
                    p.PDate = DateTime.Now;
                    p.PBill = p.testId;
                    context.Patients.Add(p);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(p);
                }
            }
            else
            {
                return View("error");
            }
        }
        [HttpGet]
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
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                ViewBag.Tests = new SelectList(context.Tests.ToList(), "testId", "testName");
                Patient p = context.Patients.SingleOrDefault(d => d.PId == id);
                return View(p);
            }
            else
            {
                return View("error");
            }
        }
        [HttpPost,ActionName("Edit")]
        public ActionResult Do_Edit(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                Patient p = context.Patients.SingleOrDefault(d => d.PId == id);
                ViewBag.Tests = new SelectList(context.Tests.ToList(), "testId", "testName");
                TryUpdateModel(p, new string[] { "PName", "PAddress", "PAge", "PPhone", "PDate", "PBill", "testId" });
                if (ModelState.IsValid)
                {
                    p.PDate = DateTime.Now;
                    p.PBill = p.Test.testBill;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(p);
            }
            else
            {
                return View("error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                Patient pnt = context.Patients.Include("Test").SingleOrDefault(p => p.PId == id);
                return View(pnt);
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Confirm_Delete(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                Patient p = context.Patients.SingleOrDefault(d => d.PId == id);
                context.Patients.Remove(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View("error");
            }
        }
    }
}
