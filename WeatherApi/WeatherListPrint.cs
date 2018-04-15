using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather
{
    public class WeatherListPrint
    {
        public string DateAndTime { set; get; }
        public double TemperatureInCelsius { set; get; }
        public double WindSpeed { set; get; }
        public double WindDir { set; get; }
        public int Cloudiness { set; get; }
        public int Humidity { set; get; }
        public double TempMax { set; get; }
        public double TempMin { set; get; }
        public double PressureGroundLevel { set; get; }
    }
}
