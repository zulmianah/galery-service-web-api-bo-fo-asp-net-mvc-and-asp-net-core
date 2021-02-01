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
using rest;

namespace rest.Controllers
{
    public class CategoryPictureController : ApiController
    {
        private galery db = new galery();

        // GET: api/CategoryPicture
        public IQueryable<CATEGORY_PICTURE> GetCATEGORY_PICTURE()
        {
            return db.CATEGORY_PICTURE;
        }

        // GET: api/CategoryPicture/5
        [ResponseType(typeof(CATEGORY_PICTURE))]
        public IHttpActionResult GetCATEGORY_PICTURE(int id)
        {
            CATEGORY_PICTURE cATEGORY_PICTURE = db.CATEGORY_PICTURE.Find(id);
            if (cATEGORY_PICTURE == null)
            {
                return NotFound();
            }

            return Ok(cATEGORY_PICTURE);
        }

        // PUT: api/CategoryPicture/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCATEGORY_PICTURE(int id, CATEGORY_PICTURE cATEGORY_PICTURE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cATEGORY_PICTURE.ID_CATEGORY_PICTURE)
            {
                return BadRequest();
            }

            db.Entry(cATEGORY_PICTURE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORY_PICTUREExists(id))
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

        // POST: api/CategoryPicture
        [ResponseType(typeof(CATEGORY_PICTURE))]
        public IHttpActionResult PostCATEGORY_PICTURE(CATEGORY_PICTURE cATEGORY_PICTURE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CATEGORY_PICTURE.Add(cATEGORY_PICTURE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CATEGORY_PICTUREExists(cATEGORY_PICTURE.ID_CATEGORY_PICTURE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cATEGORY_PICTURE.ID_CATEGORY_PICTURE }, cATEGORY_PICTURE);
        }
        [HttpDelete]
        // DELETE: api/CategoryPicture/5
        [ResponseType(typeof(CATEGORY_PICTURE))]
        public IHttpActionResult DeleteCATEGORY_PICTURE(int id)
        {
            CATEGORY_PICTURE cATEGORY_PICTURE = db.CATEGORY_PICTURE.Find(id);
            if (cATEGORY_PICTURE == null)
            {
                return NotFound();
            }

            db.CATEGORY_PICTURE.Remove(cATEGORY_PICTURE);
            db.SaveChanges();

            return Ok(cATEGORY_PICTURE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CATEGORY_PICTUREExists(int id)
        {
            return db.CATEGORY_PICTURE.Count(e => e.ID_CATEGORY_PICTURE == id) > 0;
        }
    }
}