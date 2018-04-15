using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace tristarweather
{
    public partial class Tile : UserControl
    {
        public static readonly RoutedEvent MouseEnteredEvent =
            EventManager.RegisterRoutedEvent("MouseEnteredEvent", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(Tile));

        public static readonly RoutedEvent MouseLeftEvent =
            EventManager.RegisterRoutedEvent("MouseLeftEvent", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(Tile));

        public static readonly RoutedEvent MouseLeftClkEvent =
            EventManager.RegisterRoutedEvent("MouseLeftClkEvent", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(Tile));

        public Tile()
        {
            InitializeComponent();
        }


        public event RoutedEventHandler MouseEntered
        {
            add => AddHandler(MouseEnteredEvent, value);
            remove => RemoveHandler(MouseEnteredEvent, value);
        }

        public event RoutedEventHandler MouseLeft
        {
            add => AddHandler(MouseLeftEvent, value);
            remove => RemoveHandler(MouseLeftEvent, value);
        }

        public event RoutedEventHandler MouseLeftClick
        {
            add => AddHandler(MouseLeftClkEvent, value);
            remove => RemoveHandler(MouseLeftClkEvent, value);
        }

        private void HourOfEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Grid_MouseEnter(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MouseEnteredEvent));
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MouseLeftEvent));
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // RaiseEvent(new RoutedEventArgs(Tile.MouseLeftClkEvent));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MouseLeftClkEvent));
        }

        //TODO REMAINDER big button as event handler
    }
}