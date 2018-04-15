using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace tristarweather
{
    internal class StationsListSingleton
    {
        private const string UrlToStations = "http://pomiary.gdmel.pl/rest/stations";
        private static StationsListSingleton _stationsListSingleton;
        private static readonly object LockingObject = new object();
        private static WebClient _webClient;
        private static StreamReader _sr;
        private static Stream _stream;
        private static DetailedWeatherData _detailedWeatherData;

        private StationsListSingleton()
        {
            _webClient = new WebClient();
        }


        public static StationsListSingleton Instance
        {
            get
            {
                if (_stationsListSingleton == null)
                    lock (LockingObject)
                    {
                        if (_stationsListSingleton == null) _stationsListSingleton = new StationsListSingleton();
                    }

                return _stationsListSingleton;
            }
        }

        public JsonMain GetData()
        {
            _stream = _webClient.OpenRead(UrlToStations);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            var rootObject = JsonConvert.DeserializeObject<JsonMain>(json);

            return rootObject;
        }


        public static DetailedWeatherData GetDetailedData(string url)
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(url);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _detailedWeatherData = JsonConvert.DeserializeObject<DetailedWeatherData>(json);

            return _detailedWeatherData;
        }
    }
}