using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using tristarweather.CategoriesNew;
using tristarweather.CategoriesNew.Events;

namespace tristarweather
{
    public partial class EventDetails : Window
    {
        private Brush[] _brushes;
        private List<CategoryColors> _categoryColorsList = new List<CategoryColors>();
        private readonly List<int> _categoryIdsList = new List<int>() { 1, 19, 51, 35, 83, 61, 69, 77, 96 };
        private readonly List<CategoriesFromPdf> categoryListFromPdf;
        private readonly JsonEvent lista;

        public EventDetails(JsonEvent lista)
        {
            InitializeComponent();
            this.lista = lista;

            var categoryList = new[]
            {
                "kino", "teatr", "sztuka", "muzyka", "nauka", "literatura", "rozrywka", "rekreacja", "inne"
            };

            _brushes = new Brush[categoryList.Length];
            for (var i = 0; i < categoryList.Length; i++) _brushes[i] = ConvertBrushFromString((string)Properties.Settings.Default[categoryList[i]]);

            FillList();
            categoryListFromPdf = EventsSingleton.GetCategoriesFromJson();

            WhatTextBox.Text = lista.Co;
            TimeTextBox.Text = lista.Czas; 
            HourTextBox.Text = string.Equals(lista.Godzina, "00:00:00") ? "Cały dzień" : lista.Godzina;
            //TODO this hour shoulda be converted a bit sooner 
            CreateLinkFromUri(facebookTextBox, lista.Link.fb);

            var sb = new StringBuilder();
            sb.AppendLine().Append(lista.NazwaObiektu).AppendLine().AppendLine().Append(lista.Miejsce).AppendLine()
                .AppendLine().Append(lista.Adres.street).AppendLine().Append(lista.Miasto);

            PlaceName.Text = sb.ToString();
            var htmlContent = FormHtml();
            Browser.NavigateToString(htmlContent);
            SetCategory();

            CreateLinkFromUri(eventSiteTextBox, lista.Link.www);
            //  Type t = typeof(Brushes); //refleksja
            //  System.Windows.Media.Brush brush = (System.Windows.Media.Brush)t.GetProperty("Red").GetValue(null, null); 
            PaintCategoryBackground();
            PaintImageBackground();
            AddImageSource();
        }

        public enum CategoryColor : long
        {
            Maroon = 1, //kino
            Magenta = 19, //teatr
            Peru = 51, //sztuka
            Purple = 35, //muzyka
            SteelBlue = 83, //nauka
            Brown = 61, //literatura
            Pink = 69, //rozrywka
            Orange = 77, //rekreacja
            Gray = 96 //inne
        }

        private void FillList()
        {
            for (var i = 0; i < 9; i++) _categoryColorsList.Add(new CategoryColors(_categoryIdsList[i], _brushes[i]));
        }

        private SolidColorBrush ConvertBrushFromString(string colorAsString)
        {
            return (SolidColorBrush) new BrushConverter().ConvertFromString(
                colorAsString);
        }

        private void CreateLinkFromUri(RichTextBox richTextBox2, string uri)
        {
            if (string.Equals(uri, null)) return;
            richTextBox2.IsDocumentEnabled = true;
            richTextBox2.IsReadOnly = true;
            richTextBox2.Document.Blocks.FirstBlock.Margin = new Thickness(0);
            var para = new Paragraph {Margin = new Thickness(0)};
            richTextBox2.Document.Blocks.Clear();
            var link = new Hyperlink {IsEnabled = true};
            link.Inlines.Add(uri);
            link.NavigateUri = new Uri(uri);
            link.RequestNavigate += (sender, args) => Process.Start(args.Uri.ToString());
            para.Inlines.Add(link);
            richTextBox2.Document.Blocks.Add(para);
            richTextBox2.Visibility = Visibility.Visible;
        }

        private void ButtonMap_Click(object sender, RoutedEventArgs e)
        {
            var eventLocationMap = new EventLocationMap(lista);
            eventLocationMap.Show();
            //TODO check for null localisation
            //TODO that replace - check for null possibilities
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }

        private void PaintCategoryBackground()
        {
            Brush brushes;
            brushes = _categoryColorsList.Where(x => x.Id == lista.IdKategorii).Select(x => x.EventColor).First();
            CategoryRectangle.Fill = brushes;
        }

        private void PaintImageBackground()
        {
            for (var i = 0; i < 2; i++)
            {
                var rectangle1 = new Rectangle
                {
                    Fill = Brushes.Black,
                    Opacity = 0.1
                };
                Grid.SetColumn(rectangle1, i + 2);
                Grid.SetRow(rectangle1, 0);
                MainGrid.Children.Add(rectangle1);
            }
        }

        private void AddImageSource()
        {
            if (lista.Zalaczniki.Count != 0)
            {
                var fullFilePath = lista.Zalaczniki[0].ToString();
                var testMatch = "";
                if (!fullFilePath.Contains("http") && fullFilePath.Contains("events"))
                {
                    testMatch = "http://planer.info.pl/image/event/" + lista.Id +
                                "/cutcorner"; //ten warunek "event" do poprawienia
                }
                else
                {
                    var ms = Regex.Matches(fullFilePath, @"(www.+|http.+)([\s]|$)");
                    if (ms[0].Value.Contains('\"')) testMatch = ms[0].Value.Replace('\"', ' ');
                }

                var bpi = new BitmapImage(new Uri(testMatch));
                image.Source = bpi;
                image.Stretch = Stretch.Uniform;
            }
        }

        private void SetCategory()
        {
            var categoryText = categoryListFromPdf.Where(x => x.root_id == lista.IdKategorii).Select(x => x.category)
                .First();
            CategoryTextBox.Text = categoryText;
        }

        private string FormHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html><html> <head>");
            sb.Append("<meta charset=\"UTF-8\"></head>");
            sb.Append("<font size=\"2\"color=\"black\"></font>");
            sb.Append("<body bgcolor=#E6E6E6>");
            sb.Append("<font face=\"Century Gothic\" size=\"2\">");
            sb.Append(lista.OpisDlugi);
            sb.Append("</body> </html>");

            return sb.ToString();
        }
    }
}