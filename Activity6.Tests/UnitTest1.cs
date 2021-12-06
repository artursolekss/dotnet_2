using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.Polymorphism;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Activity6.Tests
{
    [TestClass]
    public class ShapeTest
    {
        /*[TestMethod]
        public void TypeOfShape()
        {
            var shapes = new List<Shape>{
                new Rectangle(2,3),
                new Circle(3)
            };
            var areas = new List<double>();


            foreach (Shape shape in shapes)
            {
                areas.Add(shape.CalculateArea());
            }
            Assert.AreEqual(24, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }*/
        [TestMethod]
        public void TypeOfShape()
        {
            var shapes = new List<Shape>
            {
                new Rectangle(2,3),
                new Circle(3)
            };
            var areas = new List<double>();
            foreach (Shape shape in shapes)
            {
                if (shape.GetType() == typeof(Rectangle))
                {
                    areas.Add(((Rectangle)shape).CalculateArea());
                }
                if (shape.GetType() == typeof(Circle))
                {
                    areas.Add(((Circle)shape).CalculateArea());
                }

            }
            Assert.AreEqual(6, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }

        [TestClass]
        public class ValueTest
        {

            [TestMethod]
            public void TestPositiveValue()
            {
                var myRadius = new Circle(-1);
                var mySides = new Rectangle(3, 4);

                Assert.IsTrue(myRadius.Radius > 0);
                Assert.IsTrue(mySides.Width > 0);
                Assert.IsTrue(mySides.Length > 0);
            }
        }
    }

    [TestClass]
    public class RectangleTest
    {

        [TestMethod]
        public void TestCalculateArea()
        {
            var myRectangle = new Rectangle(3, 4);
            var result = myRectangle.CalculateArea();
            Assert.AreEqual(12, result);
        }

    }
    [TestClass]
    public class CircleTest
    {

        [TestMethod]
        public void TestCalculateArea()
        {
            var myCircle = new Circle(3);
            var result = myCircle.CalculateArea();
            Assert.AreEqual(9, result);
        }

    }
}

