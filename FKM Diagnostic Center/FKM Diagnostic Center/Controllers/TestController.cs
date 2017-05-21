using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FKM_Diagnostic_Center.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                return View(context.Tests.ToList());
            }
            else
            {
                return View("error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include="testName, testBill")] Test t)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                if (ModelState.IsValid)
                {
                    UserDBContext context = new UserDBContext();
                    t.testDate = DateTime.Now;
                    t.testQuantity = 0;
                    context.Tests.Add(t);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(t);
                }
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
                Test t = context.Tests.SingleOrDefault(d => d.testId == id);
                return View(t);
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Do_Edit(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                Test t = context.Tests.SingleOrDefault(d => d.testId == id);
                TryUpdateModel(t, new string[] { "testBill", "testName" });
                if (ModelState.IsValid)
                {
                    t.testDate = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(t);
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
                Test test = context.Tests.SingleOrDefault(t => t.testId == Id);
                return View(test);
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
                Test t = context.Tests.SingleOrDefault(d => d.testId == id);
                return View(t);
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
                Test t = context.Tests.SingleOrDefault(d => d.testId == id);
                context.Tests.Remove(t);
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