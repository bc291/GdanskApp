using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using tristarweather.Annotations;

namespace tristarweather
{
    public class TileItem
    {
        private string _hour;
        private string _title;
        private string _where;
        private string _category;

        public string Category
        {
            get => _category;
            set
            {
                if (value == _category) return;
                _category = value;
                OnPropertyChanged();
            }
        }

        public string Hour
        {
            get => _hour;
            set
            {
                if (value == _hour) return;
                _hour = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Where
        {
            get => _where;
            set
            {
                if (value == _where) return;
                _where = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
