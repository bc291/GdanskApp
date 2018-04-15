using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using tristarweather.CategoriesNew;
using tristarweather.Events;

namespace tristarweather
{
    internal class EventsSingleton
    {
        private const string UrlToPlaces = "http://planer.info.pl/api/rest/places.json";
        private const string UrlToEvents = "http://planer.info.pl/api/rest/events.json";
        private const string UrlToOrganizers = "http://planer.info.pl/api/rest/organizers.json";
        private const string UrlToCategories = "http://planer.info.pl/api/rest/categories.json";
        private static EventsSingleton _eventsSingleton;
        private static readonly object LockingObject = new object();
        private static WebClient _webClient;
        private static StreamReader _sr;

        private static string UrlRoot = "http://planer.info.pl/api/rest/events.json?start_date=";

        private static Stream _stream;
        private static EventsInstance[] _eventsInstance;
        private static List<Places> _listEventsPlaces;
        private static List<Events.Events> _listEventsAllEvents;
        private static List<Organizers> _listEventsOrganizers;
        private static List<Categories> _listEventsCategories;
        private static List<CategoriesFromPdf> _listCategoriesFromJson;

        private EventsSingleton()
        {
            _webClient = new WebClient();
        }


        public static EventsSingleton Instance
        {
            get
            {
                if (_eventsSingleton == null)
                    lock (LockingObject)
                    {
                        if (_eventsSingleton == null) _eventsSingleton = new EventsSingleton();
                    }

                return _eventsSingleton;
            }
        }


        public static EventsInstance[] GetDetailedData(string endDate)
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlRoot + endDate);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _eventsInstance = JsonConvert.DeserializeObject<EventsInstance[]>(json);

            return _eventsInstance;
        }


        public static List<Places> GetPlaces()
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlToPlaces);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _listEventsPlaces = JsonConvert.DeserializeObject<Places[]>(json).ToList();
            return _listEventsPlaces;
        }

        public static List<Events.Events> GetEvents()
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlToEvents);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _listEventsAllEvents = JsonConvert.DeserializeObject<Events.Events[]>(json).ToList();
            return _listEventsAllEvents;
        }

        public static List<Categories> GetCategories()
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlToCategories);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _listEventsCategories = JsonConvert.DeserializeObject<Categories[]>(json).ToList();
            return _listEventsCategories;
        }

        public static List<Organizers> GetOrganizers()
        {
            _webClient = new WebClient();
            _stream = _webClient.OpenRead(UrlToOrganizers);
            _sr = new StreamReader(_stream);
            var json = _sr.ReadToEnd();
            _listEventsOrganizers = JsonConvert.DeserializeObject<Organizers[]>(json).ToList();
            return _listEventsOrganizers;
        }

        public static List<CategoriesFromPdf> GetCategoriesFromJson()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                @"JsonPdfCategories.json");
            _sr = new StreamReader(path);
            var json = _sr.ReadToEnd();
            _listCategoriesFromJson = JsonConvert.DeserializeObject<CategoriesFromPdf[]>(json).ToList();
            return _listCategoriesFromJson;
        }
    }
}