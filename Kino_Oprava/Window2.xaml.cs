using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kino_Oprava
{
    /// <summary>
    /// Interakční logika pro Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string ButtonAttributes { get; set; }
        public string FilmName { get; set; }
        public string CinemaName { get; set; }
        public string Date { get; set; }

        public Window2(string ButtonAttributes, string FilmName, string CinemaName, string Date)
        {
            InitializeComponent();

            string[] pozice = ButtonAttributes.Split('_');

            filmLabel.Content = FilmName;
            cinemaLabel.Content = CinemaName;
            dateLabel.Content = Date;
            columnLabel.Content = pozice[1];
            rowLabel.Content = pozice[2];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = t2.Text.Trim();
            string name = t1.Text.Trim();

            
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string namePattern = @"^[A-Za-z]+(?: [A-Za-z]+(?=.*\s))?(?: [A-Za-z]+)?$";

            bool isValidEmail = Regex.IsMatch(email, emailPattern);

            bool isValidName = Regex.IsMatch(name, namePattern);
            
            
            
            if (!isValidEmail)
            {

            }
            else if (!isValidName)
            {

            }
            else
            {
                string column = columnLabel.Content.ToString();
                string row = rowLabel.Content.ToString();
                string film = filmLabel.Content.ToString();
                string cinema = cinemaLabel.Content.ToString();
                string date = dateLabel.Content.ToString();


                Reservations insert = new Reservations(t1.Text, t2.Text, row, column, film, cinema, date);
                var db = new SQLiteConnection(@"../../db/database.db3");
                db.Insert(insert);
                db.Close();


                MessageBox.Show("Vaše data byla uložena ;)");
                Application.Current.Shutdown();
            }
            
                
            
        }
    }
}
