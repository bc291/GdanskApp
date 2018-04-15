using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather
{
    public class Datum
    {
        public int no { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public bool rain { get; set; }
        public bool water { get; set; }
        public bool winddir { get; set; }
        public bool windlevel { get; set; }
    }
}
