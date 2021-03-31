using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Italika.Models;

namespace Italika.Controllers
{
    public class BR_ITALIKASController : Controller
    {
        private BRANCHBITEntities db = new BRANCHBITEntities();

        // GET: Italika
        public ActionResult Index()
        {
            return View(db.BR_ITALIKAS.ToList());
        }

        // GET: Italika/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BR_ITALIKAS bR_ITALIKAS = db.BR_ITALIKAS.Find(id);
            if (bR_ITALIKAS == null)
            {
                return HttpNotFound();
            }
            return View(bR_ITALIKAS);
        }

        // GET: Italika/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Italika/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ITALIKA,SKU,FERT,MODELO,TIPO,NUM_SERIE,FECHA")] BR_ITALIKAS bR_ITALIKAS)
        {
            if (ModelState.IsValid)
            {
                db.BR_ITALIKAS.Add(bR_ITALIKAS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bR_ITALIKAS);
        }

        // GET: Italika/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BR_ITALIKAS bR_ITALIKAS = db.BR_ITALIKAS.Find(id);
            if (bR_ITALIKAS == null)
            {
                return HttpNotFound();
            }
            return View(bR_ITALIKAS);
        }

        // POST: Italika/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ITALIKA,SKU,FERT,MODELO,TIPO,NUM_SERIE,FECHA")] BR_ITALIKAS bR_ITALIKAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bR_ITALIKAS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bR_ITALIKAS);
        }

        // GET: Italika/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BR_ITALIKAS bR_ITALIKAS = db.BR_ITALIKAS.Find(id);
            if (bR_ITALIKAS == null)
            {
                return HttpNotFound();
            }
            return View(bR_ITALIKAS);
        }

        // POST: Italika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BR_ITALIKAS bR_ITALIKAS = await db.BR_ITALIKAS.FindAsync(id);
            db.BR_ITALIKAS.Remove(bR_ITALIKAS);
            await db.SaveChangesAsync();
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
