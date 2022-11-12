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
    public class KsiazeczkaZdrowiaNagsController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: KsiazeczkaZdrowiaNags
        public ActionResult Index()
        {
            var ksiazeczkaZdrowiaNag = db.KsiazeczkaZdrowiaNag.Include(k => k.Zwierze);
            return View(ksiazeczkaZdrowiaNag.ToList());
        }

        // GET: KsiazeczkaZdrowiaNags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag = db.KsiazeczkaZdrowiaNag.Find(id);
            if (ksiazeczkaZdrowiaNag == null)
            {
                return HttpNotFound();
            }
            return View(ksiazeczkaZdrowiaNag);
        }

        // GET: KsiazeczkaZdrowiaNags/Create
        public ActionResult Create()
        {
            ViewBag.KzN_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie");
            return View();
        }

        // POST: KsiazeczkaZdrowiaNags/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KzN_GIDNumer,KzN_ZwrNumer,KzN_Nazwa,KzN_DataUtworzenia")] KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag)
        {
            if (ModelState.IsValid)
            {
                db.KsiazeczkaZdrowiaNag.Add(ksiazeczkaZdrowiaNag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KzN_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", ksiazeczkaZdrowiaNag.KzN_ZwrNumer);
            return View(ksiazeczkaZdrowiaNag);
        }

        // GET: KsiazeczkaZdrowiaNags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag = db.KsiazeczkaZdrowiaNag.Find(id);
            if (ksiazeczkaZdrowiaNag == null)
            {
                return HttpNotFound();
            }
            ViewBag.KzN_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", ksiazeczkaZdrowiaNag.KzN_ZwrNumer);
            return View(ksiazeczkaZdrowiaNag);
        }

        // POST: KsiazeczkaZdrowiaNags/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KzN_GIDNumer,KzN_ZwrNumer,KzN_Nazwa,KzN_DataUtworzenia")] KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazeczkaZdrowiaNag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KzN_ZwrNumer = new SelectList(db.Zwierze, "Zwr_GIDNumer", "Zwr_Imie", ksiazeczkaZdrowiaNag.KzN_ZwrNumer);
            return View(ksiazeczkaZdrowiaNag);
        }

        // GET: KsiazeczkaZdrowiaNags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag = db.KsiazeczkaZdrowiaNag.Find(id);
            if (ksiazeczkaZdrowiaNag == null)
            {
                return HttpNotFound();
            }
            return View(ksiazeczkaZdrowiaNag);
        }

        // POST: KsiazeczkaZdrowiaNags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KsiazeczkaZdrowiaNag ksiazeczkaZdrowiaNag = db.KsiazeczkaZdrowiaNag.Find(id);
            db.KsiazeczkaZdrowiaNag.Remove(ksiazeczkaZdrowiaNag);
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
