using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OyuncuTabani.Models;

namespace OyuncuTabani.Controllers
{
    public class FutbolcuController : Controller
    {
        private OyuncuTabaniEntities db = new OyuncuTabaniEntities();

        public ActionResult OyuncuAra(string siralama,string arama)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(siralama) ? "soyadi_azalan" : "";
            ViewBag.DateSortParm = siralama == "tarih_artan" ? "tarih_azalan" : "tarih_artan";

            var futbolcu = from s in db.Futbolcu
                           select s;
            //arama
            if (!String.IsNullOrEmpty(arama))
            {
                futbolcu = futbolcu.Where(s => s.Fsoyadi.ToUpper().Contains(arama.ToUpper())
                   ||
                  s.Fadi.ToUpper().Contains(arama.ToUpper()));
              
            }


            //siralama
            switch (siralama)
            {
                case "soyadi_azalan":
                    futbolcu = futbolcu.OrderByDescending(s => s.Fsoyadi);
                    break;
                case "tarih_artan":
                    futbolcu = futbolcu.OrderBy(s => s.Dtarih);
                    break;
                case "tarih_azalan":
                    futbolcu = futbolcu.OrderByDescending(s => s.Dtarih);
                    break;
                default:
                    futbolcu = futbolcu.OrderBy(s => s.Fsoyadi);
                    break;
            }
            
           return View(futbolcu.ToList());

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbolcu futbolcu = db.Futbolcu.Find(id);
            if (futbolcu == null)
            {
                return HttpNotFound();
            }
            return View(futbolcu);
        }

        // GET: Futbolcu/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FutbolcuID,Fadi,Fsoyadi,Dtarih,Fmevki")] Futbolcu futbolcu)
        {
            if (ModelState.IsValid)
            {
                db.Futbolcu.Add(futbolcu);
                db.SaveChanges();
                return RedirectToAction("OyuncuAra");
            }

            return View(futbolcu);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbolcu futbolcu = db.Futbolcu.Find(id);
            if (futbolcu == null)
            {
                return HttpNotFound();
            }
            return View(futbolcu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FutbolcuID,Fadi,Fsoyadi,Dtarih,Fmevki")] Futbolcu futbolcu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(futbolcu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OyuncuAra");
            }
            return View(futbolcu);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Futbolcu futbolcu = db.Futbolcu.Find(id);
            if (futbolcu == null)
            {
                return HttpNotFound();
            }
            return View(futbolcu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Futbolcu futbolcu = db.Futbolcu.Find(id);
            db.Futbolcu.Remove(futbolcu);
            db.SaveChanges();
            return RedirectToAction("OyuncuAra");
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
