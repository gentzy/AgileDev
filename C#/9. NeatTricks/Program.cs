using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.NeatTricks
{
    delegate int del(int i);

    public static class Program
    {
        static void Main(string[] args)
        {
            string[] friends = DoInitializers();

            // Implicitly typed variables mean the compiler is infering what type they have. 
            // They can only be local and cannot be initialized to null.
            foreach (var friend in friends) // implicitly typed variable
            {
                Console.WriteLine(friend);
            }

            DoAnonymousTypes(friends);

            DoLambda();
        }

        private static void DoAnonymousTypes(string[] friends)
        {
            // Annonymous types are useful when we want to bundle together
            // properties without having to explicitly declare a struct or class.
            // On the flipside you can never refer to the type because it is named
            // by the compiler. You must also use VAR to store it in a variable.
            ArrayList listOfFriends = new ArrayList();
            Random random = new Random();
            foreach (string friend in friends)
            {
                var nameParts = friend.GetNameParts(); // implicitly typed variable
                var newFriend = new { FirstName = nameParts[0], LastName = nameParts[1], Importance = random.Next() % 10 }; // anonymous type + implicitly typed variable
                listOfFriends.Add(newFriend);
            }


            // Dynamic seems similar to var but it is different. They both allow you to bypass explicitly declaring a type.
            // In this context we have a collection of objects (listOfFriends) which we internally know holds the
            // annonymous class used in the previous FOREACH. If we had used VAR, the variable would have had type object. 
            // By using DYNAMIC we are bypassing compilation and resolving the properties access at runtime
            //  => we are telling the compiler to trust us for now and at runtime we will bind to the properties.
            foreach (dynamic newFriend in listOfFriends)
            {
                HowMuchICare(importance: newFriend.Importance, lastName: newFriend.LastName, firstName: newFriend.FirstName); // named parameters
            }

            // We have ommited giving a value to the importance parameter.
            HowMuchICare("Justin", "Bieber");
        }

        private static string[] DoInitializers()
        {
            string[] friends = new string[4] { "Michael Jackson", "Michael Phelps", "Marylin Monroe", "Frank Sinatra" };
            string[] simpleFriends = new[] { "Michael Jackson", "Michael Phelps", "Marylin Monroe", "Frank Sinatra" };
            string[] simplerFriends = { "Michael Jackson", "Michael Phelps", "Marylin Monroe", "Frank Sinatra" };
            return friends;
        }

        // Extension methods give you the ability to extend a class without having the source code.
        // The good thing is that you can call the method like it belonged to the class in the first place.
        // The downside is that you don't have access to the class' internals. 
        public static string[] GetNameParts(this string fullName) // extension method must be in a static class
        {
            return fullName.Split(' ');
        }

        // When a parameter is given a default value, it can be ommited by the callers.
        public static void HowMuchICare(string firstName, string lastName, int importance = 0) // optional parameter
        {
            string care = "not at all";
            if (importance >= 4 && importance < 8)
            {
                care = "a little bit";
            }
            else if (importance >= 8)
            {
                care = "a lot";
            }

            Console.WriteLine("I care about " + firstName + " " + lastName + " " + care);
        }

        // Lambdas are annonymous functions used to create delegates. They are used when we need to pass a delegate
        // to methods. We will interact with them a lot writing LINQ.
        private static void DoLambda()
        {
            del squareNumber = x => x * x; // Could we assign a lambda to VAR ?
            del doubleNumber = x => x + x;
            Console.WriteLine(squareNumber(5));
            Console.WriteLine(doubleNumber(5));
        }
    }
}
