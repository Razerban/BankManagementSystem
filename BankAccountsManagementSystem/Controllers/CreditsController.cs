using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;
using BankAccountsManagementSystem.Models;

namespace BankAccountsManagementSystem.Controllers
{
    public class CreditsController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: Credits
        public ActionResult Index(string searchString)
        {
            try
            {
                var credits = _db.Credits.Include(c => c.Client);
                if (!String.IsNullOrEmpty(searchString))
                {
                    credits = credits.Where(c => c.Client.Nom.Contains(searchString));
                }
                return View(credits.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Credits/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var credit = _db.Credits.Find(id);
                if (credit == null)
                {
                    return HttpNotFound();
                }
                return View(credit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Credits/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Credits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "CreditId,MontantCredit,Planification,PayementMonsuel,ClientId")] Credit credit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Credits.Add(credit);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", credit.ClientId);
                return View(credit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Credits/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var credit = _db.Credits.Find(id);
                if (credit == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", credit.ClientId);
                return View(credit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Credits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "CreditId,MontantCredit,Planification,PayementMonsuel,ClientId")] Credit credit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(credit).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", credit.ClientId);
                return View(credit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Credits/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var credit = _db.Credits.Find(id);
                if (credit == null)
                {
                    return HttpNotFound();
                }
                return View(credit);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var credit = _db.Credits.Find(id);
                _db.Credits.Remove(credit);
                _db.SaveChanges();
                return RedirectToAction("Index");
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