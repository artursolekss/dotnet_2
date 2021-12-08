using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.Polymorphism;
using System.Linq;
namespace Activity6.Test
{
    [TestClass]
    public class Activity6_test
    {

        [TestMethod]
        public void CheckCircleImplementsIPrintable()
        {

            Assert.IsTrue(typeof(Circle).GetInterfaces().Any(intf => intf == typeof(IPrintable)));
        }

        [TestMethod]
        public void CheckRectangleImplementsIPrintable()
        {
            Assert.IsTrue(typeof(Rectangle).GetInterfaces().Any(intf => intf == typeof(IPrintable)));
        }


        [TestMethod]
        public void CalculateAreaCircle()
        {
            Shape circle = new Circle(5);
            circle.CalculateArea();
            Assert.AreEqual(5 * 5 * System.Math.PI, circle.Area);

            circle = new Circle(7);
            circle.CalculateArea();
            Assert.AreEqual(7 * 7 * System.Math.PI, circle.Area);
        }

        [TestMethod]
        public void CalculatePerimeterCircle()
        {
            Shape circle = new Circle(10);
            circle.CalculatePerimeter();
            Assert.AreEqual(10 * 2 * System.Math.PI, circle.Perimeter);
        }

        [TestMethod]
        public void TestPrintCircle()
        {
            Shape circle = new Circle(10);
            circle.CalculatePerimeter();
            circle.CalculateArea();
            double area = 10 * 10 * System.Math.PI;
            double perimeter = 2 * 10 * System.Math.PI;
            string outputExpected = "The area of the circle is " + area + System.Environment.NewLine +
                "The perimeter of the circle is " + perimeter + System.Environment.NewLine;

            this.TestPrint((IPrintable)circle, outputExpected);
        }

        private void TestPrint(IPrintable obj, string outputExpected)
        {
            System.IO.StringWriter strW = new System.IO.StringWriter();
            System.Console.SetOut(strW);
            obj.Print();
            Assert.AreEqual(outputExpected, strW.ToString());
        }
    }
}