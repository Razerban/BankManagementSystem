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
    public class OperationsController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: Operations
        public ActionResult Index(string searchString)
        {
            try
            {
                var operations = _db.Operations.Include(o => o.Compte);
                if (!String.IsNullOrEmpty(searchString))
                {
                    operations = operations.Where(c => c.Type.ToString().Contains(searchString)
                                                       || c.CompteId.ToString().Contains(searchString));
                }
                return View(operations.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var operation = _db.Operations.Find(id);
                if (operation == null)
                {
                    return HttpNotFound();
                }
                return View(operation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CompteId = new SelectList(_db.Comptes, "CompteId", "CompteId");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Operations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperationId,Type,Montant,Date,CompteId")] Operation operation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var compte = _db.Comptes.Find(operation.CompteId);
                    if (operation.Type == TypeOperation.Retrait)
                    {
                        compte.SoldeBase = compte.SoldeBase - operation.Montant;
                    }
                    else compte.SoldeBase = compte.SoldeBase + operation.Montant;
                    _db.Operations.Add(operation);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CompteId = new SelectList(_db.Comptes, "CompteId", "CompteId", operation.CompteId);
                return View(operation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var operation = _db.Operations.Find(id);
                if (operation == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CompteId = new SelectList(_db.Comptes, "CompteId", "CompteId", operation.CompteId);
                return View(operation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Operations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperationId,Type,Montant,Date,CompteId")] Operation operation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(operation).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CompteId = new SelectList(_db.Comptes, "CompteId", "CompteId", operation.CompteId);
                return View(operation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var operation = _db.Operations.Find(id);
                if (operation == null)
                {
                    return HttpNotFound();
                }
                return View(operation);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var operation = _db.Operations.Find(id);
                _db.Operations.Remove(operation);
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