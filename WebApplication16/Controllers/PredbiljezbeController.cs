using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class PredbiljezbeController : Controller
    {
        private SeminarEntities db = new SeminarEntities();

        // GET: Predbiljezbe
        [Authorize]
        public ActionResult Index()
        {
            var predbiljezbe = db.Predbiljezbe.Include(p => p.Seminari);
            return View(predbiljezbe.ToList());
        }

        // GET: Predbiljezbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezbe predbiljezbe = db.Predbiljezbe.Find(id);
            if (predbiljezbe == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezbe);
        }

        // GET: Predbiljezbe/Create
        public ActionResult Create()
        {
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv");
            return View();
        }

        // POST: Predbiljezbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPredbiljezba,IdSeminar,Ime,Prezime,Adresa,Email,Telefon,Prihvaceno,Odbijeno")] Predbiljezbe predbiljezbe)
        {
                if (ModelState.IsValid)
            {
                db.Predbiljezbe.Add(predbiljezbe);
                db.SaveChanges();
                //return RedirectToAction("Index");     
                return RedirectToRoute(new { controller = "Zahvala", action = "Index" });
            }

                ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezbe.IdSeminar);
            return View(predbiljezbe);
        }

        // GET: Predbiljezbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezbe predbiljezbe = db.Predbiljezbe.Find(id);
            if (predbiljezbe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezbe.IdSeminar);
            return View(predbiljezbe);
        }

        // POST: Predbiljezbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPredbiljezba,IdSeminar,Ime,Prezime,Adresa,Email,Telefon,Prihvaceno,Odbijeno")] Predbiljezbe predbiljezbe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predbiljezbe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezbe.IdSeminar);
            return View(predbiljezbe);
        }

        // GET: Predbiljezbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezbe predbiljezbe = db.Predbiljezbe.Find(id);
            if (predbiljezbe == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezbe);
        }

        // POST: Predbiljezbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predbiljezbe predbiljezbe = db.Predbiljezbe.Find(id);
            db.Predbiljezbe.Remove(predbiljezbe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
