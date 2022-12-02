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
using MagneticMonitoringApp.Models;

namespace MagneticMonitoringApp.Controllers
{
    [Authorize]
    //Web api versioning using URI
    [RoutePrefix("api/v1/ResultAlgorithm2")]
    public class ResultAlgorithm2Controller : ApiController
    {
        private MagneticDBContext db = new MagneticDBContext();


        //"The 'ObjectContent`1' type failed to serialize the response body for content type 'application/json; charset=utf-8'
        // to solve the problem - because we are using entity framework with related entities, use the code below : https://stackoverflow.com/questions/23098191/failed-to-serialize-the-response-in-web-api-with-json - 
        public ResultAlgorithm2Controller()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        // GET: api/v1/ResultAlgorithm2
        [Route("")]
        public IQueryable<ResultAlgorithm2> GetResultAlgorithm2()
        {
            return db.ResultAlgorithm2;
        }

        // GET: api/v1/ResultAlgorithm2?startDate=2020-08-24&endDate=2020-08-27

        [ResponseType(typeof(ResultAlgorithm2))]
        [Route("")]
        public IHttpActionResult GetResultAlgorithm2([FromUri] DateTime startDate, DateTime endDate)
        {
            DateTime endDatePlusOne = endDate.AddDays(1);

            IQueryable<ResultAlgorithm2> listResultAlgorithm2 = db.ResultAlgorithm2.Where(x => x.Date >= startDate && x.Date < endDatePlusOne);
            //if (listResultAlgorithm2 == null)
            //{
            //    return NotFound();
            //}

            if (listResultAlgorithm2.Count() == 0)
            {
                return Content(HttpStatusCode.NotFound, "Results are not found");
            }

            return Ok(listResultAlgorithm2);
        }

        //// PUT: api/ResultAlgorithm2/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutResultAlgorithm2(int id, ResultAlgorithm2 resultAlgorithm2)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != resultAlgorithm2.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(resultAlgorithm2).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ResultAlgorithm2Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/ResultAlgorithm2
        //[ResponseType(typeof(ResultAlgorithm2))]
        //public IHttpActionResult PostResultAlgorithm2(ResultAlgorithm2 resultAlgorithm2)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ResultAlgorithm2.Add(resultAlgorithm2);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = resultAlgorithm2.Id }, resultAlgorithm2);
        //}

        //// DELETE: api/ResultAlgorithm2/5
        //[ResponseType(typeof(ResultAlgorithm2))]
        //public IHttpActionResult DeleteResultAlgorithm2(int id)
        //{
        //    ResultAlgorithm2 resultAlgorithm2 = db.ResultAlgorithm2.Find(id);
        //    if (resultAlgorithm2 == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ResultAlgorithm2.Remove(resultAlgorithm2);
        //    db.SaveChanges();

        //    return Ok(resultAlgorithm2);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultAlgorithm2Exists(int id)
        {
            return db.ResultAlgorithm2.Count(e => e.Id == id) > 0;
        }
    }
}