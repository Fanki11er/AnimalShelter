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
    public class GatuneksController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Gatuneks
        public ActionResult Index()
        {
            return View(db.Gatunek.ToList());
        }

        // GET: Gatuneks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunek gatunek = db.Gatunek.Find(id);
            if (gatunek == null)
            {
                return HttpNotFound();
            }
            return View(gatunek);
        }

        // GET: Gatuneks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gatuneks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gat_GIDNumer,Gat_Nazwa")] Gatunek gatunek)
        {
            if (ModelState.IsValid)
            {
                db.Gatunek.Add(gatunek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gatunek);
        }

        // GET: Gatuneks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunek gatunek = db.Gatunek.Find(id);
            if (gatunek == null)
            {
                return HttpNotFound();
            }
            return View(gatunek);
        }

        // POST: Gatuneks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gat_GIDNumer,Gat_Nazwa")] Gatunek gatunek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gatunek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gatunek);
        }

        // GET: Gatuneks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunek gatunek = db.Gatunek.Find(id);
            if (gatunek == null)
            {
                return HttpNotFound();
            }
            return View(gatunek);
        }

        // POST: Gatuneks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gatunek gatunek = db.Gatunek.Find(id);
            db.Gatunek.Remove(gatunek);
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
