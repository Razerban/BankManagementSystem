using System;
using System.Linq;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;

namespace BankAccountsManagementSystem.Controllers
{
    public class CinController : Controller
    {
        public ActionResult IsCinAvailable(String cin)
        {
            try
            {
                using (var db = new BankDbContext())
                {
                    try
                    {
                        var cCin = db.PersonnesPhysiques.Single(p => p.Cin == cin);
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}