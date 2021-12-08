namespace CSharp.Activity.Polymorphism
{
    public abstract class Shape
    {
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }
        public abstract void CalculateArea();//this method is actually used as the setter
        public abstract void CalculatePerimeter();
    }

    public interface IPrintable
    {
        void Print();
    }


    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }

        public override void CalculateArea()
        {
            this.Area = this.Length * this.Width;
        }

        public override void CalculatePerimeter()
        {
            this.Perimeter = 2 * (this.Length + this.Width);
        }

        public void Print()
        {
            Console.WriteLine("The area of the rectangle is " + this.Area + System.Environment.NewLine +
                "The perimeter of the rectangle is " + this.Perimeter);
        }

    }

    public class Circle : Shape, IPrintable
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override void CalculateArea()
        {
            this.Area = System.Math.PI * this.Radius * this.Radius;
        }

        public override void CalculatePerimeter()
        {
            this.Perimeter = 2 * this.Radius * System.Math.PI;
        }


        public void Print()
        {
            Console.WriteLine("The area of the circle is " + this.Area + System.Environment.NewLine +
                "The perimeter of the circle is " + this.Perimeter);
        }
    }
}