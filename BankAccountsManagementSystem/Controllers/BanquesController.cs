using System;
using System.Linq;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;

namespace BankAccountsManagementSystem.Controllers
{
    public class BanquesController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: Banques
        public ActionResult Index()
        {
            try
            {
                var banque = _db.Banque.Find("ENIT Bank");
                var pm = from c in _db.PersonnesMorales
                    select c;
                var pp = from c in _db.PersonnesPhysiques
                    select c;
                var comptes = from c in _db.Comptes
                        select c;
                var credits = from c in _db.Credits
                        select c;
                if (banque == null)
                {
                    return HttpNotFound();
                }
                banque.NbrComptes = Enumerable.Count(comptes);
                banque.NbrClients = Enumerable.Count(pm) + Enumerable.Count(pp);
                banque.NbrCredits = Enumerable.Count(credits);
                banque.ArgentDepose = comptes.Sum(i => i.SoldeBase);
                banque.SommeCredits = credits.Sum(i => i.MontantCredit);
                _db.SaveChanges();
                return View(banque);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}