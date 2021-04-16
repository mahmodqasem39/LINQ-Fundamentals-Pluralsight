using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Linq //if we change name space here must include that namespace in the program
{
    public static class MyLinQ
    {
        //we use this here to refer to the method directlly in the program not using instances of the class
        public static int Count<T>(this IEnumerable<T> Sequence)
        {
            int res = 0;
            foreach (var item in Sequence)
            {
                res += 1;
            }
            return res;
        }
    }
}
