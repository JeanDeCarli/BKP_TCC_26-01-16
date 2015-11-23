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

        // PUT: api/Executions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExecution(int id, Execution execution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != execution.id)
            {
                return BadRequest();
            }

            db.Entry(execution).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExecutionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Executions
        [ResponseType(typeof(Execution))]
        public IHttpActionResult PostExecution(Execution execution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Execution.Add(execution);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExecutionExists(execution.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = execution.id }, execution);
        }

        // DELETE: api/Executions/5
        [ResponseType(typeof(Execution))]
        public IHttpActionResult DeleteExecution(int id)
        {
            Execution execution = db.Execution.Find(id);
            if (execution == null)
            {
                return NotFound();
            }

            db.Execution.Remove(execution);
            db.SaveChanges();

            return Ok(execution);
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