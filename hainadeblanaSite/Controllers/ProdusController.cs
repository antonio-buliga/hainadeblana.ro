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
    public class ProdusController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: Produs
        public async Task<ActionResult> Index()
        {
            var produs = db.Produs.Include(p => p.Categorii_Produse);
            return View(await produs.ToListAsync());
        }

        // GET: Produs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // GET: Produs/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.Categorii_Produse, "CategorieID", "NumeCategorie");
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProdusID,NumeProdus,Pret,Descriere,CategorieID")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Produs.Add(produs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.Categorii_Produse, "CategorieID", "NumeCategorie", produs.CategorieID);
            return View(produs);
        }

        // GET: Produs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.Categorii_Produse, "CategorieID", "NumeCategorie", produs.CategorieID);
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdusID,NumeProdus,Pret,Descriere,CategorieID")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.Categorii_Produse, "CategorieID", "NumeCategorie", produs.CategorieID);
            return View(produs);
        }

        // GET: Produs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = await db.Produs.FindAsync(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produs produs = await db.Produs.FindAsync(id);
            db.Produs.Remove(produs);
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
