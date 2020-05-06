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
    public class AccreditationsController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: Accreditations
        public async Task<ActionResult> Index()
        {
            return View(await db.Accreditations.ToListAsync());
        }

        // GET: Accreditations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accreditation accreditation = await db.Accreditations.FindAsync(id);
            if (accreditation == null)
            {
                return HttpNotFound();
            }
            return View(accreditation);
        }

        // GET: Accreditations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accreditations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Active")] Accreditation accreditation)
        {
            if (ModelState.IsValid)
            {
                db.Accreditations.Add(accreditation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accreditation);
        }

        // GET: Accreditations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accreditation accreditation = await db.Accreditations.FindAsync(id);
            if (accreditation == null)
            {
                return HttpNotFound();
            }
            PopulateAssignedAccreditationTextData(accreditation);
            return View(accreditation);
        }

        private void PopulateAssignedAccreditationTextData(Accreditation accreditation)
        {
            var allAccreditationText = from a in db.AccreditationsTexts
                                       where (a.AccreditationId == accreditation.Id)
                                       select new vmAccreditationsTexts
                                       {
                                           AccreditationsTextId = a.Id,
                                           Language = a.Language1.Label,
                                           Label = a.Label
                                       };
            var viewModel = new List<vmAccreditationsTexts>();
            foreach (var text in allAccreditationText)
            {
                viewModel.Add(new vmAccreditationsTexts
                {
                    AccreditationsTextId = text.AccreditationsTextId,
                    Language = text.Language,
                    Label = text.Label
                });
            }
            ViewBag.AccreditationText = viewModel;
        }


        // POST: Accreditations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Active")] Accreditation accreditation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accreditation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accreditation);
        }

        // GET: Accreditations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accreditation accreditation = await db.Accreditations.FindAsync(id);
            if (accreditation == null)
            {
                return HttpNotFound();
            }
            return View(accreditation);
        }

        // POST: Accreditations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Accreditation accreditation = await db.Accreditations.FindAsync(id);
            db.Accreditations.Remove(accreditation);
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
