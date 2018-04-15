using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace tristarweather
{
    internal class WeatherSingleton
    {
        private const string UrlToWeather =
            "http://api.openweathermap.org/data/2.5/forecast?id=3099434&APPID=47be9fce480a710280f27c66c88f97a3";

        private static WeatherSingleton _weatherSingleton;
        private static readonly object LockingObject = new object();
        private static WebClient _webClient;
        private static StreamReader _sr;
        private static Stream _stream;
        private static WeatherInstance _weatherInstance;

        private WeatherSingleton()
        {
            _webClient = new WebClient();
        }


        public static WeatherSingleton Instance
        {
            get
            {
                if (_weatherSingleton == null)
                    lock (LockingObject)
                    {
                        if (_weatherSingleton == null) _weatherSingleton = new WeatherSingleton();
                    }

                return _weatherSingleton;
            }
        }


        public static WeatherInstance GetDetailedData()
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlToWeather);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _weatherInstance = JsonConvert.DeserializeObject<WeatherInstance>(json);

            return _weatherInstance;
        }
    }
}