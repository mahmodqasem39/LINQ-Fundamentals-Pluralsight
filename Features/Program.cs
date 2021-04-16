using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; // we cant use two methods extentions with the same name in the program so we comment the
//using Features.Linq; //couston lnq that we make to hide Count Method inside it 

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers  = new List<Employee>
            {
                new Employee { ID = 1, Name = "Ahmed" },
                new Employee { ID = 2, Name = "Mahmoud" }  
            };

            IEnumerable<Employee> sales = new Employee[]
            {
                new Employee {ID=1,Name="Khaled" },
                new Employee { ID=2 , Name="Ali"}
            };


            #region using of enumerator & foreach
            //IEnumerator<Employee> enumerator = sales.GetEnumerator();//walk throw for each item in list or array or .....
            //while (enumerator.MoveNext()) //fetch next record of any structure(array , list , collection , pointer of tree) 
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            //foreach (var item in developers)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region using of Linq $ Coustom Linq

            //Console.WriteLine(developers.Count());

            //string text = "54.6";
            //Console.WriteLine($"{text.ToDoubble()} type : {text.GetTypeCode()}");
            #endregion

            #region using of lambda expression

            ////using metohd refer to logic i need
            //foreach (var item in sales.Where(startsWithK))
            //{
            //    Console.WriteLine(item.Name);
            //}

            ////using Delegates but it's hard syentax
            //foreach (var item in sales.Where
            //    (delegate (Employee arg)
            //{
            //    return arg.Name.StartsWith("K");
            //})) 
            //{
            //    Console.WriteLine(item.Name);
            //};

            ////using Lambda exprresion
            //foreach (var item in sales.Where(e => e.Name.StartsWith("K")))
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion

            #region Func & Action
            //Func<int, int> test = testSquare; // func but not using lambda is using call method
            //Func<int, int> square = x => x * x; // take 1 param int and return int
            //Func<int, int, int> add = (x, y) => x + y; //take 2 params and return int
            //Func<int, int, int, int> add3 = (x, y, z) => // anther synatx
            //{
            //    var temp = x;
            //    temp = x + y + z;
            //    return temp;
            //};
            //Action<int> write = x => Console.WriteLine(x); // take 1 param and return void

            //write(square(add(2, 3) + add3(1, 2, 3))); //call write  => 121

            ////here we use Func method in order by extMethod and where extMtheod
            //foreach (var item in developers.Where(e => e.Name.Length == 5)
            //                               .OrderBy(e => e.Name))     
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region query syntax VS method syntax

            //method syntax
            var query = developers.Where(d => d.Name.Length == 5)
                .OrderByDescending(d => d.Name)
                .Select(d => d);//.Count();

            //query syntax
            var query2 = from devloper in developers
                         where devloper.Name.Length == 5
                         orderby devloper.Name descending
                         select devloper;
            //query2.Count();

            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }

            #endregion

        }

        private static int testSquare(int arg)
        {
            return arg * arg;
        }

        private static bool startsWithK(Employee arg)
        {
            return arg.Name.StartsWith("K");
        }


    }
}
