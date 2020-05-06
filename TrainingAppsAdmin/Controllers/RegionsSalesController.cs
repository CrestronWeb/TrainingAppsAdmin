using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingAppsAdmin.Models;

namespace TrainingAppsAdmin.Controllers
{
    public class RegionsSalesController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: RegionsSales
        public async Task<ActionResult> Index()
        {
            return View(await db.RegionsSales.ToListAsync());
        }

        // GET: RegionsSales/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsSale regionsSale = await db.RegionsSales.FindAsync(id);
            if (regionsSale == null)
            {
                return HttpNotFound();
            }
            return View(regionsSale);
        }

        // GET: RegionsSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionsSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Priority,Active")] RegionsSale regionsSale)
        {
            if (ModelState.IsValid)
            {
                db.RegionsSales.Add(regionsSale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(regionsSale);
        }

        // GET: RegionsSales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsSale regionsSale = await db.RegionsSales.FindAsync(id);
            if (regionsSale == null)
            {
                return HttpNotFound();
            }
            return View(regionsSale);
        }

        // POST: RegionsSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Priority,Active")] RegionsSale regionsSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regionsSale).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(regionsSale);
        }

        // GET: RegionsSales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsSale regionsSale = await db.RegionsSales.FindAsync(id);
            if (regionsSale == null)
            {
                return HttpNotFound();
            }
            return View(regionsSale);
        }

        // POST: RegionsSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RegionsSale regionsSale = await db.RegionsSales.FindAsync(id);
            db.RegionsSales.Remove(regionsSale);
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
