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
    public class SeminariController : Controller
    {
        private SeminarEntities db = new SeminarEntities();

        // GET: Seminari
        public ActionResult Index()
        {
            return View(db.Seminari.ToList());
        }

        // GET: Seminari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminari seminari = db.Seminari.Find(id);
            if (seminari == null)
            {
                return HttpNotFound();
            }
            return View(seminari);
        }

        // GET: Seminari/Create       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seminari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeminar,Naziv,Opis,Datum,Popunjen")] Seminari seminari)
        {
            if (ModelState.IsValid)
            {               
                db.Seminari.Add(seminari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seminari);
        }

        // GET: Seminari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminari seminari = db.Seminari.Find(id);
            if (seminari == null)
            {
                return HttpNotFound();
            }
            return View(seminari);
        }

        // POST: Seminari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeminar,Naziv,Opis,Datum,Popunjen")] Seminari seminari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminari);
        }

        // GET: Seminari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminari seminari = db.Seminari.Find(id);
            if (seminari == null)
            {
                return HttpNotFound();
            }
            return View(seminari);
        }

        // POST: Seminari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminari seminari = db.Seminari.Find(id);
            db.Seminari.Remove(seminari);
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
