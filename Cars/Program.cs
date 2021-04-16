using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = processFiles("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            #region Query synatx for filter by fuel effiecent car

            var qury2 = from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined descending, car.Name ascending
                        select new 
                        // anonymaous object we use it so select spacifiec ojects that we need instaed of
                        //select all objects refrences //high pefromance
                        {
                            car.Manufacturer,
                            car.Name,
                            car.Combined
                        };


            Console.WriteLine("Query Syntax");
            foreach (var item in qury2.Take(10))
            {
                Console.WriteLine($" {item.Manufacturer} {item.Name} : {item.Combined}");
            }
            #endregion

            Console.WriteLine("********************************************************");

            #region Method synatx for filter by fuel effiecent car

            var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                         .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name)
                        .Select(c => new { c.Manufacturer , c.Name , c.Combined });// anonymaous object & secondey sort
            //FirstOrDefault(c => c.Manufacturer == "Baa" && c.Year == 2016); //we can also use last

            #region some filters
            var result = cars.Any(c => c.Manufacturer == "Ford"); // check if any if of Manufacturer return bool
            var result2 = cars.All(c => c.Manufacturer == "Ford"); //check of all Manufacturer == ford and return bool
            //var result3 = cars.Contains(); check if obj of car is exsist

            var result4 = cars.Select(c => c.Name ); //select all string from cars
            var result5 = cars.SelectMany(c => c.Name).OrderBy(c => c); //select all letters from string in cars

            foreach (var item in result5)
            {
                //Console.WriteLine(item);
            }
           
            #endregion


            Console.WriteLine("Method Syntax");

            //select top one mathch the expression
            //if(query != null)
            //{
            //    Console.WriteLine(query.Name);
            //}

            foreach (var item in query.Take(10))
            {
                Console.WriteLine($"{item.Manufacturer} {item.Name} : {item.Combined}");
            }

            #endregion
        }

        private static List<Car> processFiles(string path)
        {

            #region QuerySyntax
            //var query = from line in File.ReadAllLines(path).Skip(1)
            //            where line.Length > 1
            //            select Car.CarsFromCsv(line);
            //return query.ToList();
            #endregion
            return File.ReadAllLines(path).Skip(1) // to skip first line
                .Where(line => line.Length > 1)
                .ToCar().ToList();  
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }

    public static class CarExtenstions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var coloumns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(coloumns[0]),
                    Manufacturer = coloumns[1],
                    Name = coloumns[2],
                    Displacement = double.Parse(coloumns[3]),
                    Cylinders = int.Parse(coloumns[4]),
                    City = int.Parse(coloumns[5]),
                    Highway = int.Parse(coloumns[6]),
                    Combined = int.Parse(coloumns[7])
                };
            }
        }

    }
}
