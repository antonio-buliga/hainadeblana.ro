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
    public class ProdusComandasController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: ProdusComandas
        public async Task<ActionResult> Index()
        {
            var produsComanda = db.ProdusComanda.Include(p => p.Comanda).Include(p => p.Produs);
            return View(await produsComanda.ToListAsync());
        }

        // GET: ProdusComandas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusComanda produsComanda = await db.ProdusComanda.FindAsync(id);
            if (produsComanda == null)
            {
                return HttpNotFound();
            }
            return View(produsComanda);
        }

        // GET: ProdusComandas/Create
        public ActionResult Create()
        {
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID");
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus");
            return View();
        }

        // POST: ProdusComandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProdusComandaID,ComandaID,ProdusID")] ProdusComanda produsComanda)
        {
            if (ModelState.IsValid)
            {
                db.ProdusComanda.Add(produsComanda);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", produsComanda.ComandaID);
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsComanda.ProdusID);
            return View(produsComanda);
        }

        // GET: ProdusComandas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusComanda produsComanda = await db.ProdusComanda.FindAsync(id);
            if (produsComanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", produsComanda.ComandaID);
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsComanda.ProdusID);
            return View(produsComanda);
        }

        // POST: ProdusComandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdusComandaID,ComandaID,ProdusID")] ProdusComanda produsComanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produsComanda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", produsComanda.ComandaID);
            ViewBag.ProdusID = new SelectList(db.Produs, "ProdusID", "NumeProdus", produsComanda.ProdusID);
            return View(produsComanda);
        }

        // GET: ProdusComandas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdusComanda produsComanda = await db.ProdusComanda.FindAsync(id);
            if (produsComanda == null)
            {
                return HttpNotFound();
            }
            return View(produsComanda);
        }

        // POST: ProdusComandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProdusComanda produsComanda = await db.ProdusComanda.FindAsync(id);
            db.ProdusComanda.Remove(produsComanda);
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
