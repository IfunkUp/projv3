using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projetsv3;

namespace projetsv3.Controllers
{
    public class VraagsController : Controller
    {
        private INFO_c1035462Entities db = new INFO_c1035462Entities();

        // GET: Vraags
        public ActionResult Index()
        {
            return View(db.Proj_Vragen.ToList());
        }

        // GET: Vraags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // GET: Vraags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vraags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,naam,voornaam,adres,gemeente,type,content,date")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Proj_Vragen.Add(vraag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vraag);
        }

        // GET: Vraags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: Vraags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,naam,voornaam,adres,gemeente,type,content,date")] Vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vraag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vraag);
        }

        // GET: Vraags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: Vraags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vraag vraag = db.Proj_Vragen.Find(id);
            db.Proj_Vragen.Remove(vraag);
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
