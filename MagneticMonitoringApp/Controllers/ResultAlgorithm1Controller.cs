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
    [RoutePrefix("api/v1/ResultAlgorithm1")]
    public class ResultAlgorithm1Controller : ApiController
    {
        private MagneticDBContext db = new MagneticDBContext();

        //"The 'ObjectContent`1' type failed to serialize the response body for content type 'application/json; charset=utf-8'
        // to solve the problem - because we are using entity framework with related entities, use the code below : https://stackoverflow.com/questions/23098191/failed-to-serialize-the-response-in-web-api-with-json - 
        public ResultAlgorithm1Controller()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/v1/ResultAlgorithm1
        [Route("")]
        public IQueryable<ResultAlgorithm1> GetResultAlgorithm1()
        {
            return db.ResultAlgorithm1;
        }

        // GET: api/v1/ResultAlgorithm1?startDate=2020-08-24&endDate=2020-08-27
        [ResponseType(typeof(ResultAlgorithm1))]
        [Route("")]
        public IHttpActionResult GetResultAlgorithm1([FromUri] DateTime startDate, DateTime endDate)
        {
            DateTime endDatePlusOne = endDate.AddDays(1);

            IQueryable<ResultAlgorithm1> listResultAlgorithm1 = db.ResultAlgorithm1.Where(x => x.Date >= startDate && x.Date < endDatePlusOne);
            //if (listResultAlgorithm2 == null)
            //{
            //    return NotFound();
            //}

            if (listResultAlgorithm1.Count() == 0)
            {
                return Content(HttpStatusCode.NotFound, "Results are not found");
            }

            return Ok(listResultAlgorithm1);
        }

        //// PUT: api/ResultAlgorithm1/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutResultAlgorithm1(int id, ResultAlgorithm1 resultAlgorithm1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != resultAlgorithm1.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(resultAlgorithm1).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ResultAlgorithm1Exists(id))
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

        //// POST: api/ResultAlgorithm1
        //[ResponseType(typeof(ResultAlgorithm1))]
        //public IHttpActionResult PostResultAlgorithm1(ResultAlgorithm1 resultAlgorithm1)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ResultAlgorithm1.Add(resultAlgorithm1);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = resultAlgorithm1.Id }, resultAlgorithm1);
        //}

        //// DELETE: api/ResultAlgorithm1/5
        //[ResponseType(typeof(ResultAlgorithm1))]
        //public IHttpActionResult DeleteResultAlgorithm1(int id)
        //{
        //    ResultAlgorithm1 resultAlgorithm1 = db.ResultAlgorithm1.Find(id);
        //    if (resultAlgorithm1 == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ResultAlgorithm1.Remove(resultAlgorithm1);
        //    db.SaveChanges();

        //    return Ok(resultAlgorithm1);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultAlgorithm1Exists(int id)
        {
            return db.ResultAlgorithm1.Count(e => e.Id == id) > 0;
        }
    }
}