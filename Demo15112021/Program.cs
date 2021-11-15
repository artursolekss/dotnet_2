using System;

namespace Demo15112021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //class MyProgram : Program,GeniusProgram <--- MULTIPLE INHERITANCE NOT ALLOWED
    class MyProgram : Program, IComparable<MyProgram>  //MyProgram is the Sub-Class of the class Program and it implements IComparable interface (NO MULTIPLE INHERITANCE HERE)
    {
        public int CompareTo(MyProgram o)
        {
            return -1;//NO MEANING, just to escape the errors
        }
    }

    class GeniusProgram
    {

    }
}
