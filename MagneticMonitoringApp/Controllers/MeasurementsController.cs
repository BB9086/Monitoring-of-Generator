using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagneticMonitoringApp.Common;
using MagneticMonitoringApp.Models;

namespace MagneticMonitoringApp.Controllers
{
    [TrackExecutionTime]
    public class MeasurementsController : Controller
    {
        private MagneticDBContext db = new MagneticDBContext();

        // GET: Measurements
        public ActionResult Index()
        {
            var measurements = db.Measurements.Include(m => m.Generator);
            return View(measurements.ToList());
        }

        // GET: Measurements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // GET: Measurements/Create
        public ActionResult Create()
        {
            ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name");
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Path1___raw_signal,Path2___fft,Path3___signal_features,GeneratorId")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Measurements.Add(measurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", measurement.GeneratorId);
            return View(measurement);
        }

        // GET: Measurements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", measurement.GeneratorId);
            return View(measurement);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,Path1___raw_signal,Path2___fft,Path3___signal_features,Name")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", measurement.GeneratorId);
            return View(measurement);
        }

        // GET: Measurements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            db.Measurements.Remove(measurement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetData(string filepath)
        {
            //string filepath = @"C:\Users\blagoje\Desktop\DataMagneticMonitoring\G1\Raw_signal_1.lvm";
            List<string> lines = System.IO.File.ReadAllLines(filepath+".lvm").ToList();

            
            List<Coordinate> coordinates = new List<Coordinate>();

            foreach (var line in lines)
            {
                Coordinate coordinate = new Coordinate();
                //divide coordinates in one line and put them as array elements
                string[] separateCoordinate = line.Split('\t');
                coordinate.xCoordinate = Convert.ToDouble(separateCoordinate[0]);
                coordinate.yCoordinate = Convert.ToDouble(separateCoordinate[1]);
                coordinates.Add(coordinate);
            }

            return Json(coordinates, JsonRequestBehavior.AllowGet);
        }

    }
}
