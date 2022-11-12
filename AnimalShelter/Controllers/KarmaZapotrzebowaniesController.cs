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
    public class KarmaZapotrzebowaniesController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: KarmaZapotrzebowanies
        public ActionResult Index()
        {
            var karmaZapotrzebowanie = db.KarmaZapotrzebowanie.Include(k => k.Gatunek);
            return View(karmaZapotrzebowanie.ToList());
        }

        // GET: KarmaZapotrzebowanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarmaZapotrzebowanie karmaZapotrzebowanie = db.KarmaZapotrzebowanie.Find(id);
            if (karmaZapotrzebowanie == null)
            {
                return HttpNotFound();
            }
            return View(karmaZapotrzebowanie);
        }

        // GET: KarmaZapotrzebowanies/Create
        public ActionResult Create()
        {
            ViewBag.Zap_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa");
            return View();
        }

        // POST: KarmaZapotrzebowanies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zap_GIDNumer,Zap_GatNumer,Zap_NazwaKarmy,Zap_IloscAktualna,Zap_IloscPotrzebna,Zap_Jm")] KarmaZapotrzebowanie karmaZapotrzebowanie)
        {
            if (ModelState.IsValid)
            {
                db.KarmaZapotrzebowanie.Add(karmaZapotrzebowanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Zap_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", karmaZapotrzebowanie.Zap_GatNumer);
            return View(karmaZapotrzebowanie);
        }

        // GET: KarmaZapotrzebowanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarmaZapotrzebowanie karmaZapotrzebowanie = db.KarmaZapotrzebowanie.Find(id);
            if (karmaZapotrzebowanie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Zap_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", karmaZapotrzebowanie.Zap_GatNumer);
            return View(karmaZapotrzebowanie);
        }

        // POST: KarmaZapotrzebowanies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zap_GIDNumer,Zap_GatNumer,Zap_NazwaKarmy,Zap_IloscAktualna,Zap_IloscPotrzebna,Zap_Jm")] KarmaZapotrzebowanie karmaZapotrzebowanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karmaZapotrzebowanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Zap_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", karmaZapotrzebowanie.Zap_GatNumer);
            return View(karmaZapotrzebowanie);
        }

        // GET: KarmaZapotrzebowanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarmaZapotrzebowanie karmaZapotrzebowanie = db.KarmaZapotrzebowanie.Find(id);
            if (karmaZapotrzebowanie == null)
            {
                return HttpNotFound();
            }
            return View(karmaZapotrzebowanie);
        }

        // POST: KarmaZapotrzebowanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KarmaZapotrzebowanie karmaZapotrzebowanie = db.KarmaZapotrzebowanie.Find(id);
            db.KarmaZapotrzebowanie.Remove(karmaZapotrzebowanie);
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
