using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagneticMonitoringApp.Models
{
    public class Measurement1
    {
    }

    [MetadataType(typeof(MeasurementMetaData))]
    public partial class Measurement
    {
    }

    public class MeasurementMetaData
    {
        [Display(Name = "Raw signal")]
        public string Path1___raw_signal { get; set; }

        [Display(Name = "FFT")]
        public string Path2___fft { get; set; }

        [Display(Name = "Signal features")]
        public string Path3___signal_features { get; set; }
    }
}