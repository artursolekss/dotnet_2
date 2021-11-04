using System;

namespace Demo04112021
{

    class GenClass<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public void DisplayMe(T val)
        {
            Console.WriteLine(val);
        }

        public U GenMethod<U>() => default(U);

        public bool IsGreaterThan(T val)
        {
            return this.IsGreaterThan(val);
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            GenClass<int> genInt = new GenClass<int>();
            GenClass<string> genStr = new GenClass<string>();
            //GenClass<Program> var = new GenClass<Program>();

            var var1 = genInt.Value; // the type of var1 is int
            var var2 = genStr.Value; // the type of var2 is string

            var var3 = genInt.GenMethod<byte>(); // the type of var2 is byte 
                                                 // and it is initialized to 0


            //var answer = System.DateTime.Now.Year == 2021 ? "Now is 2021" : "Now is not 2021";

            string answer;
            //if (System.DateTime.Now.Year == 2021)
            //    answer = "Now is 2021";
            //else
            //    answer = "Now is not 2021";

            switch (System.DateTime.Now.Year)
            {
                case 2021:
                    answer = "Now is 2021";
                    break;
                default:
                    answer = "Now is not 2021";
                    break;
            }

            Console.WriteLine(answer);


            //int x = 10;
            //object obj1 = x;
            //object obj2 = "text";
            //x = 456;
            //Console.WriteLine(x);
            //Console.WriteLine(obj1);


            //    int? age = null;
            //    if (age.HasValue == true)
            //    {
            //        System.Console.WriteLine("num = " + age.Value);
            //    }
            //    else
            //    {
            //        System.Console.WriteLine("num = Null");
            //    }
            //    //y is set to zero 
            //    int y = age.GetValueOrDefault();
            //    // num.Value throws an InvalidOperationException if
            //    // num.HasValue is false 
            //    try
            //    {
            //        y = age.Value;
            //    }
            //    catch (System.InvalidOperationException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
        }
    }
}
