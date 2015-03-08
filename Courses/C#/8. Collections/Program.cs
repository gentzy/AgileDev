using System;
using System.Collections;
using System.Collections.Generic;

namespace _6.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            DoCollections();

            DoGenerics();

            DoIterators();
        }

        private static void DoCollections()
        {
            ArrayList array = new ArrayList();
            array.Add("A string");
            array.Add(5);
            array.Add(DateTime.Now);

            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            object[] myArray = new object[3];
            myArray[0] = "A string";
        }

        struct WordCount
        {
            public string word;
            public int count;
        }

        private static void DoGenerics()
        {
            // Generics
            List<string> stringList = new List<string>();
            stringList.Add("A string");
            stringList.Add("Another string");
            //stringList.Add(5);

            List<WordCount> myList = new List<WordCount>();
            myList.Add(new WordCount { word = "elephant", count = 4 });
            myList.Add(new WordCount { word = "zebra", count = 2 });

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            wordCount["elephant"] = 4;
            wordCount["zebra"] = 2;
           // Console.WriteLine(wordCount["lion"]);
            Console.WriteLine(wordCount.ContainsKey("lion") ? "Lion has " + wordCount["lion"] : "Lion has not been counted");

            int lionCount;
            if (wordCount.TryGetValue("lion", out lionCount))
            {
                Console.WriteLine("Lion has " + lionCount);
            }
            else
            {
                Console.WriteLine("Lion has not been counted");
            }
        }

        private static void DoIterators()
        {
            // Iterator
            foreach (int number in RandomNumbers())
            {
                Console.WriteLine(number);
            }

            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Tom");
            employees.Add(391, "Ben");
            employees.Add(709, "Alice");

            CustomCollection<string> customEmployees = new CustomCollection<string>(employees);
            foreach (string employee in customEmployees)
            {
                Console.WriteLine(employee);
                break;
            }

            foreach (string employee in customEmployees)
            {
                Console.WriteLine(employee);
            }
        }

        public static System.Collections.IEnumerable RandomNumbers()
        {
            Random random = new Random(100);

            yield return random.Next();
            yield return random.Next() + 5;
            yield return random.Next() + 8;
        }
    }
}
