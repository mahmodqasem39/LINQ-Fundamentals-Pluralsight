using System;
using System.Collections.Generic;
using System.Linq;

namespace Queires
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight" , Rate = 8.9f , Year = 2008 },
                new Movie { Title = "The King's Sppech" , Rate = 8.0f , Year = 2010 },
                new Movie { Title = "Casblanca" , Rate = 8.5f , Year = 1942 },
                new Movie { Title = "Star Wars V" , Rate = 8.7f , Year = 1980 }
            };

            var query = movies.Filter(m => m.Year > 2000);
            query = query.Take(1);

            var enamurater = query.GetEnumerator();
            while (enamurater.MoveNext())
            {
                Console.WriteLine(enamurater.Current.Title);
            }

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Title);
            //}
        }
    }
}
