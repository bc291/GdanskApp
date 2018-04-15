using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather
{
    public class TypesOfDataEnum
    {
        public const string rain = "mm";
        public const string water = "m";
        public const string winddir = "kierunek";
        public const string windlevel = "m/s";

        public enum DataTypes : long
        {
            rain=1, water, winddir, windlevel,
        }

        public enum WeatherParameters : long
        {
            DateAndTime = 1, TemperatureInCelsius, WindSpeed, WindDir,
            Cloudiness, Humidity, TempMax, TempMin, PressureGroundLevel
        }
    }


}
