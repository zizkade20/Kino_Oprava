using kino_home;
using SQLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Reservations temp = new Reservations(t1.Text, t2.Text, rowLabel.Content.ToString(), columnLabel.Content.ToString(), filmLabel.Content.ToString(), cinemaLabel.Content.ToString(), dateLabel.Content.ToString());
            var db = new SQLiteConnection("../../db/database.db3");
            db.Insert(temp);
            db.Close();


            MessageBox.Show("Vaše data byla uložena ;)");
            this.Close();
        }
    }
}
