using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tristarweather.CategoriesNew.Events
{
    class CategoryColors
    {
        public int Id { set; get; }
        public System.Windows.Media.Brush EventColor { set; get; }

        public CategoryColors(int id, System.Windows.Media.Brush eventColor)
        {
            this.Id = id;
            this.EventColor = eventColor;
        }
    }
}
