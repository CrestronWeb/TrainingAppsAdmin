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
    public class AccreditationsTextsController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: AccreditationsTexts
        public async Task<ActionResult> Index()
        {
            var accreditationsTexts = db.AccreditationsTexts.Include(a => a.Accreditation).Include(a => a.Language1);
            return View(await accreditationsTexts.ToListAsync());
        }

        // GET: AccreditationsTexts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccreditationsText accreditationsText = await db.AccreditationsTexts.FindAsync(id);
            if (accreditationsText == null)
            {
                return HttpNotFound();
            }
            return View(accreditationsText);
        }

        // GET: AccreditationsTexts/Create
        public ActionResult Create(int? AccreditationsId)
        {
            ViewBag.AccreditationId = new SelectList(db.Accreditations, "Id", "Name", AccreditationsId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label");
            ViewBag.returnAccreditation = db.Accreditations.Find(AccreditationsId);
            return View();
        }

        // POST: AccreditationsTexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AccreditationId,Language,Label")] AccreditationsText accreditationsText)
        {
            if (ModelState.IsValid)
            {
                db.AccreditationsTexts.Add(accreditationsText);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AccreditationId = new SelectList(db.Accreditations, "Id", "Name", accreditationsText.AccreditationId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", accreditationsText.Language);
            return View(accreditationsText);
        }

        // GET: AccreditationsTexts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccreditationsText accreditationsText = await db.AccreditationsTexts.FindAsync(id);
            if (accreditationsText == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccreditationId = new SelectList(db.Accreditations, "Id", "Name", accreditationsText.AccreditationId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", accreditationsText.Language);
            return View(accreditationsText);
        }

        // POST: AccreditationsTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AccreditationId,Language,Label")] AccreditationsText accreditationsText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accreditationsText).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccreditationId = new SelectList(db.Accreditations, "Id", "Name", accreditationsText.AccreditationId);
            ViewBag.Language = new SelectList(db.Languages, "ISO", "Label", accreditationsText.Language);
            return View(accreditationsText);
        }

        // GET: AccreditationsTexts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccreditationsText accreditationsText = await db.AccreditationsTexts.FindAsync(id);
            if (accreditationsText == null)
            {
                return HttpNotFound();
            }
            return View(accreditationsText);
        }

        // POST: AccreditationsTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AccreditationsText accreditationsText = await db.AccreditationsTexts.FindAsync(id);
            db.AccreditationsTexts.Remove(accreditationsText);
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
