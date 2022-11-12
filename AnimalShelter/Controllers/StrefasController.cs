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
    public class StrefasController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Strefas
        public ActionResult Index()
        {
            var strefa = db.Strefa.Include(s => s.Gatunek);
            return View(strefa.ToList());
        }

        // GET: Strefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strefa strefa = db.Strefa.Find(id);
            if (strefa == null)
            {
                return HttpNotFound();
            }
            return View(strefa);
        }

        // GET: Strefas/Create
        public ActionResult Create()
        {
            ViewBag.Str_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa");
            return View();
        }

        // POST: Strefas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Str_GIDNumer,Str_GatNumer,Str_Kod,Str_Nazwa")] Strefa strefa)
        {
            if (ModelState.IsValid)
            {
                db.Strefa.Add(strefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Str_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", strefa.Str_GatNumer);
            return View(strefa);
        }

        // GET: Strefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strefa strefa = db.Strefa.Find(id);
            if (strefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Str_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", strefa.Str_GatNumer);
            return View(strefa);
        }

        // POST: Strefas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Str_GIDNumer,Str_GatNumer,Str_Kod,Str_Nazwa")] Strefa strefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Str_GatNumer = new SelectList(db.Gatunek, "Gat_GIDNumer", "Gat_Nazwa", strefa.Str_GatNumer);
            return View(strefa);
        }

        // GET: Strefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strefa strefa = db.Strefa.Find(id);
            if (strefa == null)
            {
                return HttpNotFound();
            }
            return View(strefa);
        }

        // POST: Strefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strefa strefa = db.Strefa.Find(id);
            db.Strefa.Remove(strefa);
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
