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
    public class StatusController : ApiController
    {
        private TestReportEntities db = new TestReportEntities();

        // GET: api/Status
        public IQueryable<Status> GetStatus()
        {
            return db.Status;
        }

        // GET: api/Status/5
        [ResponseType(typeof(Status))]
        public IHttpActionResult GetStatus(int id)
        {
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusExists(int id)
        {
            return db.Status.Count(e => e.id == id) > 0;
        }
    }
}