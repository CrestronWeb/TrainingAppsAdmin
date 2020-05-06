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
using TrainingAppsAdmin.ViewModels;

namespace TrainingAppsAdmin.Controllers
{
    public class RegionsController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: Regions
        public async Task<ActionResult> Index()
        {
            return View(await db.tblRegions.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegion tblRegion = await db.tblRegions.FindAsync(id);
            if (tblRegion == null)
            {
                return HttpNotFound();
            }
            return View(tblRegion);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RegionId,Name,Priority,Active")] tblRegion tblRegion)
        {
            if (ModelState.IsValid)
            {
                db.tblRegions.Add(tblRegion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblRegion);
        }

        // GET: Regions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegion tblRegion = await db.tblRegions.FindAsync(id);
            if (tblRegion == null)
            {
                return HttpNotFound();
            }
            PopulateRegionsTextsData(tblRegion);
            return View(tblRegion);
        }

        private void PopulateRegionsTextsData(tblRegion tblRegion)
        {
            var allRegionsText = from rt in db.RegionsTexts
                                       where (rt.RegionId == tblRegion.RegionId)
                                       select new vmRegionsText
                                       {
                                           RegionsTextId = rt.Id,
                                           Region = rt.tblRegion.Name,
                                           Language = rt.Language1.Label,
                                           Name = rt.Name
                                       };
            var viewModel = new List<vmRegionsText>();
            foreach (var text in allRegionsText)
            {
                viewModel.Add(new vmRegionsText
                {
                    RegionsTextId = text.RegionsTextId,
                    Region = text.Region,
                    Language = text.Language,
                    Name = text.Name
                });
            }
            ViewBag.RegionsText = viewModel;
        }



        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RegionId,Name,Priority,Active")] tblRegion tblRegion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblRegion);
        }

        // GET: Regions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegion tblRegion = await db.tblRegions.FindAsync(id);
            if (tblRegion == null)
            {
                return HttpNotFound();
            }
            return View(tblRegion);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblRegion tblRegion = await db.tblRegions.FindAsync(id);
            db.tblRegions.Remove(tblRegion);
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
