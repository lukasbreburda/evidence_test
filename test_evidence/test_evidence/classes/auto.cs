using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_evidence.classes
{
    public class auto
{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string znacka { get; set; }
        public string model { get; set; }
        public int objem { get; set; }
        public int vykon { get; set; }
        public int rok_vyroby { get; set; }
        public int stav_kilometru { get; set; }
       

        public auto()
        {
        }

        public override string ToString()
        {
            return znacka + " " + model + " " + "- " + rok_vyroby;
        }
    }
}
