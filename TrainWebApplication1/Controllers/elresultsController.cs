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
using TrainWebApplication1.Models;

namespace TrainWebApplication1.Controllers
{
    public class elresultsController : ApiController
    {
        private elactivity db = new elactivity();

        // GET: api/elresults
        public IQueryable<elresult> GetResults()
        {
            return db.Results;
        }

        // GET: api/elresults/5
        [ResponseType(typeof(elresult))]
        public IHttpActionResult Getelresult(int id)
        {
            elresult elresult = db.Results.Find(id);
            if (elresult == null)
            {
                return NotFound();
            }

            return Ok(elresult);
        }

        // PUT: api/elresults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putelresult(int id, elresult elresult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elresult.id)
            {
                return BadRequest();
            }

            db.Entry(elresult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elresultExists(id))
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

        // POST: api/elresults
        [ResponseType(typeof(elresult))]
        public IHttpActionResult Postelresult(elresult elresult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Results.Add(elresult);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = elresult.id }, elresult);
        }

        // DELETE: api/elresults/5
        [ResponseType(typeof(elresult))]
        public IHttpActionResult Deleteelresult(int id)
        {
            elresult elresult = db.Results.Find(id);
            if (elresult == null)
            {
                return NotFound();
            }

            db.Results.Remove(elresult);
            db.SaveChanges();

            return Ok(elresult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool elresultExists(int id)
        {
            return db.Results.Count(e => e.id == id) > 0;
        }
    }
}