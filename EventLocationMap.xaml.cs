using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF;
using tristarweather.CategoriesNew;
using Location = Microsoft.Maps.MapControl.WPF.Location;

namespace tristarweather
{
    public partial class EventLocationMap : Window
    {
        private readonly JsonEvent _lista;
        private const string Key = "HIDDEN_FOR_GIT_PURPOSES";
        private bool _isDetailsShown;

        public EventLocationMap(JsonEvent lista)
        {
            InitializeComponent();
            _lista = lista;
            ShowAndHideElements();

            var longitude = PrepareEventCoordinates(lista.Adres.lng);
            var latitude = PrepareEventCoordinates(lista.Adres.lat);

            FillEventInfo();

            var location = new Location(latitude, longitude);
            var pushpin = AddNewPushpinToMap(location, lista.NazwaObiektu+" - "+ "ulica " + lista.Adres.street+", "+lista.Adres.zipcode+" "+lista.Adres.city, Colors.Blue); //maybe StringBuilder?


            MapLayer.SetPosition(pushpin, location);
            EventMapBing.ZoomLevel = 16;

            ShowRouteHint();
        }

        private async void ShowRouteHint()
        {
            routeHintTextBox.Visibility = Visibility.Visible;
            await Task.Run(() => ShowRouteHintWorker());
            await Task.Run(() => ShowRouteHintWorker());
            await Task.Run(() => ShowRouteHintWorker());
            await Task.Run(() => ShowRouteHintWorker());

        }

        private async Task ShowRouteHintWorker()
        {          
            await Task.Delay(500);
            routeHintTextBox.Dispatcher.Invoke(() => routeHintTextBox.Text = "Aby obliczyć drogę kliknij proszę dwa razy w wybrany punkt, lub podaj swój adres domowy   ->",
                DispatcherPriority.Background);
            await Task.Delay(500);
            routeHintTextBox.Dispatcher.Invoke(() => routeHintTextBox.Text = "Aby obliczyć drogę kliknij proszę dwa razy w wybrany punkt, lub podaj swój adres domowy ->",
                DispatcherPriority.Background);           
        }

        private void GetResponse(Uri uri, Action<Response> callback)
        {
            var wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    var ser = new DataContractJsonSerializer(typeof(Response));
                    callback(ser.ReadObject(a.Result) as Response);
                }
            };
            wc.OpenReadAsync(uri);
        }

        private void EventMapBing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePos = e.GetPosition(this);
            var pinLocal = EventMapBing.ViewportPointToLocation(mousePos);
            FindRoute(pinLocal);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetLocationFromAddres();
        }


        private void FormatRouteDetails(Route route)
        {
            if (route.TravelDistance > 1.0) routeDistanceTextBox.Text = TruncateNumber(route.TravelDistance, 2) + " km";
            else routeDistanceTextBox.Text = route.TravelDistance * 1000 + " m";

            if (route.TravelDuration > 60)
                routeTimeTextBox.Text = (int) route.TravelDuration / 60 + "m " +
                                        TruncateNumber(route.TravelDuration%60, 2) + "s";
            else routeTimeTextBox.Text = route.TravelDuration + " s";

            if (route.TravelDurationTraffic > 60)
                routeTimeTrafficTextBox.Text = (int) route.TravelDurationTraffic / 60 + "m " +
                                               TruncateNumber(route.TravelDurationTraffic%60, 2) + "s";
            else routeTimeTrafficTextBox.Text = route.TravelDurationTraffic + " s";
        }

        private double TruncateNumber(double number, int decimals)
        {
            return Math.Truncate(number*Math.Pow(10, decimals))/Math.Pow(10, decimals);
        }

        private void cityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) Button_Click(this, new RoutedEventArgs());
        }

        private void FindRoute(Location pinLocation)
        {
            ClearPushpin();
            

            var from = PrepareEventCoordinates();

            var to = pinLocation.Latitude + "," + pinLocation.Longitude;
            var geocodeRequest = PrepareRouteQuery(from, to);

            GetResponse(geocodeRequest, x =>
            {
                ClearPolylines();
                var route = x.ResourceSets[0].Resources[0] as Route;

                var routePath = route.RoutePath.Line.Coordinates;
                var locs = new LocationCollection();

                for (var i = 0; i < routePath.Length; i++)
                    if (routePath[i].Length >= 2)
                        locs.Add(new Location(routePath[i][0], routePath[i][1]));

                var routeLine = new MapPolyline
                {
                    Locations = locs,
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 5
                };

                EventMapBing.Children.Add(routeLine);
                FormatRouteDetails(route);
                PrepareRouteInstructions(route);
            });

            var geocodeRequest2 =
                new Uri(string.Format("https://dev.virtualearth.net/REST/v1/Locations/{0},{1}?key={2}",
                    pinLocation.Latitude.ToString().Replace(',', '.'),
                    pinLocation.Longitude.ToString().Replace(',', '.'), Key));

            GetResponse(geocodeRequest2, x =>
            {
                var etestes = x.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                actualAddressTextBox.Text = etestes.Address.FormattedAddress;
                   if (!_isDetailsShown)
            {
                ShowAndHideElements();
                _isDetailsShown = true;
            }

                AddNewPushpinToMap(pinLocation,"Punkt docelowy: "+ etestes.Address.FormattedAddress, Colors.Blue);
            });

         
        }

        private void GetLocationFromAddres()
        {
            var typedAddress = streetTextBox.Text;
            var typedCity = cityTextBox.Text;
            var query = typedAddress + "," + typedCity + ",PL";
            var geocodeRequest =
                new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", query, Key));

            GetResponse(geocodeRequest, x =>
            {
                var etestes = x.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                actualAddressTextBox.Text = etestes.Address.AddressLine;


                var location = new Location
                {
                    Latitude = etestes.Point.Coordinates[0],
                    Longitude = etestes.Point.Coordinates[1]
                };
                FindRoute(location);
            });
        }

        private void ClearPushpin()
        {
            var variableUsedForSecondPinDelete = 0;
            for (var i = 0; i < EventMapBing.Children.Count; i++)
                if (EventMapBing.Children[i] is Pushpin)
                {
                    if (variableUsedForSecondPinDelete == 1) EventMapBing.Children.Remove(EventMapBing.Children[i]);
                    variableUsedForSecondPinDelete++;
                }
        }

        private void ClearPolylines()
        {
            for (var i = 0; i < EventMapBing.Children.Count; i++)
                if (EventMapBing.Children[i] is MapPolyline)
                    EventMapBing.Children.Remove(EventMapBing.Children[i]);
        }

        private string PrepareEventCoordinates()
        {
            return _lista.Adres.lat + "," + _lista.Adres.lng;
        }

        private void PrepareRouteInstructions(Route route)
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var routeLeg in route.RouteLegs)
            foreach (var itineraryItem in routeLeg.ItineraryItems)
            {
                sb.Append(++counter+". ");
                sb.AppendLine(itineraryItem.Instruction.Text);
                }
          
            directoryInstructionsTextBox.Text = sb.ToString();
        }

        private Uri PrepareRouteQuery(string from, string to)
        {
            var query =
                string.Format(
                    "https://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0={0}&wp.1={1}&optmz=distance&routeAttributes=routePath&key={2}",
                    from, to, Key);
            return new Uri(query);
        }

        private Pushpin AddNewPushpinToMap(Location pinLocation, string toolTip, Color PushpinColor)
        {
            var pushpin = new Pushpin {Name = "Place"};

            ToolTipService.SetToolTip(pushpin, toolTip);
            pushpin.Background = new SolidColorBrush(PushpinColor);
            pushpin.Location = pinLocation;
            EventMapBing.Center = pinLocation;


            var numberOfPushpins = 1;
            foreach (var children in EventMapBing.Children)
                if (children is Pushpin)
                    numberOfPushpins++;

            EventMapBing.Children.Add(pushpin);
            return pushpin;
        }

        private void FillEventInfo()
        {
            var sb = new StringBuilder();
            sb.Append("Obiekt: ");
            if (_lista.NazwaObiektu != null) sb.Append(_lista.NazwaObiektu).AppendLine();
          //  if (lista.Adres.street != null) sb.Append(lista.Adres.street).AppendLine();
           // if (lista.Adres.city != null) sb.Append(lista.Adres.city);
          //  if (lista.Adres.zipcode != null) sb.Append(" ").Append(lista.Adres.zipcode);
            eventInfoTextBox.Text = sb.ToString();
        }

        private double PrepareEventCoordinates(string coordinateAsText)
        {
            double coordinateAsNumber;
            if (coordinateAsText != null) double.TryParse(coordinateAsText.Replace('.', ','), out coordinateAsNumber);
            else coordinateAsNumber = 0.0;
            return coordinateAsNumber;
        }

        private void ShowAndHideElements()
        {
            List<UIElement> uiElementsList = new List<UIElement>()
            {
                actualAddressTextBox, totalTimeLabel, totalTimeTrafficLabel, distanceLabel, routeDistanceTextBox, routeTimeTextBox,
                routeTimeTrafficTextBox, actualAdresLabel, directoryInstructionsTextBox, routeInstructionsLabel
            };

            foreach (var element in uiElementsList)
            {
                ShowAndHideElementsWorker(element);
            }
        }

        private void ShowAndHideElementsWorker(UIElement uiObject)
        {
            uiObject.Visibility = uiObject.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}