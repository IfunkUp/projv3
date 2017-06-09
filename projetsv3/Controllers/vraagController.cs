using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projetsv3;
using projetsv3.TaalResources;

namespace projetsv3.Controllers
{
    public class vraagController : Controller
    {
        private INFO_c1035462Entities db = new INFO_c1035462Entities();

        // GET: vraag
        public ActionResult Index()
        {
            return View(db.Proj_Vragen.ToList());
        }

        // GET: vraag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // GET: vraag/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = Teksten.Question, Value = "0" });
            items.Add(new SelectListItem { Text = Teksten.Remark, Value = "1" });
            ViewBag.type = items;
            return View();
        }

        // POST: vraag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,naam,voornaam,adres,gemeente,type,content,date")] vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Proj_Vragen.Add(vraag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vraag);
        }

        // GET: vraag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: vraag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,naam,voornaam,adres,gemeente,type,content,date")] vraag vraag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vraag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vraag);
        }

        // GET: vraag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vraag vraag = db.Proj_Vragen.Find(id);
            if (vraag == null)
            {
                return HttpNotFound();
            }
            return View(vraag);
        }

        // POST: vraag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vraag vraag = db.Proj_Vragen.Find(id);
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
