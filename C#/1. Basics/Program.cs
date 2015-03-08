using System;
using System.Collections.Generic;
using System.Linq;
using Text = System.Text;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Text.StringBuilder strBuilder = new Text.StringBuilder();
            strBuilder.AppendLine("Title");
            strBuilder.Append("Contents");
            Console.WriteLine(strBuilder.Length);
            Console.WriteLine(strBuilder.ToString());
        }
    }
}

