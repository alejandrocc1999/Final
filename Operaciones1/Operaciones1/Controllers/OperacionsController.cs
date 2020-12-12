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
using Operaciones1.Models;

namespace Operaciones1.Controllers
{
    public class OperacionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Operacions
        public IQueryable<Operacion> GetOperacions()
        {
            return db.Operacions;
        }

        // GET: api/Operacions/5
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult GetOperacion(double id)
        {
            Operacion operacion = db.Operacions.Find(id);
            if (operacion == null)
            {
                return NotFound();
            }

            return Ok(operacion);
        }

        // PUT: api/Operacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOperacion(double id, Operacion operacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operacion.numero)
            {
                return BadRequest();
            }

            db.Entry(operacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionExists(id))
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

        // POST: api/Operacions
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult PostOperacion(Operacion operacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operacions.Add(operacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OperacionExists(operacion.numero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = operacion.numero }, operacion);
        }

        // DELETE: api/Operacions/5
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult DeleteOperacion(double id)
        {
            Operacion operacion = db.Operacions.Find(id);
            if (operacion == null)
            {
                return NotFound();
            }

            db.Operacions.Remove(operacion);
            db.SaveChanges();

            return Ok(operacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperacionExists(double id)
        {
            return db.Operacions.Count(e => e.numero == id) > 0;
        }
    }
}