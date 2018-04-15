using System;
using System.Collections.Generic;

namespace tristarweather
{
    public class Place
    {
        public int id { get; set; }
        public string subname { get; set; }
        public string name { get; set; }
    }

    public class Urls
    {
        public string www { get; set; }
        public string fb { get; set; }
        public string tickets { get; set; }
    }

    public class Organizer
    {
        public int id { get; set; }
        public string designation { get; set; }
    }

    public class Tickets
    {
        public string type { get; set; }
        public string startTicket { get; set; }
        public string endTicket { get; set; }
    }

    public class EventsInstance
    {
        public int id { get; set; }
        public Place place { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        public Urls urls { get; set; }
        public List<object> attachments { get; set; }
        public string descLong { get; set; }
        public int categoryId { get; set; }
        public DateTime startDate { get; set; }
        public Organizer organizer { get; set; }
        public int active { get; set; }
        public Tickets tickets { get; set; }
        public string descShort { get; set; }
    }
}