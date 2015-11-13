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
    public class PhasesController : ApiController
    {
        private TestReportEntities db = new TestReportEntities();

        // GET: api/Phases
        public IQueryable<Phase> GetPhase()
        {
            return db.Phase;
        }

        // GET: api/Phases/5
        [ResponseType(typeof(Phase))]
        public IHttpActionResult GetPhase(int id)
        {
            Phase phase = db.Phase.Find(id);
            if (phase == null)
            {
                return NotFound();
            }

            return Ok(phase);
        }

        // PUT: api/Phases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhase(int id, Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase.id)
            {
                return BadRequest();
            }

            db.Entry(phase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhaseExists(id))
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

        // POST: api/Phases
        [ResponseType(typeof(Phase))]
        public IHttpActionResult PostPhase(Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phase.Add(phase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phase.id }, phase);
        }

        // DELETE: api/Phases/5
        [ResponseType(typeof(Phase))]
        public IHttpActionResult DeletePhase(int id)
        {
            Phase phase = db.Phase.Find(id);
            if (phase == null)
            {
                return NotFound();
            }

            db.Phase.Remove(phase);
            db.SaveChanges();

            return Ok(phase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhaseExists(int id)
        {
            return db.Phase.Count(e => e.id == id) > 0;
        }
    }
}