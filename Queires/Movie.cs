using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queires
{
    class Movie
    {
        public string Title { get; set; }
        public float Rate { get; set; }

        int _year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returring {_year} for {Title}");
                return _year;
            }
            set
            {
                _year = value;
            }
        }
    }
}
