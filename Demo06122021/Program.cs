using System;
using CSharp.Activity;
using CSharp.Activity.Datastore;
namespace Demo06122021
{
    class Program
    {
        static void Main(string[] args)
        {

            AbstractArrayStore<string> myCol = new ArrayStore<string>();
            myCol.Add("Element1");
            myCol.Add("Element2");
            myCol.Add("Element3");
            myCol.Add("Element4");
            myCol.Add("Element5");
            myCol.Add("Element6");
            myCol.Add("Element7");
            myCol.Add("Element8");
            myCol.Add("Element9");
            myCol.Add("Element10");
            myCol.Add("Element11");
            myCol.Add("Element12");
            myCol.Add("Element13");
            myCol.Add("Element14");
            myCol.Add("Element15");
            myCol.Add("Element16");
            myCol.Add("Element17");
            myCol.Add("Element18");
            myCol.Add("Element19");
            myCol.Add("Element20");
            for(int i=0;i<myCol.Count;i++)
                Console.WriteLine(myCol[i]);

            //SubClass obj = new SubClass();
            //Base obj2 = obj;//two variables store the same object
            //try
            //{
            //    if (obj2 is SubClass)
            //        obj = (SubClass)obj2;
            //}
            //catch (InvalidCastException)
            //{

            //}
            //Console.WriteLine(obj2 == obj);
            //IMyIntf myInt = obj;
            //myInt.MyMethod();

            //Circle circle = new Circle();
            //circle.Radius = 13;
            //ChangeRadius(circle);//if we pass by ref, then result would be 8, else 13
            //Console.WriteLine("Radius " + circle.Radius);


            //int a = 4;
            //if (a > 3)
            //    Console.WriteLine();
            //else if (a <= 3)
            //    Console.WriteLine();
            //else if (a > 7)//this code is unreachable
            //    Console.WriteLine();

            //try
            //{
            //    try
            //    {
            //        throw new Exception();
            //    }
            //    catch (Exception)
            //    {
            //        //throw;//rethrows the exception and resets the stack trace
            //        throw new Exception();//does not reset the stack trace
            //    }
            //    finally
            //    {
            //        Console.WriteLine("Finally is excuted");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            ////catch (ArgumentException)
            ////{

            ////}


        }

        abstract class MyAbstr : IMyIntf
        {
            public abstract void MyMethod();
        }

        interface IMyIntf
        {
            void MyMethod();
        }

        class SubClass : Base, IMyIntf
        {
            public void MyMethod()
            {

            }

            public SubClass() : base(2)
            {
                Console.WriteLine("Constructor of the sub-class called");
            }

            public void MethodA(int a)
            {

            }
            public string MethodA()
            {
                return "str";
            }

        }

        class Base
        {
            public Base()
            {
                Console.WriteLine("Base constructor with no parameters called");
            }
            public Base(int a)
            {
                Console.WriteLine("Base constructor with 1 parameter called");
            }
        }

        static void ChangeRadius(Circle obj)//if not pass by ref, then the new variable
        {
            obj = new Circle();//the value of the variable
            obj.Radius = 8;
        }
    }

    class Circle
    {
        public double Radius { get; set; }
    }
}
