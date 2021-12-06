using System;

namespace CSharp.Activity.Polymorphism
{
    public abstract class Shape : IPrintable
    {
        //public double Area { get; protected set; }
        public double Area
        {
            get
            {
                return Area;
            }

            protected set
            {
                return;
            }
        }

        public abstract double CalculateArea();

        public virtual void Print()
        {
            Console.WriteLine($"The area is: {Area}");

        }
    }

}
