using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagneticMonitoringApp.Common
{
    public class TrackExecutionTime : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.RouteData.Values["controller"].ToString() + " -> " +
               filterContext.RouteData.Values["action"].ToString() + " -> " +
               filterContext.Exception.Message + " \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("---------------------------------------------------------\n");
        }

        private void LogExecutionTime(string message)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), message);
        }
    }
}