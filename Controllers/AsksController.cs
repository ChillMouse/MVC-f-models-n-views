using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_f_Denis.Models;

namespace MVC_f_Denis.Controllers
{
    public class AsksController : Controller
    {
        private Entities db = new Entities();

        // GET: Asks
        public ActionResult Index()
        {
            return View(db.Asks.ToList());
        }

        // GET: Asks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asks asks = db.Asks.Find(id);
            if (asks == null)
            {
                return HttpNotFound();
            }
            return View(asks);
        }

        // GET: Asks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_user,ID_product,Ask")] Asks asks)
        {
            if (ModelState.IsValid)
            {
                db.Asks.Add(asks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asks);
        }

        // GET: Asks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asks asks = db.Asks.Find(id);
            if (asks == null)
            {
                return HttpNotFound();
            }
            return View(asks);
        }

        // POST: Asks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_user,ID_product,Ask")] Asks asks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asks);
        }

        // GET: Asks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asks asks = db.Asks.Find(id);
            if (asks == null)
            {
                return HttpNotFound();
            }
            return View(asks);
        }

        // POST: Asks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Asks asks = db.Asks.Find(id);
            db.Asks.Remove(asks);
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
