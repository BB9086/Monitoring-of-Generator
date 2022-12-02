using MagneticMonitoringApp.Common;
using MagneticMonitoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagneticMonitoringApp.Controllers
{
    [TrackExecutionTime]
    public class MultipleTablesController : Controller
    {
        // GET: MultipleTables
        public ActionResult Index()
        {
            MagneticDBContext db = new MagneticDBContext();
            return View(db.Generators.ToList());
        }

        public ActionResult Index1(int generatorId)
        {
            MagneticDBContext db = new MagneticDBContext();
            List<Measurement> measurements = db.Measurements.Where(x => x.GeneratorId == generatorId).ToList();
            return View(measurements);
        }

        public ActionResult Index2(int measurementId)
        {
            MagneticDBContext db = new MagneticDBContext();
            ResultAlgorithm1 resultAlgorithm1 = new ResultAlgorithm1();
            resultAlgorithm1 = db.ResultAlgorithm1.Where(x => x.MeasurementId == measurementId).SingleOrDefault();
            ResultAlgorithm2 resultAlgorithm2 = new ResultAlgorithm2();
            resultAlgorithm2 = db.ResultAlgorithm2.Where(x => x.MeasurementId == measurementId).SingleOrDefault();

            ResultAlgorithms1and2 resultAlgorithms1And2 = new ResultAlgorithms1and2();
            resultAlgorithms1And2.resultAlgorithm1 = resultAlgorithm1;
            resultAlgorithms1And2.resultAlgorithm2 = resultAlgorithm2;

            return View(resultAlgorithms1And2);
        }
    }
}