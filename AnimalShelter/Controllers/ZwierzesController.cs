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
    public class ZwierzesController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Zwierzes
        public ActionResult Index()
        {
            var zwierze = db.Zwierze.Include(z => z.Gatunek).Include(z => z.Kojec).Include(z => z.Zdjecie1);
            return View(zwierze.ToList());
        }

        // GET: Zwierzes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwierze zwierze = db.Zwierze.Find(id);
            if (zwierze == null)
            {
                return HttpNotFound();
            }
            return View(zwierze);
        }

        // GET: Zwierzes/Create
        public ActionResult Create()
        {
            ViewBag.Zwr_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa");
            ViewBag.Zwr_KojNumer = new SelectList(db.Kojec, "Koj_GIDNumer", "Koj_Kod");
            ViewBag.Zwr_Avatar = new SelectList(db.Zdjecie, "Zdj_GIDNumer", "Zdj_Tytul");
            return View();
        }

        // POST: Zwierzes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zwr_GIDNumer,Zwr_GatNumer,Zwr_Imie,Zwr_DataPrzyjecia,Zwr_Plec,Zwr_Avatar,Zwr_Opis,Zwr_Rasa,Zwr_KojNumer")] Zwierze zwierze)
        {
            if (ModelState.IsValid)
            {
                db.Zwierze.Add(zwierze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Zwr_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", zwierze.Zwr_GatNumer);
            ViewBag.Zwr_KojNumer = new SelectList(db.Kojec, "Koj_GIDNumer", "Koj_Kod", zwierze.Zwr_KojNumer);
            ViewBag.Zwr_Avatar = new SelectList(db.Zdjecie, "Zdj_GIDNumer", "Zdj_Tytul", zwierze.Zwr_Avatar);
            return View(zwierze);
        }

        // GET: Zwierzes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwierze zwierze = db.Zwierze.Find(id);
            if (zwierze == null)
            {
                return HttpNotFound();
            }
            ViewBag.Zwr_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", zwierze.Zwr_GatNumer);
            ViewBag.Zwr_KojNumer = new SelectList(db.Kojec, "Koj_GIDNumer", "Koj_Kod", zwierze.Zwr_KojNumer);
            ViewBag.Zwr_Avatar = new SelectList(db.Zdjecie, "Zdj_GIDNumer", "Zdj_Tytul", zwierze.Zwr_Avatar);
            return View(zwierze);
        }

        // POST: Zwierzes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zwr_GIDNumer,Zwr_GatNumer,Zwr_Imie,Zwr_DataPrzyjecia,Zwr_Plec,Zwr_Avatar,Zwr_Opis,Zwr_Rasa,Zwr_KojNumer")] Zwierze zwierze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zwierze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Zwr_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", zwierze.Zwr_GatNumer);
            ViewBag.Zwr_KojNumer = new SelectList(db.Kojec, "Koj_GIDNumer", "Koj_Kod", zwierze.Zwr_KojNumer);
            ViewBag.Zwr_Avatar = new SelectList(db.Zdjecie, "Zdj_GIDNumer", "Zdj_Tytul", zwierze.Zwr_Avatar);
            return View(zwierze);
        }

        // GET: Zwierzes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zwierze zwierze = db.Zwierze.Find(id);
            if (zwierze == null)
            {
                return HttpNotFound();
            }
            return View(zwierze);
        }

        // POST: Zwierzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zwierze zwierze = db.Zwierze.Find(id);
            db.Zwierze.Remove(zwierze);
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
