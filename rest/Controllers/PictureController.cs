using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using bo.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using rest;
using rest.Models;

namespace rest.Controllers
{
    public class PictureController : ApiController
    {
        private galery db = new galery();

        // GET: api/Picture
        /*public IQueryable<PICTURE> GetPICTUREs()
        {
            return db.PICTUREs;
        }*/

        // GET: api/Picture/5
        [ResponseType(typeof(PICTURE))]
        public IHttpActionResult GetPICTURE(int id)
        {
            PICTURE pICTURE = db.PICTUREs.Find(id);
            if (pICTURE == null)
            {
                return NotFound();
            }

            return Ok(pICTURE);
        }

        // PUT: api/Picture/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPICTURE(int id, PICTURE pICTURE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pICTURE.ID_PICTURE)
            {
                return BadRequest();
            }

            db.Entry(pICTURE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PICTUREExists(id))
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

        // POST: api/Picture
        [ResponseType(typeof(PICTURE))]
        public async System.Threading.Tasks.Task<HttpResponseMessage> PostPICTURE()
        {

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                PICTURE pICTURE = null;
                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        if (key == "pICTURE")
                        {
                            pICTURE = JsonConvert.DeserializeObject<PICTURE>(val);
                            if (!ModelState.IsValid)
                            {
                                return Request.CreateResponse(HttpStatusCode.BadRequest);
                            }
                            db.PICTUREs.Add(pICTURE);
                            db.SaveChanges();
                        }
                        HttpResponseMessage result = null;
                        var httpRequest = HttpContext.Current.Request;

                        if (httpRequest.Files.Count > 0)
                        {
                            var docfiles = new List<string>();
                            foreach (string file in httpRequest.Files)
                            {
                                var postedFile = httpRequest.Files[file];
                                var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + pICTURE.ID_PICTURE + ".jpg");
                                postedFile.SaveAs(filePath);
                                docfiles.Add(filePath);
                            }
                            result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                        }
                        else
                        {
                            result = Request.CreateResponse(HttpStatusCode.BadRequest);
                        }
                        return result;
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        // DELETE: api/Picture/5
        [ResponseType(typeof(PICTURE))]
        public IHttpActionResult DeletePICTURE(int id)
        {
            PICTURE pICTURE = db.PICTUREs.Find(id);
            if (pICTURE == null)
            {
                return NotFound();
            }

            db.PICTUREs.Remove(pICTURE);
            db.SaveChanges();

            return Ok(pICTURE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PICTUREExists(int id)
        {
            return db.PICTUREs.Count(e => e.ID_PICTURE == id) > 0;
        }

        // https://localhost:44388/api/Picture/CategoryPicture/paginate?IdCategoryPicture=65&pageNumber=1&pageSize=2

        [System.Web.Http.Route("api/Picture/CategoryPicture/paginate")]
        public PaginatePicture GetPICTUREs(int IdCategoryPicture, [FromUri]PagingParameterModel pagingparametermodel)
        {

            // Return List of Customer  
            var source = (from p in db.PICTUREs.OrderBy(p => p.ID_CATEGORY_PICTURE).Where(i => i.ID_CATEGORY_PICTURE == IdCategoryPicture) select p).AsQueryable();

            // Get's No of Rows Count   
            int count = source.Count();

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pagingparametermodel.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pagingparametermodel.pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };

            return new PaginatePicture(items,
                                       TotalCount,
                                       PageSize,
                                       CurrentPage,
                                       TotalPages,
                                       previousPage,
                                       nextPage);

        }
    }
}