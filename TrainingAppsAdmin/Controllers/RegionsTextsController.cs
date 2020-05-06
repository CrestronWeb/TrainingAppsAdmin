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
using System.Drawing;

namespace TrainingAppsAdmin.Controllers
{
    public class RegionsTextsController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: RegionsTexts
        public async Task<ActionResult> Index()
        {
            var regionsTexts = db.RegionsTexts.Include(r => r.tblRegion);
            return View(await regionsTexts.ToListAsync());
        }

        // GET: RegionsTexts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsText regionsText = await db.RegionsTexts.FindAsync(id);
            if (regionsText == null)
            {
                return HttpNotFound();
            }
            return View(regionsText);
        }

        // GET: RegionsTexts/Create
        public ActionResult Create(int? regionId)
        {
            ViewBag.RegionId = new SelectList(db.tblRegions, "RegionId", "Name", regionId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label");
            ViewBag.returnRegion = db.tblRegions.Find(regionId);
            return View();
        }

        // POST: RegionsTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RegionId,Language,Name")] RegionsText regionsText)
        {
            if (ModelState.IsValid)
            {
                db.RegionsTexts.Add(regionsText);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(db.tblRegions, "RegionId", "Name", regionsText.RegionId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", regionsText.Language);
            return View(regionsText);
        }

        // GET: RegionsTexts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsText regionsText = await db.RegionsTexts.FindAsync(id);
            if (regionsText == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(db.tblRegions, "RegionId", "Name", regionsText.RegionId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", regionsText.Language);
            return View(regionsText);
        }


        // POST: RegionsTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RegionId,Language,Name")] RegionsText regionsText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regionsText).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(db.tblRegions, "RegionId", "Name", regionsText.RegionId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", regionsText.Language);
            return View(regionsText);
        }

        // GET: RegionsTexts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionsText regionsText = await db.RegionsTexts.FindAsync(id);
            if (regionsText == null)
            {
                return HttpNotFound();
            }
            return View(regionsText);
        }

        // POST: RegionsTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RegionsText regionsText = await db.RegionsTexts.FindAsync(id);
            db.RegionsTexts.Remove(regionsText);
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
