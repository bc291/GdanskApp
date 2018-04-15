using System.Windows.Controls;

namespace tristarweather.Pages
{
    public partial class MainFrame : Page
    {
        public MainFrame()
        {
            InitializeComponent();
            string quote = "\"Gdańsk jest kluczem do wszystkiego.\"\nNapoleon Bonaparte";
            textBox.Text = quote;
        }
    }
}