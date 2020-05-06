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
    public class Crestron101CoursesContentTypesController : Controller
    {
        private TrainingappsEntities db = new TrainingappsEntities();

        // GET: Crestron101CoursesContentTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.Crestron101CoursesContentTypes.ToListAsync());
        }

        // GET: Crestron101CoursesContentTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crestron101CoursesContentTypes crestron101CoursesContentTypes = await db.Crestron101CoursesContentTypes.FindAsync(id);
            if (crestron101CoursesContentTypes == null)
            {
                return HttpNotFound();
            }
            return View(crestron101CoursesContentTypes);
        }

        // GET: Crestron101CoursesContentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crestron101CoursesContentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Crestron101CoursesContentTypes crestron101CoursesContentTypes)
        {
            if (ModelState.IsValid)
            {
                db.Crestron101CoursesContentTypes.Add(crestron101CoursesContentTypes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(crestron101CoursesContentTypes);
        }

        // GET: Crestron101CoursesContentTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crestron101CoursesContentTypes crestron101CoursesContentTypes = await db.Crestron101CoursesContentTypes.FindAsync(id);
            if (crestron101CoursesContentTypes == null)
            {
                return HttpNotFound();
            }
            return View(crestron101CoursesContentTypes);
        }

        // POST: Crestron101CoursesContentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Crestron101CoursesContentTypes crestron101CoursesContentTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crestron101CoursesContentTypes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(crestron101CoursesContentTypes);
        }

        // GET: Crestron101CoursesContentTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crestron101CoursesContentTypes crestron101CoursesContentTypes = await db.Crestron101CoursesContentTypes.FindAsync(id);
            if (crestron101CoursesContentTypes == null)
            {
                return HttpNotFound();
            }
            return View(crestron101CoursesContentTypes);
        }

        // POST: Crestron101CoursesContentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Crestron101CoursesContentTypes crestron101CoursesContentTypes = await db.Crestron101CoursesContentTypes.FindAsync(id);
            db.Crestron101CoursesContentTypes.Remove(crestron101CoursesContentTypes);
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
