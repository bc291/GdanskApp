using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiveCharts;

namespace tristarweather.Pages
{
    public partial class Page1 : Page
    {
        private const string BasePath = @"http://pomiary.gdmel.pl/rest/measurments/";
        private JsonMain _jsonMain;
        private string _measurrementUnit;
        private List<Details> _singleListAfterUnJagging;

        public Page1()
        {
            InitializeComponent();
            SetCulture();
            ClearAllData();
            UpdateData();
         
            plotbutton.ToolTip = "Stworzenie wykresu wymaga wcześniejszego pobrania danych.";

            Style style = null;
            if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Jasny")) { style = (Style)Application.Current.Resources["ButtonLight"]; }
            else if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Ciemny")) { style = (Style)Application.Current.Resources["ButtonDark"]; }
            plotbutton.Style = style;
            GetDataButton.Style = style;       
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public void ObtainMainData(JsonMain jsonMain)
        {
            var stationName = listOfStations.Text;
            var measurrementSymbol = typeOfData.Text;
            var pickedDate = datePicker.Text;

            ObtainUnit(measurrementSymbol);

            var stationNumber = jsonMain.data.Where(p => p.name.Equals(stationName)).Select(p => p.no).First();

            var querryLast = BasePath + stationNumber + @"/" +
                             measurrementSymbol + @"/" + pickedDate;

            CollectDetailedData(querryLast);
        }


        public void CollectDetailedData(string url)
        {
            var detailedWeatherData = StationsListSingleton.GetDetailedData(url);
            var jaggedList = detailedWeatherData.data;
            _singleListAfterUnJagging = new List<Details>();

            foreach (var valuesPerTimePeriod in jaggedList)
                if (valuesPerTimePeriod[1] == null)
                    _singleListAfterUnJagging.Add(new Details
                    {
                        Date = valuesPerTimePeriod[0],
                        meassurement = "brak danych"
                    });
                else
                    _singleListAfterUnJagging.Add(new Details
                    {
                        Date = valuesPerTimePeriod[0],
                        meassurement = valuesPerTimePeriod[1]
                    });

            weatherList.ItemsSource = _singleListAfterUnJagging;
        }


        private void ClearAllData()
        {
            typeOfData.Items.Clear();
            listOfStations.Items.Clear();
        }

        private void UpdateData()
        {
            _jsonMain = StationsListSingleton.Instance.GetData();
            foreach (var stations in _jsonMain.data) listOfStations.Items.Add(stations.name);
            listOfStations.Text = _jsonMain.data[0].name; //default         
            foreach (var types in Enum.GetValues(typeof(TypesOfDataEnum.DataTypes))) typeOfData.Items.Add(types);
            typeOfData.Text = TypesOfDataEnum.DataTypes.rain.ToString(); //default
        }

        private void ObtainUnit(string measurrementSymbol)
        {
            var test23123 =
                (TypesOfDataEnum.DataTypes) Enum.Parse(typeof(TypesOfDataEnum.DataTypes), measurrementSymbol, true);

            switch ((long) test23123)
            {
                case (long) TypesOfDataEnum.DataTypes.rain:
                    _measurrementUnit = TypesOfDataEnum.rain;
                    break;

                case (long) TypesOfDataEnum.DataTypes.water:
                    _measurrementUnit = TypesOfDataEnum.water;
                    break;

                case (long) TypesOfDataEnum.DataTypes.winddir:
                    _measurrementUnit = TypesOfDataEnum.winddir;
                    break;

                case (long) TypesOfDataEnum.DataTypes.windlevel:
                    _measurrementUnit = TypesOfDataEnum.windlevel;
                    break;
            }
        }

        private void plotbutton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var chartwindow = new ChartWindow(_singleListAfterUnJagging, _measurrementUnit);
            chartwindow.Show();
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ObtainMainData(_jsonMain);
            plotbutton.IsEnabled = true;
            plotbutton.ClearValue(ToolTipProperty);
        }

        private void SetCulture()
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
    }
}