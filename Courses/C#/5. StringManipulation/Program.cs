using System;
using System.Collections.Generic;
using System.Linq;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Some ";
            string s1 = "escaped \"text\"";
            string s2 = @"""escaped text"""; // verbatim string literal
            string s3 = "\u0029";

            Console.WriteLine(s3);
            Console.WriteLine(s + s1);
            Console.WriteLine("New line \r\n " + s2);
            Console.WriteLine(@"New line \r\n " + s2);

            // Operations
            Console.WriteLine("\r\nOPERATIONS");
            Console.WriteLine(s[2]); // m
            Console.WriteLine(s2.Length); // 14
            Console.WriteLine(new string('a', 3));
            Console.WriteLine(Char.IsLetterOrDigit(s3[0]));
            Console.WriteLine(s2.Contains("text"));
            Console.WriteLine(s1.IndexOf("e")); // Which e will it return the index of ?

            Console.WriteLine("\r\nIMMUTABILITY");
            string newS = s;
            newS = String.Concat(newS, "new text");

            Console.WriteLine("\r\nSTRING BUILDER");
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.AppendLine(s);
            builder.AppendLine(s2);
            builder.AppendLine(s3);
            Console.WriteLine(builder.ToString());

            double d = 299792.457999999984;
            decimal dec = 299792.457999999984M;
        }
    }
}
