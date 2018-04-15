using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace tristarweather.Pages
{
    public partial class Page2 : Page
    {
        private List<WeatherListPrint> _readyList;
        private int _numberOfThreeHoursIntervals;
        private readonly List<WeatherData> _listWeatherData;
        private readonly int _addDay;

        public Page2()
        {
            InitializeComponent();
            var weatherInstance = WeatherSingleton.GetDetailedData();
            _listWeatherData = weatherInstance.list;

            for (var i = 0; i < _listWeatherData.Count; i += _listWeatherData.Count / 3)
                listOfDays.Items.Add(++_addDay); //take care of test.Count/3 instead of 8 

            var weatherParametersEnumerator = Enum.GetNames(typeof(TypesOfDataEnum.WeatherParameters)).GetEnumerator();

            weatherParametersEnumerator.MoveNext();
            while (weatherParametersEnumerator.MoveNext()) parametersToPlot.Items.Add(weatherParametersEnumerator.Current);

            plotbutton.ToolTip = "Stworzenie wykresu wymaga wcześniejszego pobrania danych.";

            Style style = null;
            if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Jasny")) { style = (Style)Application.Current.Resources["ButtonLight"]; }
            else if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Ciemny")) { style = (Style)Application.Current.Resources["ButtonDark"]; }
            plotbutton.Style = style;
            GetDataButton.Style = style;
        }

        private static double FahrenheitToCelsius(double temp)
        {
            return Math.Truncate((-273.15 + temp) * 100) / 100;
        }

        private void PrintResult()
        {
            _readyList = new List<WeatherListPrint>();

            _numberOfThreeHoursIntervals = int.Parse(listOfDays.Text) * 8;
            if (_numberOfThreeHoursIntervals > _listWeatherData.Count) _numberOfThreeHoursIntervals = _listWeatherData.Count;

            for (var i = 0; i < _numberOfThreeHoursIntervals - 1; i++)
                _readyList.Add(new WeatherListPrint
                {
                    DateAndTime = _listWeatherData[i].dt_txt,
                    TemperatureInCelsius = FahrenheitToCelsius(_listWeatherData[i].main.temp),
                    Cloudiness = _listWeatherData[i].clouds.all,
                    Humidity = _listWeatherData[i].main.humidity,
                    PressureGroundLevel = _listWeatherData[i].main.grnd_level,
                    TempMax = FahrenheitToCelsius(_listWeatherData[i].main.temp_max),
                    TempMin = FahrenheitToCelsius(_listWeatherData[i].main.temp_min),
                    WindDir = _listWeatherData[i].wind.deg,
                    WindSpeed = _listWeatherData[i].wind.speed
                });

            weatherDataGrid.ItemsSource = _readyList;
        }

        private void Path_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            PrintResult();
            plotbutton.IsEnabled = true;
            plotbutton.ClearValue(ToolTipProperty);
        }

        private void Plotbutton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var chartwindow = new ChartCityWeather(_readyList, parametersToPlot.Text);
            chartwindow.Show();
        }
    }
}