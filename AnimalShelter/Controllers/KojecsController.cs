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
    public class KojecsController : Controller
    {
        private AnimalShelterEntities db = new AnimalShelterEntities();

        // GET: Kojecs
        public ActionResult Index()
        {
            var kojec = db.Kojec.Include(k => k.Strefa);
            return View(kojec.ToList());
        }

        // GET: Kojecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kojec kojec = db.Kojec.Find(id);
            if (kojec == null)
            {
                return HttpNotFound();
            }
            return View(kojec);
        }

        // GET: Kojecs/Create
        public ActionResult Create()
        {
            ViewBag.Koj_StrNumer = new SelectList(db.Strefa, "Str_GIDNumer", "Str_Kod");
            return View();
        }

        // POST: Kojecs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Koj_GIDNumer,Koj_StrNumer,Koj_Kod,Koj_Nazwa")] Kojec kojec)
        {
            if (ModelState.IsValid)
            {
                db.Kojec.Add(kojec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Koj_StrNumer = new SelectList(db.Strefa, "Str_GIDNumer", "Str_Kod", kojec.Koj_StrNumer);
            return View(kojec);
        }

        // GET: Kojecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kojec kojec = db.Kojec.Find(id);
            if (kojec == null)
            {
                return HttpNotFound();
            }
            ViewBag.Koj_StrNumer = new SelectList(db.Strefa, "Str_GIDNumer", "Str_Kod", kojec.Koj_StrNumer);
            return View(kojec);
        }

        // POST: Kojecs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Koj_GIDNumer,Koj_StrNumer,Koj_Kod,Koj_Nazwa")] Kojec kojec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kojec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Koj_StrNumer = new SelectList(db.Strefa, "Str_GIDNumer", "Str_Kod", kojec.Koj_StrNumer);
            return View(kojec);
        }

        // GET: Kojecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kojec kojec = db.Kojec.Find(id);
            if (kojec == null)
            {
                return HttpNotFound();
            }
            return View(kojec);
        }

        // POST: Kojecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kojec kojec = db.Kojec.Find(id);
            db.Kojec.Remove(kojec);
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
