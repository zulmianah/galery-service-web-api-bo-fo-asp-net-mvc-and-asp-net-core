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
using rest.Models;

namespace rest.Controllers
{
    public class MyLoginController : ApiController
    {
        private galery db = new galery();

        [System.Web.Http.Route("api/Login/Insert")]
        [HttpPost]
        public Response Insert(MYLOGIN Reg)
        {
            try
            {
                db.MYLOGINs.Add(Reg);
                db.SaveChanges();
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch (Exception)
            {
                return new Response { Status = "Error", Message = "Invalid Data." };
                throw;
            }
        }
        [System.Web.Http.Route("api/Login/Login")]
        [HttpPost]
        public Response Login(MYLOGIN login)
        {
            var log = db.MYLOGINs.Where(x => x.EMAIL.Equals(login.EMAIL) && x.PASSWORD.Equals(login.PASSWORD)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
            {
                return new Response { Status = "Success", Message = "Login Successfully" };
            }

        }

        // GET: api/MyLogin
        public IQueryable<MYLOGIN> GetMYLOGINs()
        {
            return db.MYLOGINs;
        }

        // GET: api/MyLogin/5
        [ResponseType(typeof(MYLOGIN))]
        public IHttpActionResult GetMYLOGIN(int id)
        {
            MYLOGIN mYLOGIN = db.MYLOGINs.Find(id);
            if (mYLOGIN == null)
            {
                return NotFound();
            }

            return Ok(mYLOGIN);
        }

        // PUT: api/MyLogin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMYLOGIN(int id, MYLOGIN mYLOGIN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mYLOGIN.ID)
            {
                return BadRequest();
            }

            db.Entry(mYLOGIN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MYLOGINExists(id))
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

        // POST: api/MyLogin
        [ResponseType(typeof(MYLOGIN))]
        public IHttpActionResult PostMYLOGIN(MYLOGIN mYLOGIN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MYLOGINs.Add(mYLOGIN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mYLOGIN.ID }, mYLOGIN);
        }

        // DELETE: api/MyLogin/5
        [ResponseType(typeof(MYLOGIN))]
        public IHttpActionResult DeleteMYLOGIN(int id)
        {
            MYLOGIN mYLOGIN = db.MYLOGINs.Find(id);
            if (mYLOGIN == null)
            {
                return NotFound();
            }

            db.MYLOGINs.Remove(mYLOGIN);
            db.SaveChanges();

            return Ok(mYLOGIN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MYLOGINExists(int id)
        {
            return db.MYLOGINs.Count(e => e.ID == id) > 0;
        }
    }
}