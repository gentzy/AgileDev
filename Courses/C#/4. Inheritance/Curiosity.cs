using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._1_Inheritance
{
    class Curiosity
    {
        // What do you think will be printed out ?
        static void Main(string[] args)
        {
            Derived derivedObj = new Derived();
            Base baseObj = new Derived();
            baseObj.DoSomething("a");

            derivedObj.DoSomething("b");

            Base anotherBaseObj = (Base)derivedObj;
            anotherBaseObj.DoSomething("c");
        }
    }

    class Base
    {
        public virtual void DoSomething(string parameter)
        {
            Console.WriteLine("Base.DoSomething");
        }
    }

    class Derived : Base
    {
        public override void DoSomething(string parameter)
        {
            Console.WriteLine("Derived.Base.DoSomething");
        }

        public void DoSomething(object parameter)
        {
            Console.WriteLine("Derived.DoSomething");
        }
    }
}



// We have overloaded the DoSomething method in the derived class (there are 2 methods with very similar signatures)
// When a method that is overloaded is called, the runtime looks at all the eligile methods and picks the appropriate one.
// However, if a method is a result of an override, it is not considered eligible to be picked when resolving an overload.
