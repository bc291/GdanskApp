using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace tristarweather.Settings
{
    public partial class Settingss : Page
    {
        private readonly List<TextBox> _colorTextBoxes;
        private readonly string[] _settingNames;
        private List<ComboBox> _comboBoxList;
        private string[] _defaultColors;

        public Settingss()
        {
            InitializeComponent();
            var defaultCities = new[] {"Gdańsk", "Gdynia", "Sopot", "Kartuzy", "Wejherowo"};
            foreach (var city in defaultCities) defaultCity.Items.Add(city);

            defaultCity.Text = tristarweather.Properties.Settings.Default.defaultCity;

            _colorTextBoxes = new List<TextBox>();

            foreach (var gridListItem in MainGrid.Children)
                if (gridListItem is TextBox textBox)
                    _colorTextBoxes.Add(textBox); //TODO REMAINDER In case if more textboxes added, change that
            _settingNames = new[]
                {"kino", "teatr", "sztuka", "muzyka", "nauka", "literatura", "rozrywka", "rekreacja", "inne"};
            var textboxIterator = 0;

            foreach (var textbox in _colorTextBoxes)
            {
                var colorObtainedFromString = ObtainColorFromString(Properties.Settings
                    .Default[_settingNames[textboxIterator]].ToString());
                ChangeControlBackground(textbox, colorObtainedFromString);

                textboxIterator++;
            }

            FillColorComboBox();
            PrepareTilesCountComboBox();
            themeComboBox.Text = tristarweather.Properties.Settings.Default.ThemeColor;
        }

        private void PrepareTilesCountComboBox()
        {
            for (var i = 1; i < 7; i++) numberOfTiles.Items.Add(i);
            numberOfTiles.Text = Properties.Settings.Default.numberOfTiles.ToString();
        }


        private void FillColorComboBox()
        {
            _comboBoxList = new List<ComboBox>
            {
                colorCategory,
                colorCategory2,
                colorCategory3,
                colorCategory4,
                colorCategory5,
                colorCategory6,
                colorCategory7,
                colorCategory8,
                colorCategory9
            };

         
            var propertyColorInformation = GetColorsFromReflection();
            var colorList = FillListWithColorsFromReflection(propertyColorInformation);


            foreach (var comboBox in _comboBoxList)
                for (var i = 1; i < colorList.Count; i++) // i=1 to avoid transparent
                {
                    var comboBoxItem = new ComboBoxItem();
                    var colorTakenFromReflectionList = ObtainColorFromString(colorList[i]);
                    ChangeControlBackground(comboBoxItem, colorTakenFromReflectionList);
                    comboBoxItem.Content = colorList[i];
                    //  comboBoxItem.Background = new SolidColorBrush(
                    //    System.Windows.Media.Color.FromArgb(propInfo.A, color.R, color.G, color.B));

                    comboBox.Items.Add(comboBoxItem);
                }

            var comboboxIterator = 0;

            foreach (var combobox in _comboBoxList)
            {
                combobox.Text = Properties.Settings.Default[_settingNames[comboboxIterator]].ToString();
                comboboxIterator++;
            }
        }

        private static List<string> FillListWithColorsFromReflection(PropertyInfo[] propertyInfo)
        {
            var colorList = new List<string>();
            foreach (var propInfo in propertyInfo) colorList.Add(propInfo.Name);
            return colorList;
        }

        private PropertyInfo[] GetColorsFromReflection()
        {
            var colorType = typeof(Color);
            var colorProperties = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            return colorProperties;
        }

        private void ChangeColorPreview(object sender, TextBox textbox, int index)
        {
            if (!colorCategory.IsLoaded)
                return;

            var comboBox = sender as ComboBox;
            var selectedItemAsString = comboBox?.SelectedItem;
            var value = ((ComboBoxItem)selectedItemAsString)?.Content.ToString();
            textbox.Background = ObtainColorFromString(value);
            UpdatePropertyAndSave(index, value);
        }

        private void UpdatePropertyAndSave(int index, string value)
        {
            Properties.Settings.Default[_settingNames[index]] = value;
            Properties.Settings.Default.Save(); //update?
        }

        private void Colors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var casted = sender as ComboBox;

            var tempIterator = 0;
            foreach (var combobox in _comboBoxList)
            {
                if (casted?.Name == combobox.Name)
                    ChangeColorPreview(sender, _colorTextBoxes[tempIterator], tempIterator);          
                tempIterator++;
            }
        }


        private void NumberOfTiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!numberOfTiles.IsLoaded)
                return;
            var comboBox = sender as ComboBox;
            var selectedItemAsString = comboBox?.SelectedItem.ToString();
            Properties.Settings.Default.numberOfTiles = int.Parse(selectedItemAsString);
            Properties.Settings.Default.Save();
        }


        private void SetDefaults()
        {
            _defaultColors = new[]
            {
                "Maroon", "Magenta", "Peru", "Purple", "SteelBlue", "Brown",
                "Pink", "Orange", "Gray"
            };


            var colorIterator = 0;
            SolidColorBrush brush5;
            foreach (var gridItem in MainGrid.Children)
                if (gridItem is TextBox textbox)
                {
                    brush5 = ObtainColorFromString(_defaultColors[colorIterator]);                   
                    Properties.Settings.Default[_settingNames[colorIterator]] = _defaultColors[colorIterator];
                    ChangeControlBackground(textbox, brush5);
                    colorIterator++;
                }

            Properties.Settings.Default.ThemeColor = "Jasny";
            themeComboBox.Text = "Jasny";
            defaultCity.Text = "Gdańsk";
            Properties.Settings.Default.numberOfTiles = 6;
            Properties.Settings.Default.defaultCity = "Gdańsk";
            Properties.Settings.Default.Save();
            numberOfTiles.Text = Properties.Settings.Default.numberOfTiles.ToString();

            var miniIterator = 0;
            foreach (var item in _comboBoxList)
            {
                item.Text = Properties.Settings.Default[_settingNames[miniIterator]].ToString();
                miniIterator++;
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetDefaults();
        }

        private void ChangeControlBackground(Control control, Brush brush)
        {
            control.Background = brush;
        }

        private static SolidColorBrush ObtainColorFromString(string colorString)
        {
           return (SolidColorBrush)new BrushConverter().ConvertFromString(colorString);
        }

        private void themeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!themeComboBox.IsLoaded) return;

            var casted = sender as ComboBox;
            var selectedItem = casted?.SelectedItem;
            var contentOfSelectedItem = ((ComboBoxItem)selectedItem).Content.ToString();
                
            if (contentOfSelectedItem == "Jasny")
            {
                tristarweather.Properties.Settings.Default.ThemeColor = "Jasny";
                MessageBoxResult result = MessageBox.Show("Aplikacja zrestartuje się", "Wymagane ponowne uruchomienie aplikacji", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    tristarweather.Properties.Settings.Default.configChanged = false;
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }

            else if (contentOfSelectedItem == "Ciemny")
            {
                tristarweather.Properties.Settings.Default.ThemeColor = "Ciemny";
                MessageBoxResult result = MessageBox.Show("Aplikacja zrestartuje się", "Wymagane ponowne uruchomienie aplikacji", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    tristarweather.Properties.Settings.Default.configChanged = false;
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            Properties.Settings.Default.Save(); //update?
        }

        private void DefaultCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!themeComboBox.IsLoaded) return;

            var casted = sender as ComboBox;
            var selectedItem = casted?.SelectedItem;           
            tristarweather.Properties.Settings.Default.defaultCity = selectedItem.ToString();
            tristarweather.Properties.Settings.Default.configChanged = true;
            Properties.Settings.Default.Save();
        }
    }
}