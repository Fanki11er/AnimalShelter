using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class ZdjeciesController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Zdjecies
        public ActionResult Index()
        {
            var zdjecie = db.Zdjecie.Include(z => z.Zwierze);
            return View(zdjecie.ToList());
        }

        // GET: Zdjecies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdjecie zdjecie = db.Zdjecie.Find(id);
            if (zdjecie == null)
            {
                return HttpNotFound();
            }
            return View(zdjecie);
        }

        // GET: Zdjecies/Create
        public ActionResult Create()
        {
            ViewBag.Zdj_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie");
            return View();
        }

        // POST: Zdjecies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zdj_GIDNumer,Zdj_ZwrNumer,Zdj_Tytul,Zdj_Sciezka")] Zdjecie zdjecie)
        {
            if (ModelState.IsValid)
            {
                db.Zdjecie.Add(zdjecie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Zdj_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", zdjecie.Zdj_ZwrNumer);
            return View(zdjecie);
        }

        // GET: Zdjecies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdjecie zdjecie = db.Zdjecie.Find(id);
            if (zdjecie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Zdj_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", zdjecie.Zdj_ZwrNumer);
            return View(zdjecie);
        }

        // POST: Zdjecies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zdj_GIDNumer,Zdj_ZwrNumer,Zdj_Tytul,Zdj_Sciezka")] Zdjecie zdjecie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zdjecie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Zdj_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", zdjecie.Zdj_ZwrNumer);
            return View(zdjecie);
        }

        // GET: Zdjecies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zdjecie zdjecie = db.Zdjecie.Find(id);
            if (zdjecie == null)
            {
                return HttpNotFound();
            }
            return View(zdjecie);
        }

        // POST: Zdjecies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zdjecie zdjecie = db.Zdjecie.Find(id);
            db.Zdjecie.Remove(zdjecie);
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
