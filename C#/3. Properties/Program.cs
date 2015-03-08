using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            TimePeriod timePeriod = new TimePeriod();
            timePeriod.Minutes = 30;
            double hours = timePeriod.Hours;
            //timePeriod.Years = 50;
            timePeriod.Days = 10;
            Console.WriteLine(timePeriod.StringVersion);
        }
    }

    class TimePeriod
    {
        private double seconds;
        private double minutes;
        private double years = 20;
        private string stringVersion;

        // Simple property with full access to the member
        public double Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        // Property which performs operations on a member
        public double Hours
        {
            get { return seconds / 3600; }
            set { seconds = value * 3600; }
        }

        // Readonly property
        public double Years
        {
            get { return years; }
        }

        // Property not connected to a member
        public double Days
        {
            get;
            set;
        }

        // Lazy instantiation of a property
        public string StringVersion
        {
            get
            {
                if (stringVersion == null)
                {
                    stringVersion = Hours.ToString() + "h " + minutes + "m " + seconds + "s";
                }

                return stringVersion;
            }
        }
    }
}
