using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Maritime.Web.Models
{
    public class IndexViewModel
    {
        [Display(Name = "Standard Deviation")]
        public double StandardDeviation { get; set; }

        [Display(Name = "Arithmetic Mean")]
        public double Mean { get; set; }

        public IDictionary<Tuple<double, double>, int> FrequencyDistribution { get; set; }
    }
}
