using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FKM_Diagnostic_Center.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private static int adminNum, employeeNum;
        [HttpGet]
        public ActionResult Index() //login
        {
            Session["Usertype"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            try
            {
                using (UserDBContext context = new UserDBContext())
                {
                    var usr = context.Users.Single(u => u.username == user.username && u.password == user.password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.id.ToString();
                        Session["Username"] = usr.username.ToString();
                        Session["Usertype"] = usr.type.ToString();
                        if(usr.type == "admin")
                        {
                            ViewBag.adminNum=adminNum++.ToString();
                            Session["Usertype"] = "admin";
                            return RedirectToAction("List", "User");
                        }
                        else if (usr.type == "employee")
                        {
                            ViewBag.employeeNum = employeeNum++.ToString();
                            Session["Usertype"] = "employee";
                            return RedirectToAction("Index", "Employee");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(" ", "Username or Password is wrong");
                    }
                }
            }
            catch(Exception)
            {
                return View();
            }
            return View("LogAdmin");
        }
       
        public ActionResult LogAdmin()
        {
            if (Session["UserID"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogUser()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult List()
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                return View(context.Users.ToList());
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
        public ActionResult Create(User u)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                if (ModelState.IsValid)
                {
                    UserDBContext context = new UserDBContext();
                    context.Users.Add(u);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    return View(u);
                }
            }else{
                return View("error");
            }
        }
        public ActionResult Edit(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                User user = context.Users.SingleOrDefault(u => u.id == id);
                return View(user);
            }else{
                  return View("error");
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Do_Edit(int id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                User user = context.Users.SingleOrDefault(u => u.id == id);
                TryUpdateModel(user, new string[] { "username", "password", "email", "address", "phone", "type" });
                if (ModelState.IsValid)
                {
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    return View(user);
                }
            }else{
                return View("error");
            }
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            if (Session["Usertype"].ToString() == "admin")
            {
                UserDBContext context = new UserDBContext();
                User user = context.Users.SingleOrDefault(u => u.id == Id);
                return View(user);
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
                User user = context.Users.SingleOrDefault(u => u.id == id);
                return View(user);
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
                User user = context.Users.SingleOrDefault(u => u.id == id);
                context.Users.Remove(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("error");
            }
        }
        public ActionResult DashBord()
        {
            return View();
        }
    }
}
