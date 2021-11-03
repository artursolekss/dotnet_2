using System;
using static System.Console;

namespace Demo1
{
    class Program
    {

        public static void WriteLine(string text)
        {
            ///do some stuff here
        }
        static void Main(string[] args)
        {
            Demo2.Program.WriteLine("Hello World!");
            Console.WriteLine("Argument 1 " + args[0]);
            Console.WriteLine("Argument 2 " + args[1]);

            string text = "Text";
            var sWitch = "3232";
            switch (text)
            {
            }
        }
    }
}

namespace Demo2
{
    class Program
    {

        public static void WriteLine(string text)
        {
            ///do some stuff here
        }
        static void Methods(string[] args)
        {
            Demo1.Program.WriteLine("Hello World!");
            WriteLine("Hello World!");
        }
    }
}