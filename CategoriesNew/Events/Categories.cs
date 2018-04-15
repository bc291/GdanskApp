using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tristarweather.Events
{
    public class RootCategory
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public RootCategory root_category { get; set; }
    }
}
