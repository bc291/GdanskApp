using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tristarweather.Events;

namespace tristarweather.CategoriesNew
{
    public class JsonEvent
    {
        public string Czas { set; get; }
        public string Co { set; get; }
        public string Miasto { set; get; }
        public string Miejsce { set; get; }
        public int Kategoria { set; get; }
        public string Godzina { set; get; }
        public List<object> Zalaczniki { set; get; }
        public Tickets Cena { set; get; }
        public string OpisDlugi { set; get; }
        public Urls Link { set; get; }
        public Address Adres { set; get; }
        public int Id { set; get; }
        public int IdKategorii { set; get; }
        public string NazwaObiektu { set; get; }
    }
}
