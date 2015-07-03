using System;
using System.Linq;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;

namespace BankAccountsManagementSystem.Controllers
{
    public class MatriculFiscalController : Controller
    {
        public ActionResult IsMatriculFiscalAvailable(String m)
        {
            try
            {
                using (var db = new BankDbContext())
                {
                    try
                    {
                        var mF = db.PersonnesMorales.Single(p => p.MatriculFiscal == m);
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