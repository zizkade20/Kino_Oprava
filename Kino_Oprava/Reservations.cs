using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System.Security.RightsManagement;

namespace kino_home
{
    class Reservations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public string Film { get; set; }
        public string Cinema { get; set; }
        public string Date { get; set; }
        public Reservations()
        {

        }
        public Reservations(string c1, string c2, string r, string c, string f, string cinema, string date)
        {
            Name = c1;
            Email = c2;
            Row = r;
            Column = c;
            Film = f;
            Cinema = cinema;
            Date = date;
        }
    }
}
