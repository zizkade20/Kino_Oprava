using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace Kino_Oprava
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Movie
        {
            public string Uuid { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public Cinema Cinema { get; set; }
        }

        public class Cinema
        {
            public string Name { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            var json = File.ReadAllText(@"../../filmy.json");
            List<Movie> films = JsonConvert.DeserializeObject<List<Movie>>(json);

            MoviesList.ItemsSource = films;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            var uuid = button.Tag as string;

            Window1 window1 = new Window1(uuid);

            window1.Show();
        }
    }
}
