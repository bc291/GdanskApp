using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather
{
    public class JsonMain
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Datum> data { get; set; }
    }
}
