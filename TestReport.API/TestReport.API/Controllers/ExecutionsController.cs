using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestReport.API.Models;

namespace TestReport.API.Controllers
{
    [Authorize]
    public class ExecutionsController : ApiController
    {
        private TestReportEntities db = new TestReportEntities();

        // GET: api/Executions
        public IQueryable<Execution> GetExecution()
        {
            return db.Execution;
        }

        // GET: api/Executions/5
        [ResponseType(typeof(Execution))]
        public IHttpActionResult GetExecution(int id)
        {
            Execution execution = db.Execution.Find(id);
            if (execution == null)
            {
                return NotFound();
            }

            return Ok(execution);
        }

        // POST Execution
        [ResponseType(typeof(Execution))]
        public IHttpActionResult PostExecution(Execution execution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Execution.Add(execution);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = execution.id }, execution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExecutionExists(int id)
        {
            return db.Execution.Count(e => e.id == id) > 0;
        }
    }
}