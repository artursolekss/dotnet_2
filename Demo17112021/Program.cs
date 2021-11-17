using System;
using static System.Console;
namespace Demo17112021
{
    class Program
    {
        static void Main(string[] args)
        {

            //myObject objA = new myObject("AAA");
            //myObject objB = new myObject("BBB");
            //Console.WriteLine(objA.Equals(objB));
            //Console.WriteLine(objB.Equals(objA));

            string input = Console.ReadLine();

            Sales s = new Sales();

            Sales st = null;
            if (input.Equals("Sales"))
                st = new Sales();
            else if (input.Equals("SalesTax"))
                st = new SalesTax();

            Console.WriteLine(s.ComputeSales(100));
            Console.WriteLine(s.ComputeSales(100, 2));
            Console.WriteLine(st.ComputeSales(100));


        }

        public static void DoSomething(string a, int b)
        {

        }

        public static void DoSomething(int aa, string b)
        {

        }


    }

    class Sales
    {
        public virtual decimal ComputeSales(decimal price)
        {
            return price;
        }
        public virtual decimal ComputeSales(decimal price, int qty)
        {
            return price * qty;
        }
    }
    class SalesTax : Sales
    {
        public new decimal ComputeSales(decimal price)
        {
            return price * 1.10M; // add tax
        }
    }


    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }


    class Student : Person
    {
        public string Course { get; set; }

        private double grade;
        public double Grade
        {
            get { return grade; }
            set
            {
                if (grade > 0)
                    this.grade = value;
            }
        }
        // access base class members
        public void PrintInfo()
        {
            WriteLine(this.Name);
            WriteLine(this.Age);
            WriteLine(this.Course);
            WriteLine(this.Grade);
        }
    }


    class myObject
    {

        public string myString;

        public myObject(string myStr)
        {
            this.myString = myStr;
        }

        public override bool Equals(object obj)
        {
            myObject mObj = (myObject)obj;
            return this.myString == "AAA" && mObj.myString == "BBB" ? true : false;
        }


    }

}
