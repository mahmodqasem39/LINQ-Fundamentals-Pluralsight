using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class ExtentionString
    {
        public static double ToDoubble(this string data)
        {
            double result = double.Parse(data);
            return result;
        }

    }
}
