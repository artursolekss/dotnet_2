using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo01122021;


namespace TestMyLinkedLists
{
    [TestClass]
    public class UnitTest1
    {
        private MyLinkedList<string> myList;
        [TestInitialize]//the method which is triggered at the beggining to prepare the parameters for the testing
        public void Initializer()
        {
            this.myList = new MyLinkedList<string>();
        }

        [TestMethod]
        public void AddLastElements()
        {
            this.myList.AddLast("Hello");
            this.myList.AddLast("World");
            Assert.AreEqual(this.GetLastElement(), "World");
        }
        [TestMethod]
        public void GetLast()
        {
            this.myList.AddLast("Element1");
            this.myList.AddLast("Element2");
            Assert.AreEqual(this.GetLastElement(), "Element2");
        }

        [TestMethod]
        public void TestLoop()
        {
            this.myList.AddLast("Element2");
            this.myList.AddLast("Element12");
            this.myList.AddLast("Element2121");
            this.myList.AddLast("Element3232");
            string[] compareArr = new string[] { "Element2", "Element12", "Element2121", "Element3232" };

            int i = 0;

            foreach (var element in this.myList)
                //Assert.AreEqual(element, compareArr[i++]);
                Assert.IsTrue(element.Equals(compareArr[i++]));

        }
        [TestMethod]
        public void TestPrintElements()
        {
            this.myList.AddLast("Element2");
            this.myList.AddLast("Element12");
            this.myList.AddLast("Element2121");
            this.myList.AddLast("Element3232");
            string outputExpected = "Element2" + System.Environment.NewLine +
                "Element12" + System.Environment.NewLine + "Element2121"
                + System.Environment.NewLine + "Element3232" + System.Environment.NewLine;
            System.IO.StringWriter strW = new System.IO.StringWriter();
            System.Console.SetOut(strW);
            this.myList.PrintElements();
            Assert.AreEqual(outputExpected, strW.ToString());
        }


        [TestMethod]
        public void Test75PercentSuccess()
        {
            this.myList.AddLast("Element2");
            this.myList.AddLast("Element12");
            this.myList.AddLast("Element2121");
            this.myList.AddLast("Element3232");
            string[] compareArr = new string[] { "Element212", "Element12", "Element2121", "Element3232" };

            int numberOfIncorrectCases = 0;
            int i = 0;

            foreach (var element in this.myList)
                //Assert.AreEqual(element, compareArr[i++]);
                if (!element.Equals(compareArr[i++]))
                    numberOfIncorrectCases++;

            if (numberOfIncorrectCases > 1)
                Assert.Fail();
        }

        //[TestMethod]
        //public void ThisShoulFail()
        //{
        //        Assert.Fail();
        //}

        private string GetLastElement()
        {
            return this.myList.GetLast().Current;
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotExist))]
        public void GetNotExistingIndex()
        {
            this.myList.AddLast("Element2");
            this.myList.AddLast("Element12");
            this.myList.AddLast("Element2121");
            this.myList.AddLast("Element3232");
            this.myList.GetElementByIndex(4);
        }

    }
}
