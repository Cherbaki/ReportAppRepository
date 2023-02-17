using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
#nullable disable
    public class ReportersInformation
    {
        public required string Reporter { get; set; }
        public required string Name { get; set; }
        public string ReporterType { get; set; }
        public string Occupation { get; set; }
        public string SpecialityArea { get; set; }
        public required string Address { get; set; }
        public required string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string LandlineNo { get; set; }
        public string MobileNo { get; set; }
        public required string Email { get; set; }
        public required string FaxNo { get; set; }
        public required DateTime ReportDate { get; set; }
    }
}
