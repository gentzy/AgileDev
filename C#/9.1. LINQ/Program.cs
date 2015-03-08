using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFavoriteMoviesLinqQuery();

            MyFavoriteMoviesLinqMethods();

            SolutionWithoutLinq();

            SolutionWithLinq();
        }

        private static void MyFavoriteMoviesLinqQuery()
        {
            // Assume we have an array of strings.
            string[] favoriteMovies = { "The Hunger Games", "Expendables", "Delirium", "Taxi 2" };

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in favoriteMovies
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        private static void MyFavoriteMoviesLinqMethods()
        {
            // Assume we have an array of strings.
            string[] favoriteMovies = { "The Hunger Games", "Expendables", "Delirium", "Taxi 2" };

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = favoriteMovies.Where(movie => movie.Contains(" ")).OrderBy(movie => movie);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        private static void SolutionWithoutLinq()
        {
            string[] favoriteMovies = { "The Hunger Games", "Expendables", "Delirium", "Taxi 2" };
            var moviesWithSpace = new List<string>();

            foreach (var movie in favoriteMovies)
            {
                if (movie.Contains(""))
                {
                    moviesWithSpace.Add(movie);
                }
            }

            BindToTable(moviesWithSpace);

            // We need to create an extra container (which could esentially hold all the values of the
            // original container) and iterated twice over the container (once in the Bind method).
        }

        private static void SolutionWithLinq()
        {
            string[] favoriteMovies = { "The Hunger Games", "Expendables", "Delirium", "Taxi 2" };
            IEnumerable<string> subset = favoriteMovies.Where(movie => movie.Contains(" ")).OrderBy(movie => movie); //at this point we haven't executed anything
            BindToTable(subset); // the collection is iterated only here
        }

        private static void BindToTable(IEnumerable<string> collection)
        {
            // Imagine this method is showing the data in a UI table.
            // It iterates through the collection and applies formatting and so on.
        }
    }
}
