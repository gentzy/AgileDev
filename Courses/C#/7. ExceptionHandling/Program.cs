using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "6chars";
            try
            {
                char c = s[6];
            }
            catch (Exception ex)
            {
                Console.WriteLine("We have an exception: " + ex.ToString());
            }


            try
            {
                char c = s[6];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("We have an argument out of range exception: " + ex.ToString());
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("We have an index out of range exception: " + ex.ToString());
            }



            try
            {
                throw new MyException("Oops...you did it again");
            }
            catch (Exception ex)
            {
                Console.WriteLine("We have an exception: " + ex.ToString());
            }

            throw new MyException("Oops...you did it again...again");

            Console.WriteLine("Program has exited");
        }

        internal sealed class MyException : Exception
        {
            private string m_message;
            private DateTime m_timeStamp;

            public MyException(string message)
            {
                m_message = message;
                m_timeStamp = DateTime.Now;
            }

            public override string ToString()
            {
                return String.Format("[{0}] {1}", m_timeStamp, m_message);
            }
        }
    }
}
