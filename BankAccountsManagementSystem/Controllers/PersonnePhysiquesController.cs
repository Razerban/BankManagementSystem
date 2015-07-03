using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BankAccountsManagementSystem.DataAccessLayer;
using BankAccountsManagementSystem.Models;

namespace BankAccountsManagementSystem.Controllers
{
    public class PersonnePhysiquesController : Controller
    {
        private readonly BankDbContext _db = new BankDbContext();
        // GET: PersonnePhysiques
        public ActionResult Index(string searchString)
        {
            try
            {
                var pp = from p in _db.PersonnesPhysiques
                    select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    pp = pp.Where(c => c.Nom.Contains(searchString)
                                       || c.Prénom.Contains(searchString) || c.Cin.ToString().Contains(searchString));
                }
                return View(pp.ToList());
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonnePhysiques/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personnePhysique = _db.PersonnesPhysiques.Find(id);
                if (personnePhysique == null)
                {
                    return HttpNotFound();
                }
                return View(personnePhysique);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonnePhysiques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonnePhysiques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Nom,Adresse,Prénom,Cin,Profession,Telephone,Salaire")] PersonnePhysique personnePhysique)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Clients.Add(personnePhysique);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(personnePhysique);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonnePhysiques/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personnePhysique = _db.PersonnesPhysiques.Find(id);
                if (personnePhysique == null)
                {
                    return HttpNotFound();
                }
                return View(personnePhysique);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: PersonnePhysiques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Nom,Adresse,Prénom,Cin,Profession,Telephone,Salaire")] PersonnePhysique personnePhysique)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(personnePhysique).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(personnePhysique);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PersonnePhysiques/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var personnePhysique = _db.PersonnesPhysiques.Find(id);
                if (personnePhysique == null)
                {
                    return HttpNotFound();
                }
                return View(personnePhysique);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // POST: PersonnePhysiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var personnePhysique = _db.PersonnesPhysiques.Find(id);
                _db.Clients.Remove(personnePhysique);
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