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
    public class KsiazeczkaZdrowiaElemsController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: KsiazeczkaZdrowiaElems
        public ActionResult Index()
        {
            var ksiazeczkaZdrowiaElem = db.KsiazeczkaZdrowiaElem.Include(k => k.KsiazeczkaZdrowiaNag).Include(k => k.Leczenie);
            return View(ksiazeczkaZdrowiaElem.ToList());
        }

        // GET: KsiazeczkaZdrowiaElems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem = db.KsiazeczkaZdrowiaElem.Find(id);
            if (ksiazeczkaZdrowiaElem == null)
            {
                return HttpNotFound();
            }
            return View(ksiazeczkaZdrowiaElem);
        }

        // GET: KsiazeczkaZdrowiaElems/Create
        public ActionResult Create()
        {
            ViewBag.KzE_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa");
            ViewBag.KzE_GIDLp = new SelectList(db.Leczenie, "Lec_GIDLp", "Lec_Opis");
            return View();
        }

        // POST: KsiazeczkaZdrowiaElems/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KzE_GIDNumer,KzE_GIDLp,KzE_OpisBadania,KzE_WynikBadania,KzE_DataBadania")] KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem)
        {
            if (ModelState.IsValid)
            {
                db.KsiazeczkaZdrowiaElem.Add(ksiazeczkaZdrowiaElem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KzE_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", ksiazeczkaZdrowiaElem.KzE_GIDNumer);
            ViewBag.KzE_GIDLp = new SelectList(db.Leczenie, "Lec_GIDLp", "Lec_Opis", ksiazeczkaZdrowiaElem.KzE_GIDLp);
            return View(ksiazeczkaZdrowiaElem);
        }

        // GET: KsiazeczkaZdrowiaElems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem = db.KsiazeczkaZdrowiaElem.Find(id);
            if (ksiazeczkaZdrowiaElem == null)
            {
                return HttpNotFound();
            }
            ViewBag.KzE_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", ksiazeczkaZdrowiaElem.KzE_GIDNumer);
            ViewBag.KzE_GIDLp = new SelectList(db.Leczenie, "Lec_GIDLp", "Lec_Opis", ksiazeczkaZdrowiaElem.KzE_GIDLp);
            return View(ksiazeczkaZdrowiaElem);
        }

        // POST: KsiazeczkaZdrowiaElems/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KzE_GIDNumer,KzE_GIDLp,KzE_OpisBadania,KzE_WynikBadania,KzE_DataBadania")] KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazeczkaZdrowiaElem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KzE_GIDNumer = new SelectList(db.KsiazeczkaZdrowiaNag, "KzN_GIDNumer", "KzN_Nazwa", ksiazeczkaZdrowiaElem.KzE_GIDNumer);
            ViewBag.KzE_GIDLp = new SelectList(db.Leczenie, "Lec_GIDLp", "Lec_Opis", ksiazeczkaZdrowiaElem.KzE_GIDLp);
            return View(ksiazeczkaZdrowiaElem);
        }

        // GET: KsiazeczkaZdrowiaElems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem = db.KsiazeczkaZdrowiaElem.Find(id);
            if (ksiazeczkaZdrowiaElem == null)
            {
                return HttpNotFound();
            }
            return View(ksiazeczkaZdrowiaElem);
        }

        // POST: KsiazeczkaZdrowiaElems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KsiazeczkaZdrowiaElem ksiazeczkaZdrowiaElem = db.KsiazeczkaZdrowiaElem.Find(id);
            db.KsiazeczkaZdrowiaElem.Remove(ksiazeczkaZdrowiaElem);
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
