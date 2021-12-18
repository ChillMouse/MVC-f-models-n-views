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
    public class FavoritesController : Controller
    {
        private Entities db = new Entities();

        // GET: Favorites
        public ActionResult Index()
        {
            return View(db.Favorites.ToList());
        }

        // GET: Favorites/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_user,ID_product")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                db.Favorites.Add(favorites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favorites);
        }

        // GET: Favorites/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // POST: Favorites/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_user,ID_product")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favorites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favorites);
        }

        // GET: Favorites/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Favorites favorites = db.Favorites.Find(id);
            db.Favorites.Remove(favorites);
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
