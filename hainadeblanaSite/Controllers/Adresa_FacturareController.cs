using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HainadeblanaSite.Models;

namespace HainadeblanaSite.Controllers
{
    public class Adresa_FacturareController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: Adresa_Facturare
        public async Task<ActionResult> Index()
        {
            var adresa_Facturare = db.Adresa_Facturare.Include(a => a.Comanda);
            return View(await adresa_Facturare.ToListAsync());
        }

        // GET: Adresa_Facturare/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Facturare adresa_Facturare = await db.Adresa_Facturare.FindAsync(id);
            if (adresa_Facturare == null)
            {
                return HttpNotFound();
            }
            return View(adresa_Facturare);
        }

        // GET: Adresa_Facturare/Create
        public ActionResult Create()
        {
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID");
            return View();
        }

        // POST: Adresa_Facturare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdresaFacturareID,ComandaID,Adresa")] Adresa_Facturare adresa_Facturare)
        {
            if (ModelState.IsValid)
            {
                db.Adresa_Facturare.Add(adresa_Facturare);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Facturare.ComandaID);
            return View(adresa_Facturare);
        }

        // GET: Adresa_Facturare/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Facturare adresa_Facturare = await db.Adresa_Facturare.FindAsync(id);
            if (adresa_Facturare == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Facturare.ComandaID);
            return View(adresa_Facturare);
        }

        // POST: Adresa_Facturare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdresaFacturareID,ComandaID,Adresa")] Adresa_Facturare adresa_Facturare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresa_Facturare).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Facturare.ComandaID);
            return View(adresa_Facturare);
        }

        // GET: Adresa_Facturare/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Facturare adresa_Facturare = await db.Adresa_Facturare.FindAsync(id);
            if (adresa_Facturare == null)
            {
                return HttpNotFound();
            }
            return View(adresa_Facturare);
        }

        // POST: Adresa_Facturare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Adresa_Facturare adresa_Facturare = await db.Adresa_Facturare.FindAsync(id);
            db.Adresa_Facturare.Remove(adresa_Facturare);
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
