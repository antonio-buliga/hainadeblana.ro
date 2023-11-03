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
    public class ComandasController : Controller
    {
        private hainadeblanaEntities db = new hainadeblanaEntities();

        // GET: Comandas
        public async Task<ActionResult> Index()
        {
            var comanda = db.Comanda.Include(c => c.Client);
            return View(await comanda.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = await db.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // GET: Comandas/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "NumeUtilizator");
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ComandaID,ClientID,DataComanda")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Comanda.Add(comanda);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "NumeUtilizator", comanda.ClientID);
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = await db.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "NumeUtilizator", comanda.ClientID);
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ComandaID,ClientID,DataComanda")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comanda).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Client, "ClientID", "NumeUtilizator", comanda.ClientID);
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = await db.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comanda comanda = await db.Comanda.FindAsync(id);
            db.Comanda.Remove(comanda);
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
