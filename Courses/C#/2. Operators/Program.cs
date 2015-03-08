using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            double d = 5.1;
            char c = 'A';
            bool b = true;
            long e = 7;
            float[] vector = {1,2,3};
            string s = "text";

            // Relational
            Console.WriteLine(String.Format("a > e : {0}", a > e));
            Console.WriteLine(String.Format("a != d : {0}", a != d));
            Console.WriteLine(String.Format("e == c : {0}", e == c));

            // Conditional
            Console.WriteLine(String.Format("a > 0 && e > 0: {0}", a > 0 && e > 0));
            Console.WriteLine(String.Format("a == e || b : {0}", a == e || b));

            // Primary
            Console.WriteLine(String.Format("sizeof(int) : {0}", sizeof(int)));
            Console.WriteLine(String.Format("sizeof(char) : {0}", sizeof(char)));
            Console.WriteLine(String.Format("vector[1] : {0}", vector[1]));

            // Type inference
            Console.WriteLine(String.Format("s is string : {0}", s is string));
            Console.WriteLine(String.Format("s is object : {0}", s is object));

            object o = s as object;
            Console.WriteLine(String.Format("o is string : {0}", o is object));
            Console.WriteLine(String.Format("o is object : {0}", o is string));

            object o2 = (object)s; // Explicit cast
            Console.WriteLine(String.Format("o2 is string : {0}", o2 is string));

            // Ternary operator
            Console.WriteLine(String.Format("b ? s : hello : {0}", b ? s : "hello"));

        }
    }
}
