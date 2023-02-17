using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Data
{
    public class Country
    {
        public string? Name { get; set; }
        public List<string>? States { get; set; }
        public List<string>? Cities { get; set; }
    }
}
