using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hainadeblanaSite.Models;

namespace hainadeblanaSite.Controllers
{
    public class ProdusImaginesController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: ProdusImagines
        public async Task<ActionResult> Index()
        {
            var produsImagine = db.ProdusImagine.Include(p => p.Produs);
            return View(await produsImagine.ToListAsync());
        }

        // GET: ProdusImagines/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusImagine produsImagine = await db.ProdusImagine.FindAsync(id);
            if (produsImagine == null)
            {
                return HttpNotFound();
            }
            return View(produsImagine);
        }

        // GET: ProdusImagines/Create
        public ActionResult Create()
        {
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus");
            return View();
        }

        // POST: ProdusImagines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImagineID,ProdusID,CaleImagine")] ProdusImagine produsImagine)
        {
            if (ModelState.IsValid)
            {
                db.ProdusImagine.Add(produsImagine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsImagine.ProdusID);
            return View(produsImagine);
        }

        // GET: ProdusImagines/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusImagine produsImagine = await db.ProdusImagine.FindAsync(id);
            if (produsImagine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsImagine.ProdusID);
            return View(produsImagine);
        }

        // POST: ProdusImagines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ImagineID,ProdusID,CaleImagine")] ProdusImagine produsImagine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produsImagine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsImagine.ProdusID);
            return View(produsImagine);
        }

        // GET: ProdusImagines/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusImagine produsImagine = await db.ProdusImagine.FindAsync(id);
            if (produsImagine == null)
            {
                return HttpNotFound();
            }
            return View(produsImagine);
        }

        // POST: ProdusImagines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProdusImagine produsImagine = await db.ProdusImagine.FindAsync(id);
            db.ProdusImagine.Remove(produsImagine);
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
