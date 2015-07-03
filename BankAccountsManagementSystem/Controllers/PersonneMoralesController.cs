using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;
using BankAccountsManagementSystem.Models;

namespace BankAccountsManagementSystem.Controllers
{
    public class PersonneMoralesController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: PersonneMorales
        public ActionResult Index(string searchString)
        {
            try
            {
                var pm = from p in _db.PersonnesMorales
                    select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    pm = pm.Where(c => c.Nom.Contains(searchString)
                                       || c.MatriculFiscal.Contains(searchString));
                }
                return View(pm.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonneMorales/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personneMorale = _db.PersonnesMorales.Find(id);
                if (personneMorale == null)
                {
                    return HttpNotFound();
                }
                return View(personneMorale);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonneMorales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonneMorales/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Adresse,MatriculFiscal")] PersonneMorale personneMorale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Clients.Add(personneMorale);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(personneMorale);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonneMorales/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personneMorale = _db.PersonnesMorales.Find(id);
                if (personneMorale == null)
                {
                    return HttpNotFound();
                }
                return View(personneMorale);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: PersonneMorales/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Adresse,MatriculFiscal")] PersonneMorale personneMorale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(personneMorale).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(personneMorale);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonneMorales/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personneMorale = _db.PersonnesMorales.Find(id);
                if (personneMorale == null)
                {
                    return HttpNotFound();
                }
                return View(personneMorale);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: PersonneMorales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var personneMorale = _db.PersonnesMorales.Find(id);
                _db.Clients.Remove(personneMorale);
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