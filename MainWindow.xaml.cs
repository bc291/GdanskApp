using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace tristarweather
{
    public partial class MainWindow : Window
    {
        public static readonly RoutedEvent MainWindowGetFocusEvent =
            EventManager.RegisterRoutedEvent("GetFocusEvent", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(MainWindow));


        readonly List<object> _pageList = new List<object>()
        {
            new Pages.MainFrame(),
            new Pages.Page1(),
            new Pages.Page2(),
            new Page3(),
            new Pages.Page4(),
            new Settings.Settingss()
    };

        private int _pageIndex;
        private Dictionary<string, string> _skinDictionary;
        public MainWindow()
        {
            InitializeComponent();

            frame.Content = _pageList[0];

            SetApplicationSkin(FillSkinDictionary());

            //     ChangeGridBackgroud(GridLowerLeftCorner,
            //    ConvertHexToColor(GetResourceAsString("RedBrush")));

            //Application.Current.Resources["labelPage1Style"] = new SolidColorBrush(Colors.Orange);
            //Style style3453 = new Style { TargetType = typeof(Label) };
            //style3453.Setters.Add(new Setter(ForegroundProperty, new SolidColorBrush(Colors.Orange)));
            //Application.Current.Resources["labelPageTest"] = style3453;
        }

        private Dictionary<string, string> FillSkinDictionary()
        {
            if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Jasny"))
            {
                _skinDictionary = new Dictionary<string, string>()
                {
                    {"MainGridBackgroud", "#FF0068FF"},
                    {"RedBrushProperty", "#FF263241"},
                    {"BlueBrushProperty", "#FF445A64"},
                    {"GridLowerLeftCorner", "#FF263241"},
                    {"GridUpperBar", "#FFFFFFFF"},
                    {"GridLeftCenter", "#FF263238"},
                    {"StyleProperty", "ButtonLight"},
                    {"pageBackground", "#FFFFFFFF"},
                    {"listviewBackground", "#FFFFFFFF"},
                    {"themeDarkFontColor", "#FF000000"},
                    {"contrastColor", "#FF000000"},
                };
            }

            if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Ciemny"))
            {
                _skinDictionary = new Dictionary<string, string>()
                {
                    {"MainGridBackgroud", "#FF191970"},
                    {"RedBrushProperty", "#FF000000"},
                    {"BlueBrushProperty", "#FF263241"},
                    {"GridLowerLeftCorner", "#FF000000"},
                    {"GridUpperBar", "#FF000000"},
                    {"GridLeftCenter", "#FF1C1C1C"},
                    {"StyleProperty", "ButtonDark"},
                    {"pageBackground", "#FF131313"},
                    {"listviewBackground", "#FF131313"},
                    {"themeDarkFontColor", "#FFFFA500"},
                    {"contrastColor", "#FFFFFFFF"},
                };

            }

            return _skinDictionary;
        }


        private void SetApplicationSkin(Dictionary<string, string> dictionary)
        {
            ChangeGridBackgroud(MainGrid, ConvertHexToColor(dictionary["MainGridBackgroud"]));

            ChangeResourceColor("RedBrush", ConvertHexToColor(dictionary["RedBrushProperty"]));
            ChangeResourceColor("BlueBrush", ConvertHexToColor(dictionary["BlueBrushProperty"]));

            ChangeGridBackgroud(GridLowerLeftCorner, ConvertHexToColor(dictionary["GridLowerLeftCorner"]));
            ChangeGridBackgroud(GridUpperBar, ConvertHexToColor(dictionary["GridUpperBar"]));
            ChangeGridBackgroud(GridLeftCenter, ConvertHexToColor(dictionary["GridLeftCenter"]));

            Style style = (Style)Application.Current.Resources[dictionary["StyleProperty"]];
            path.Style = style;
            path2.Style = style;
            path3.Style = style;

            ChangeResourceColor("pageBackground", ConvertHexToColor(dictionary["pageBackground"]));
            ChangeResourceColor("listviewBackground", ConvertHexToColor(dictionary["listviewBackground"]));
            ChangeResourceColor("themeDarkFontColor", ConvertHexToColor(dictionary["themeDarkFontColor"]));
            ChangeResourceColor("contrastColor", ConvertHexToColor(dictionary["contrastColor"]));
        }


        private void ChangeResourceColor(string resourceName, SolidColorBrush solidColorBrush)
        {
            Application.Current.Resources[resourceName] = solidColorBrush;
        }

        private void ChangeGridBackgroud(Grid grid, SolidColorBrush solidColorBrush) =>
            grid.Background = solidColorBrush;

        private void ChangeControlBackgroud(Control control, SolidColorBrush solidColorBrush) =>
            control.Background = solidColorBrush;

        private SolidColorBrush ConvertHexToColor(string color)
        {
            return (SolidColorBrush) new BrushConverter().ConvertFrom(color);
        }

        private string GetResourceAsString(string resourceName)
        {
            return App.Current.Resources[resourceName].ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_pageIndex != 1) frame.Content = _pageList[1] as Pages.Page1;
            PageTitle.Text = "Pomiary opadów";
            _pageIndex = 1;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (_pageIndex != 2) frame.Content = _pageList[2] as Pages.Page2;
            PageTitle.Text = "Prognoza pogody";
            _pageIndex = 2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_pageIndex != 0) frame.Content = _pageList[0] as Pages.MainFrame;
            PageTitle.Text = "Panel główny";
            _pageIndex = 0;
        }

        private void Path_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Czy napewno chcesz wyjść", "Wyjście", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Application.Current.Shutdown();
        }

        private void Path_MouseLeftButtonDown_15(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (tristarweather.Properties.Settings.Default.configChanged)
            {
                _pageList[3] = new Page3();
                tristarweather.Properties.Settings.Default.configChanged = false;
                tristarweather.Properties.Settings.Default.Save();
            }
            if (_pageIndex != 3) frame.Content = _pageList[3] as Page3;
            PageTitle.Text = "Wydarzenia kulturalne";
            _pageIndex = 3;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (_pageIndex != 4) frame.Content = _pageList[4] as Pages.Page4;
            PageTitle.Text = "O Autorze";
            _pageIndex = 4;
        }



        public event RoutedEventHandler GetFocus
        {
            add => AddHandler(MainWindowGetFocusEvent, value);
            remove => RemoveHandler(MainWindowGetFocusEvent, value);
        }

        private void MainWindowGetsFocus(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MainWindowGetFocusEvent));
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                if (_pageIndex != 5) frame.Content = _pageList[5] as Settings.Settingss;
                PageTitle.Text = "Ustawienia";
                _pageIndex = 5;

        }
    }
}