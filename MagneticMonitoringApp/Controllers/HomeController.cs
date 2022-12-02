using MagneticMonitoringApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagneticMonitoringApp.Controllers
{
    [TrackExecutionTime]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GraphicView()
        {
            return View();
        }

        public ActionResult Spreadsheet()
        {
            return View();
        }


        public ActionResult TrendAnalysis()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}