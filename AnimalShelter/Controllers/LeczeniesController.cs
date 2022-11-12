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
    public class LeczeniesController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Leczenies
        public ActionResult Index()
        {
            var leczenie = db.Leczenie.Include(l => l.KsiazeczkaZdrowiaElem).Include(l => l.KsiazeczkaZdrowiaNag);
            return View(leczenie.ToList());
        }

        // GET: Leczenies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leczenie leczenie = db.Leczenie.Find(id);
            if (leczenie == null)
            {
                return HttpNotFound();
            }
            return View(leczenie);
        }

        // GET: Leczenies/Create
        public ActionResult Create()
        {
            ViewBag.Lec_GIDLp = new SelectList(db.KsiazeczkaZdrowiaElem, "KzE_GIDLp", "KzE_OpisBadania");
            ViewBag.Lec_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa");
            return View();
        }

        // POST: Leczenies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lec_GIDNumer,Lec_GIDLp,Lec_Opis")] Leczenie leczenie)
        {
            if (ModelState.IsValid)
            {
                db.Leczenie.Add(leczenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lec_GIDLp = new SelectList(db.KsiazeczkaZdrowiaElem, "KzE_GIDLp", "KzE_OpisBadania", leczenie.Lec_GIDLp);
            ViewBag.Lec_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", leczenie.Lec_GIDNumer);
            return View(leczenie);
        }

        // GET: Leczenies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leczenie leczenie = db.Leczenie.Find(id);
            if (leczenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lec_GIDLp = new SelectList(db.KsiazeczkaZdrowiaElem, "KzE_GIDLp", "KzE_OpisBadania", leczenie.Lec_GIDLp);
            ViewBag.Lec_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", leczenie.Lec_GIDNumer);
            return View(leczenie);
        }

        // POST: Leczenies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lec_GIDNumer,Lec_GIDLp,Lec_Opis")] Leczenie leczenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leczenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lec_GIDLp = new SelectList(db.KsiazeczkaZdrowiaElem, "KzE_GIDLp", "KzE_OpisBadania", leczenie.Lec_GIDLp);
            ViewBag.Lec_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", leczenie.Lec_GIDNumer);
            return View(leczenie);
        }

        // GET: Leczenies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leczenie leczenie = db.Leczenie.Find(id);
            if (leczenie == null)
            {
                return HttpNotFound();
            }
            return View(leczenie);
        }

        // POST: Leczenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leczenie leczenie = db.Leczenie.Find(id);
            db.Leczenie.Remove(leczenie);
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
