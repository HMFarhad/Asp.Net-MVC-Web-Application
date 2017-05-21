using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FKM_Diagnostic_Center.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public JsonResult Index(string term)
        {
            try
            {
                UserDBContext context = new UserDBContext();
                List<string> pNames = new List<string>();
                List<Patient> clist = context.Patients.Where(c => c.PName.Contains(term)).ToList();
                foreach (Patient c in clist)
                {
                    pNames.Add(c.PName);
                }

                return Json(pNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        }
    }
