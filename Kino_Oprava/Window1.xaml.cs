using Newtonsoft.Json;
using SQLite;
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
using System.Windows.Shapes;
using static SQLite.TableMapping;


namespace Kino_Oprava
{
    /// <summary>
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class Window1 : Window
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
        public string FilmID { get; set; }
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {

            if (System.IO.File.Exists("../../db/database.db3"))
            {

            }
            else
            {
                var db = new SQLiteConnection("../../db/database.db3");
                db.CreateTable<Reservations>();
                db.Close();
            }


        }
        public Window1(string FilmID)
        {
            InitializeComponent();


            string json = File.ReadAllText(@"../../filmy.json");

            List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(json);

            int rows = 0;
            int columns = 0;
            string filmName = "";
            string cinemaName = "";
            string date = "";

            foreach (Movie movie in movieList)
            {
                if (movie.Uuid == FilmID)
                {
                    filmName = movie.Name;
                    cinemaName = movie.Cinema.Name;
                    date = movie.Date;
                    rows = movie.Cinema.Rows;
                    columns = movie.Cinema.Columns;
                }
            }
            filmLabel.Content = filmName;
            cinemaLabel.Content = cinemaName;
            cinemaLabel.Foreground = Brushes.White;
            dateLabel.Content = date;
            dateLabel.Foreground = Brushes.White;
            grid.Rows = rows;
            grid.Columns = columns;

            for (int y = 1; y <= rows; y++)
            {
                for (int i = 1; i <= columns; i++)
                {
                    
                    Button button = new Button()
                    {
                        Content = string.Format("{0}", i),

                        Tag = i
                    };

                    if (System.IO.File.Exists("../../db/database.db3"))
                    {
                        SQLiteConnection connection = new SQLiteConnection("../../db/database.db3");

                        List<Reservations> data = connection.Table<Reservations>().ToList();

                        if (data.Exists(item => item.Row == y.ToString() && item.Column == i.ToString() && item.Film == filmName && item.Date == date && item.Cinema == cinemaName))
                        {
                            button.Background = Brushes.Red;

                        }
                        else
                        {
                            button.Background = Brushes.LightGreen;
                        }


                        if (button.Background == Brushes.Red)
                        {

                        }
                        else
                        {
                            button.Click += new RoutedEventHandler(button_Click);
                        }
                        button.Margin = new Thickness(0, 15, 0, 0);
                        this.grid.Children.Add(button);
                        button.Name = "button_" + y + "_" + i;
                    }
                    else
                    {
                        button.Background = Brushes.LightGreen;
                        button.Click += new RoutedEventHandler(button_Click);
                        

                        button.Margin = new Thickness(0, 15, 0, 0);
                        this.grid.Children.Add(button);
                        button.Name = "button_" + y + "_" + i;
                    }


                    
                }
            }
        }
        

        void button_Click(object sender, RoutedEventArgs e)
        {

            string film = filmLabel.Content.ToString();
            string cinema = cinemaLabel.Content.ToString();
            string date = dateLabel.Content.ToString();

            Button button = (Button)sender;
            Window2 window2 = new Window2(button.Name, film, cinema, date);
            window2.Show();






        }
    }
}