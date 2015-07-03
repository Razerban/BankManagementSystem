using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;
using BankAccountsManagementSystem.Models;

namespace BankAccountsManagementSystem.Controllers
{
    public class ComptesController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: Comptes
        public ActionResult Index(string searchString)
        {
            try
            {
                var comptes = _db.Comptes.Include(c => c.Client);
                if (!String.IsNullOrEmpty(searchString))
                {
                    comptes = comptes.Where(c => c.Client.Id.ToString().Contains(searchString)
                                                 || c.CompteId.ToString().Contains(searchString)
                                                 || c.Type.ToString().Contains(searchString));
                }
                return View(comptes.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Comptes/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var compte = _db.Comptes.Find(id);
                if (compte == null)
                {
                    return HttpNotFound();
                }
                return View(compte);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Comptes/Create
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

        // POST: Comptes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompteId,ClientId,Type,SoldeBase,DateOuverture")] Compte compte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Comptes.Add(compte);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", compte.ClientId);
                return View(compte);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Comptes/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var compte = _db.Comptes.Find(id);
                if (compte == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", compte.ClientId);
                return View(compte);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Comptes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompteId,ClientId,Type,SoldeBase,DateOuverture")] Compte compte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(compte).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClientId = new SelectList(_db.Clients, "Id", "Nom", compte.ClientId);
                return View(compte);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Comptes/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var compte = _db.Comptes.Find(id);
                if (compte == null)
                {
                    return HttpNotFound();
                }
                return View(compte);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Comptes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var compte = _db.Comptes.Find(id);
                _db.Comptes.Remove(compte);
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