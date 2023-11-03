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
    public class Categorii_ProduseController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: Categorii_Produse
        public async Task<ActionResult> Index()
        {
            return View(await db.Categorii_Produse.ToListAsync());
        }

        // GET: Categorii_Produse/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorii_Produse categorii_Produse = await db.Categorii_Produse.FindAsync(id);
            if (categorii_Produse == null)
            {
                return HttpNotFound();
            }
            return View(categorii_Produse);
        }

        // GET: Categorii_Produse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorii_Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategorieID,NumeCategorie")] Categorii_Produse categorii_Produse)
        {
            if (ModelState.IsValid)
            {
                db.Categorii_Produse.Add(categorii_Produse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categorii_Produse);
        }

        // GET: Categorii_Produse/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorii_Produse categorii_Produse = await db.Categorii_Produse.FindAsync(id);
            if (categorii_Produse == null)
            {
                return HttpNotFound();
            }
            return View(categorii_Produse);
        }

        // POST: Categorii_Produse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategorieID,NumeCategorie")] Categorii_Produse categorii_Produse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorii_Produse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categorii_Produse);
        }

        // GET: Categorii_Produse/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorii_Produse categorii_Produse = await db.Categorii_Produse.FindAsync(id);
            if (categorii_Produse == null)
            {
                return HttpNotFound();
            }
            return View(categorii_Produse);
        }

        // POST: Categorii_Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categorii_Produse categorii_Produse = await db.Categorii_Produse.FindAsync(id);
            db.Categorii_Produse.Remove(categorii_Produse);
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
