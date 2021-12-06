
using System;

namespace CSharp.Activity.Polymorphism
{
    public class Rectangle : Shape
    {
        /*public double Length { get; protected set; }*/
        public double Length 
        {
            get
            {
                return Length;
            }

            protected set
            {
                return;
            }
        }
        

        public double Width
        {

            get
            {
                return Width;
            }
            protected set
            {
                return;
            }
        }

        public Rectangle(double length, double width) : base()
        {
            this.Width=width;
            this.Length = length;
        }

        public override double CalculateArea()
        {
            return Length * Width;

        }

        public override void Print()
        {
             
        }

    }

}
