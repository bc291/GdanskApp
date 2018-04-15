using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using tristarweather.CategoriesNew;
using tristarweather.Events;

namespace tristarweather
{
    public partial class Page3 : Page
    {
        private readonly List<CategoriesFromPdf> _categoryListFromPdf;
        private string _endDate;
        private EventDetails _eventDetails;
        private List<JsonEvent> _linqlambdaClone;
        private List<TextBox> _listOfLoadingTextboxes;
        public Page3()
        {
            InitializeComponent();
            _listOfLoadingTextboxes = new List<TextBox>(){loadingTextBox, loadingTextBox2, loadingTextBox3, loadingTextBox4, loadingTextBox5};
         //   ToggleControlsVisibility();
            progressBar5.Maximum = 100;
            _categoryListFromPdf = EventsSingleton.GetCategoriesFromJson();


            SetCulture();
            datePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");


            var listatest = EventsSingleton.GetPlaces();

            var citiesList = new SortedSet<string>();
            foreach (var item in listatest)
                if (item != null && item.address.city != null && item.address.city.Length > 2)
                {
                    var temp = item.address.city;
                    temp = temp.Substring(0, 1) + temp.Substring(1).ToLower();
                    citiesList.Add(temp);
                }

            citiesComboBox.Items.Add("Wszystkie");


            foreach (var city in citiesList)
                if (city != null && city.Length > 2)
                    citiesComboBox.Items.Add(city);
            citiesComboBox.Text = tristarweather.Properties.Settings.Default.defaultCity;


            AddHandler(Tile.MouseEnteredEvent,
                new RoutedEventHandler(Window_UserControl_MouseEnteredEventHandlerMethod));

            AddHandler(Tile.MouseLeftEvent,
                new RoutedEventHandler(Window_UserControl_MouseLeftEventHandlerMethod));

            AddHandler(Tile.MouseLeftClkEvent,
                new RoutedEventHandler(Window_UserControl_MouseLeftClkEventHandlerMethod));

            AddHandler(MainWindow.MainWindowGetFocusEvent,
                new RoutedEventHandler(Window_UserControl_GetFocusFromMainWindowEventHandlerMethod));
        }


        private void Window_UserControl_MouseEnteredEventHandlerMethod(object sender,
            RoutedEventArgs e)
        {
            //var CastedShit = e.Source as Tile;
            //var nowyLinq = linqlambdaClone.First(x => CastedShit.TitleOfEvent.ToString().Contains(x.Co));
            //DebuggingTool.Text = nowyLinq.Co;

            //if (eventDetails == null) eventDetails = new EventDetails(nowyLinq);

            //eventDetails.Show();
        }

        private void Window_UserControl_MouseLeftEventHandlerMethod(object sender,
            RoutedEventArgs e)
        {
            //  eventDetails.Hide();
            // eventDetails = null;
        }

        private void Window_UserControl_MouseLeftClkEventHandlerMethod(object sender,
            RoutedEventArgs e)
        {
            if (!(e.Source is Tile castedTile)) throw new ArgumentNullException(nameof(castedTile));
            var nowyLinq = _linqlambdaClone.First(x => castedTile.TitleOfEvent.ToString().Contains(x.Co));
            if (_eventDetails == null) _eventDetails = new EventDetails(nowyLinq);
            _eventDetails.Show(); //TODO crash jak alt-f4 i potem ten sam tile
        }


        public async Task<List<Categories>> GetCategoriesTask()
        {
            var myTask = Task.Run(() => GetCategoriesWorker());
            var result = await myTask;
            return result;
        }

        public List<Categories> GetCategoriesWorker()
        {
            var listatest = EventsSingleton.GetCategories();
            return listatest;
        }

        public async Task<EventsInstance[]> GetDetailedDataTask()
        {
            var myTask = Task.Run(() => GetDetailedWorker());
            var result = await myTask;
            return result;
        }

        public EventsInstance[] GetDetailedWorker()
        {
            var listatest = EventsSingleton.GetDetailedData(_endDate);
            //"&end_date="

            return listatest;
        }

        public async Task<List<Places>> GetPlacesTask()
        {
            var myTask = Task.Run(() => GetPlacesWorker());
            var result = await myTask;
            return result;
        }

        public List<Places> GetPlacesWorker()
        {
            var listatest = EventsSingleton.GetPlaces();

            return listatest;
        }

        public async Task<List<Organizers>> GetOrganizersTask()
        {
            var myTask = Task.Run(() => GetOrganizersWorker());
            var result = await myTask;
            return result;
        }

        public List<Organizers> GetOrganizersWorker()
        {
            var listatest = EventsSingleton.GetOrganizers();

            return listatest;
        }

        public async Task<List<Events.Events>> GetEventsTask()
        {
            var myTask = Task.Run(() => GetEventsWorker());
            var result = await myTask;
            return result;
        }

        public List<Events.Events> GetEventsWorker()
        {
            var listatest = EventsSingleton.GetEvents();

            return listatest;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleControlsVisibility();
            ShowHideMenu("ShowMenu", pnlBottomMenu);
            _endDate = datePicker2.Text;
            ClearData();
           

            var brush = new SolidColorBrush(Color.FromArgb(255, 184, 162, 162));

            foreach (var textBox in _listOfLoadingTextboxes)
            {
                textBox.Background = brush;
            }

            progressBar5.Visibility = Visibility.Visible;
            CollectingData();
        }

        private void ToggleControlsVisibility()
        {
            if (synchronizeButton.IsEnabled)
            {
                citiesComboBox.IsHitTestVisible = false;
                synchronizeButton.IsEnabled = false;
                datePicker2.IsEnabled = false;
            }
            else
            {
                citiesComboBox.IsHitTestVisible = true;
                synchronizeButton.IsEnabled = true;
                datePicker2.IsEnabled = true;
            }          
        }

        private async Task<List<Places>> GetPlaces()
        {
            var sw = new Stopwatch();
            sw.Start();
            var list5 = await GetPlacesTask();
            sw.Stop();
            loadingTextBox3.Text = "\"Miejsca\" w: "+ Math.Truncate(sw.Elapsed.TotalMilliseconds*1000)/1000+" ms";
            loadingTextBox3.Background = Brushes.Green;
            return list5;
        }

        private async Task<List<Categories>> GetCategories()
        {
            var sw = new Stopwatch();
            sw.Start();
            var list5 = await GetCategoriesTask();
            sw.Stop();
            loadingTextBox2.Text = "\"Kategorie\" w: " + Math.Truncate(sw.Elapsed.TotalMilliseconds * 1000) / 1000 + " ms";
            loadingTextBox2.Background = Brushes.Green;
            return list5;
        }

        private async Task<EventsInstance[]> GetDetailedData()
        {
            var sw = new Stopwatch();
            sw.Start();
            var list5 = await GetDetailedDataTask();
            sw.Stop();
            loadingTextBox.Text = "\"Dane szczegółowe\" w: " + Math.Truncate(sw.Elapsed.TotalMilliseconds * 1000) / 1000 + " ms";
            loadingTextBox.Background = Brushes.Green;
            return list5;
        }

        private async Task<List<Organizers>> GetOrganizers()
        {
            var sw = new Stopwatch();
            sw.Start();
            var list5 = await GetOrganizersTask();

            sw.Stop();
            loadingTextBox4.Text = "\"Organizatorzy\" w: " + Math.Truncate(sw.Elapsed.TotalMilliseconds * 1000) / 1000 + " ms";
            loadingTextBox4.Background = Brushes.Green;
            return list5;
        }

        private async Task<List<Events.Events>> GetEvents()
        {
            var sw = new Stopwatch();
            sw.Start();
            var list5 = await GetEventsTask();

            sw.Stop();
            loadingTextBox5.Text = "\"Wydarzenia\" w: " + Math.Truncate(sw.Elapsed.TotalMilliseconds * 1000) / 1000 + " ms";
            loadingTextBox5.Background = Brushes.Green;
            return list5;
        }

        private async void CollectingData()
        {
            LoadingCircle.Visibility = Visibility.Visible;
            var detailedDataList2 = GetDetailedData();
            await Task.WhenAll(detailedDataList2);
            var detailedDataList = await detailedDataList2;

            SetProgressBarValue(value: 20);

            var categoriesList2 = GetCategories();
            await Task.WhenAll(detailedDataList2);
            var categoriesList = await categoriesList2;
            SetProgressBarValue(value: 40);
            var eventsList2 = GetEvents();
            await Task.WhenAll(eventsList2);
            var eventsList = await eventsList2;
            SetProgressBarValue(value: 60);
            var organizersList2 = GetOrganizers();
            await Task.WhenAll(organizersList2);
            var organizersList = await organizersList2;
            SetProgressBarValue(value: 70);
            var placesList2 = GetPlaces();
            await Task.WhenAll(placesList2);
            var placesList = await placesList2;
            SetProgressBarValue(value: 100);
            progressBar5.Visibility = Visibility.Collapsed; //collapsed

            ShowHideMenu("HideMenu", pnlBottomMenu);
            SetTileData(detailedDataList, placesList);
            LoadingCircle.Visibility = Visibility.Collapsed; //collapsed
        }

        //TODO ten sbhide nie moj
        public void SetTileData(EventsInstance[] detailedDataList, List<Places> placesList)
        {
            DeleteUnusedTiles();
            var listDetailedData = detailedDataList.ToList();
            string city = default(string);
            if (citiesComboBox.Text != "") city = citiesComboBox.Text;


            var linqlambda= JoinListByPlaceId(listDetailedData, placesList);

            if (city != null && !city.Equals("Wszystkie"))
                linqlambda = linqlambda.Where(x => x.Miasto != null && x.Miasto.Equals(city)).Select(x => x).ToList();
            //linqlambda.Where(x => x.Miasto?.Equals("Gdańsk") == true).Select(x => x).ToList();
            ToggleControlsVisibility();
            _linqlambdaClone = linqlambda;
            var howManyTiles = tristarweather.Properties.Settings.Default.numberOfTiles;
            var howManyIterations = howManyTiles;
            if (howManyTiles > linqlambda.Count) howManyIterations = linqlambda.Count;

            var listOfTiles = new List<Tile>();

            var numberOfTiles = 0;

            if (howManyIterations == 0)
            {
                noDataLabel.Visibility = Visibility.Visible;
                noDataLabel.Content = "Brak wydarzeń w mieście: " + city + ", dnia: " +
                                      datePicker2.DisplayDate.Date.ToString("dd.MM.yyyy");
                noDataImage.Visibility = Visibility.Visible;
            }
            else
            {
                noDataLabel.Visibility = Visibility.Collapsed;
                noDataImage.Visibility = Visibility.Collapsed;
            }

            AddTiles(numberOfTiles, howManyIterations, listOfTiles);
            AddContentToTiles(howManyIterations, listOfTiles, linqlambda);
        }


        private List<JsonEvent> JoinListByPlaceId(List<EventsInstance> listDetailedData, List<Places> placesList)
        {
            return listDetailedData.Join(placesList, a => a.place.id, b => b.id, (a, b) =>
                new JsonEvent
                {
                    Czas = a.startDate.Date.ToString("yyyy-MM-dd"),
                    Co = a.name,
                    Miasto = b.address.city,
                    Miejsce = a.organizer.designation,
                    Kategoria = a.categoryId,
                    Godzina = a.startDate.TimeOfDay.ToString(),
                    Zalaczniki = a.attachments,
                    Cena = a.tickets,
                    Link = a.urls,
                    Adres = b.address,
                    Id = a.id,
                    OpisDlugi = a.descLong, //to sie da w jednej liscie wszystko
                    IdKategorii = a.categoryId,
                    NazwaObiektu = a.place.subname
                }).ToList();
        }

        private void DeleteUnusedTiles()
        {
            for (var i = 0; i < MainGrid.Children.Count; i++)
                if (MainGrid.Children[i] is Tile tile)
                {
                    MainGrid.Children.Remove(tile);
                    i--;
                }
        }

        private void AddContentToTiles(int howManyIterations, List<Tile> listOfTiles, List<JsonEvent> linqlambda)
        {
            for (var i = 0; i < howManyIterations; i++)
            {
                listOfTiles[i].CategoryOfEvent.Text = _categoryListFromPdf
                    .Where(x => x.root_id == linqlambda[i].Kategoria).Select(x => x.category).First();
                if (string.Equals(linqlambda[i].Godzina, "00:00:00"))
                    listOfTiles[i].HourOfEvent.Text = "Cały dzień";
                else listOfTiles[i].HourOfEvent.Text = linqlambda[i].Godzina;
                listOfTiles[i].PlaceOfEvent.Text = linqlambda[i].Miejsce;
                listOfTiles[i].TitleOfEvent.Text = linqlambda[i].Co;
                listOfTiles[i].DateOfEvent.Text = linqlambda[i].Czas;
                if (linqlambda[i].Cena != null && string.Equals(linqlambda[i].Cena.type, "tickets"))
                {
                    listOfTiles[i].PriceOfEvent.Text = linqlambda[i].Cena.startTicket + " zł";
                    listOfTiles[i].TicketIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    listOfTiles[i].PriceOfEvent.Text = "";
                }

                if (linqlambda[i].Zalaczniki.Count != 0)
                {
                    var fullFilePath = linqlambda[i].Zalaczniki[0].ToString();
                    var testMatch = "";
                    if (!fullFilePath.Contains("http") && fullFilePath.Contains("events"))
                    {
                        testMatch = "http://planer.info.pl/image/event/" + linqlambda[i].Id +
                                    "/cutcorner"; //ten warunek "event" do poprawienia
                    }
                    else
                    {
                        var ms = Regex.Matches(fullFilePath, @"(www.+|http.+)([\s]|$)");
                        if (ms[0].Value.Contains('\"')) testMatch = ms[0].Value.Replace('\"', ' ');
                    }

                    var bpi = new BitmapImage(new Uri(testMatch));
                    listOfTiles[i].image1.Source = bpi;
                }
            }
        }

        private void AddTiles(int numberOfTiles, int howManyIterations, List<Tile> listOfTiles)
        {
            for (var i = 1; i < 4; i += 2)
            for (var j = 0; j < 3; j++)
            {
                if (numberOfTiles == howManyIterations) break;
                var eventTile = new Tile();

                MainGrid.Children.Add(eventTile);
                Grid.SetRow(eventTile, i);
                Grid.SetColumn(eventTile, j);
                listOfTiles.Add(eventTile);
                numberOfTiles++;
            }
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_eventDetails == null) return;
            _eventDetails.Hide();
            _eventDetails = null;
        }

        private void Window_UserControl_GetFocusFromMainWindowEventHandlerMethod(object sender,
            RoutedEventArgs e)
        {
            if (_eventDetails == null) return;
            _eventDetails.Hide();
            _eventDetails = null;
        }

        //TODO REMAINDER There is an event to getFocus in mainpage

        private void ShowHideMenu(string storyboard, StackPanel pnl)
        {
            var sb = Resources[storyboard] as Storyboard;
            sb.Begin(pnl);
        }

        private void ClearData()
        {
            progressBar5.Value = 0;
            foreach (var textBox in _listOfLoadingTextboxes) textBox.Text = "";
        }

        private void SetProgressBarValue(int value)
        {
            progressBar5.Value = value;
        }

        private void SetCulture()
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
    }
}