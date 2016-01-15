using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestReport.Web.Models;

namespace TestReport.Web.Controllers
{
    [Authorize]
    public class ExecutionsController : Controller
    {
        private TestReportEntities db = new TestReportEntities();

        // GET: Executions
        public ActionResult Index()
        {
            var executions = db.Executions.Include(e => e.Phase).Include(e => e.Project).Include(e => e.Status);
            return View(executions.ToList());
        }

        // GET: Executions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            return View(execution);
        }

        // GET: Executions/Create
        public ActionResult Create()
        {
            ViewBag.idPhase = new SelectList(db.Phases, "id", "name");
            ViewBag.idProject = new SelectList(db.Projects, "id", "name");
            ViewBag.idStatus = new SelectList(db.Status, "id", "name");
            return View();
        }

        // POST: Executions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,testName,idStatus,idPhase,idProject,executionTime,executionDate")] Execution execution)
        {
            if (ModelState.IsValid)
            {
                db.Executions.Add(execution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPhase = new SelectList(db.Phases, "id", "name", execution.idPhase);
            ViewBag.idProject = new SelectList(db.Projects, "id", "name", execution.idProject);
            ViewBag.idStatus = new SelectList(db.Status, "id", "name", execution.idStatus);
            return View(execution);
        }

        // GET: Executions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPhase = new SelectList(db.Phases, "id", "name", execution.idPhase);
            ViewBag.idProject = new SelectList(db.Projects, "id", "name", execution.idProject);
            ViewBag.idStatus = new SelectList(db.Status, "id", "name", execution.idStatus);
            return View(execution);
        }

        // POST: Executions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,testName,idStatus,idPhase,idProject,executionTime,executionDate")] Execution execution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(execution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPhase = new SelectList(db.Phases, "id", "name", execution.idPhase);
            ViewBag.idProject = new SelectList(db.Projects, "id", "name", execution.idProject);
            ViewBag.idStatus = new SelectList(db.Status, "id", "name", execution.idStatus);
            return View(execution);
        }

        // GET: Executions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Execution execution = db.Executions.Find(id);
            if (execution == null)
            {
                return HttpNotFound();
            }
            return View(execution);
        }

        // POST: Executions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Execution execution = db.Executions.Find(id);
            db.Executions.Remove(execution);
            db.SaveChanges();
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
