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
    public class Adresa_LivrareController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: Adresa_Livrare
        public async Task<ActionResult> Index()
        {
            var adresa_Livrare = db.Adresa_Livrare.Include(a => a.Comanda);
            return View(await adresa_Livrare.ToListAsync());
        }

        // GET: Adresa_Livrare/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Livrare adresa_Livrare = await db.Adresa_Livrare.FindAsync(id);
            if (adresa_Livrare == null)
            {
                return HttpNotFound();
            }
            return View(adresa_Livrare);
        }

        // GET: Adresa_Livrare/Create
        public ActionResult Create()
        {
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID");
            return View();
        }

        // POST: Adresa_Livrare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdresaLivrareID,ComandaID,Adresa")] Adresa_Livrare adresa_Livrare)
        {
            if (ModelState.IsValid)
            {
                db.Adresa_Livrare.Add(adresa_Livrare);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Livrare.ComandaID);
            return View(adresa_Livrare);
        }

        // GET: Adresa_Livrare/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Livrare adresa_Livrare = await db.Adresa_Livrare.FindAsync(id);
            if (adresa_Livrare == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Livrare.ComandaID);
            return View(adresa_Livrare);
        }

        // POST: Adresa_Livrare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdresaLivrareID,ComandaID,Adresa")] Adresa_Livrare adresa_Livrare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresa_Livrare).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ComandaID = new SelectList(db.Comanda, "ComandaID", "ComandaID", adresa_Livrare.ComandaID);
            return View(adresa_Livrare);
        }

        // GET: Adresa_Livrare/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_Livrare adresa_Livrare = await db.Adresa_Livrare.FindAsync(id);
            if (adresa_Livrare == null)
            {
                return HttpNotFound();
            }
            return View(adresa_Livrare);
        }

        // POST: Adresa_Livrare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Adresa_Livrare adresa_Livrare = await db.Adresa_Livrare.FindAsync(id);
            db.Adresa_Livrare.Remove(adresa_Livrare);
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
