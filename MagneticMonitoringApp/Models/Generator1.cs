using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagneticMonitoringApp.Models
{
    public class Generator1
    {
    }

    [MetadataType(typeof(GeneratorMetaData))]
    public partial class Generator
    {
    }

    public class GeneratorMetaData
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Power (MW)")]
        [Range(1, 500)]
        [Required]
        public int Power_MW { get; set; }

        [Required]
        [Range(1950,2020)]
        public int Year { get; set; }
    }
}