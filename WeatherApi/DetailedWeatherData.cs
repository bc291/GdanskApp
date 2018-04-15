using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather
{
    public class DetailedWeatherData
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<List<string>> data { get; set; }
    }
}
