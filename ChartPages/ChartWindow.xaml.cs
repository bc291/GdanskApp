using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using tristarweather.Intefaces;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace tristarweather
{
    public partial class ChartWindow : ISaveable, IChart
    {
        private readonly int _isGraphInitialized;
        private double[] _listFilledWithActualMeasurremets;
        private readonly string _measurrementUn;
        private readonly List<Details> _singleListAfterUnJagging;


        public ChartWindow(List<Details> test, string testMesauMeasurrementUn)
        {
            _measurrementUn = testMesauMeasurrementUn;

            _singleListAfterUnJagging = test;
            if (_isGraphInitialized == 0) ChartSetup();
            _isGraphInitialized++;
            ChartUpdate();
            InitializeComponent();

            Style style = null;
            if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Jasny")){ style = (Style)Application.Current.Resources["ButtonLight"];}
            else if (string.Equals(tristarweather.Properties.Settings.Default.ThemeColor, "Ciemny")) { style = (Style)Application.Current.Resources["ButtonDark"]; }
            Excel.Style = style;
            PreviousPage.Style = style;
            Save.Style = style;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public void ChartSetup()
        {
            SeriesCollection = new SeriesCollection();


            var chartLabelArray = new string[_singleListAfterUnJagging.Count];


            for (var i = 0; i < _singleListAfterUnJagging.Count; i++) chartLabelArray[i] = _singleListAfterUnJagging[i].Date;

            var defaultValues = new ChartValues<ObservableValue>();
            for (var i = 0; i < _singleListAfterUnJagging.Count; i++) defaultValues.Add(new ObservableValue(0));

            SeriesCollection.Add(new StackedColumnSeries
            {
                Values = defaultValues,
                StackMode = StackMode.Values
            });

            Labels = chartLabelArray;
            Formatter = value => value + " " + _measurrementUn;
            DataContext = this;
        }


        public void ChartUpdate()
        {
            _listFilledWithActualMeasurremets = new double[_singleListAfterUnJagging.Count];

            for (var i = 0; i < _singleListAfterUnJagging.Count; i++)
                if (_singleListAfterUnJagging[i].meassurement == "brak danych")
                    _listFilledWithActualMeasurremets[i] = 0;
                else
                    _listFilledWithActualMeasurremets[i] =
                        double.Parse(_singleListAfterUnJagging[i].meassurement.Replace('.', ','));

            var temp = 0;

            foreach (var series in SeriesCollection)
            foreach (var observable in series.Values.Cast<ObservableValue>())
            {
                observable.Value = _listFilledWithActualMeasurremets[temp];
                temp++;
            }
        }

        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }


        private void Path_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                FileName = "Image",
                DefaultExt = ".png",
                Filter = "Images (.png)|*.png"
            };

            var result = dlg.ShowDialog();

            if (result == true)
            {
                if (Chart == null || string.IsNullOrEmpty(dlg.FileName)) return;

                var bounds = VisualTreeHelper.GetDescendantBounds(Chart);

                var renderTarget = new RenderTargetBitmap((int) bounds.Width, (int) bounds.Height,
                    96, 96, PixelFormats.Pbgra32);

                var visual = new DrawingVisual();

                using (var context = visual.RenderOpen())
                {
                    var visualBrush = new VisualBrush(Chart);
                    context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
                }

                renderTarget.Render(visual);
                var bitmapEncoder = new PngBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
                using (Stream stm = File.Create(dlg.FileName))
                {
                    bitmapEncoder.Save(stm);
                }
            }
        }

        private void Excel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SaveDataToFile();
        }

      

        public void SaveDataToFile()
        {
            var dlg = new SaveFileDialog
            {
                FileName = "results",
                DefaultExt = ".txt",
                Filter = "Text Files (.txt)|*.txt|Comma separated Values (.csv)|*.csv"
            };

            var result = dlg.ShowDialog();


            if (result == true)
            {
                try
                {
                    using (var sr = new StreamWriter(dlg.FileName))
                    {
                        foreach (var item in _singleListAfterUnJagging)
                            sr.WriteLine(item.Date + ";" + item.meassurement.Replace('.', ','));
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Source);
                }

                var result2 = MessageBox.Show("Do you want to open created file?", "Open confirmation",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result2 == MessageBoxResult.Yes)
                {
                    var openProcess = new Process();
                    openProcess.StartInfo.FileName = Path.GetFullPath(dlg.FileName);
                    openProcess.Start();

                    openProcess.WaitForInputIdle();

                    var p = openProcess.MainWindowHandle;
                    ShowWindow(p, 1);
                    SendKeys.SendWait("%(vu)");
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}