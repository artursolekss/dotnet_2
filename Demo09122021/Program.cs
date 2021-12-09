using System;
using System.Collections;
namespace Demo06122021
{
    class Program
    {

        private List<string> list = new List<string>();
        private List<string> duplicateList = new List<string>();
        public delegate void PrintText(string value);
        PrintText print = Console.WriteLine;
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Run();
        }

        public delegate void PrintValue(string value);
        public delegate void Print();
        public delegate object Sum(object obj1, object obj2);
        public delegate object AddMultiply(object obj1, object obj2);

        private Sum sumInt = (x, y) => ((int)x + (int)y);
        private Sum sumStr = (x, y) => ((string)x + (string)y);
        private Sum sumDouble = delegate (object x, object y) { return (double)x + (double)y; };

        public static void WelcomeMessage(string user)
        {
            Console.WriteLine("Welcome " + user);
        }

        public void Run()
        {
            PrintValue welcomeUser = user => Console.WriteLine("Welcome " + user);
            PrintValue wishHappyNew = name => Console.WriteLine("Happy new year " + name);
            PrintValue delegateObj = WelcomeMessage;
            AnotherClass objAn = new AnotherClass();
            Print objHell = objAn.Hello;
            //welcomeUser("TTPF");
            this.DoSomething(welcomeUser);
            this.DoSomething(wishHappyNew);

            //Sum sumInt = (x, y) => ((int)x + (int)y);
            //Sum sumStr = (x, y) => ((string)x + (string)y);
            //Sum sumDouble = delegate (object x, object y) { return (double)x + (double)y; };

            print(sumInt(12, 14).ToString());
            print(sumStr("Text part 1", ";Text part 2").ToString());

            AddMultiply multiplyDoubles = (x, y) => (double)x * (double)y;
            AddMultiply sumDoubles = (x, y) => (double)x + (double)y;
            AddMultiply divideDouble = (x, y) => (double)x / (double)y;

            MyDelegate getSubClass1Obj = () => new MySubclass1();// () means there is no arguments to pass
            MyDelegate getSubClass2Obj = () => new MySubclass2();
            MyDelegate getMyClass = () => new MySuperClass();

            this.Subscribe(this.OnButtonPressed);
            this.Subscribe(this.OnChange);
            this.Event(this, new EventArgs());//Event is triggered here

            this.MyEvent += this.DoSomething;
            this.MyEvent += this.DoSomething2;
            //this.MyEvent += this.OnButtonPressed;//the method does not match the pattern
            this.MyEvent();

            this.OnCollectionChanged += this.CopyPasteCollectionElements;
            this.DoSomeActionsOnCollection();


        }

        private void DoSomeActionsOnCollection()
        {
            this.Add("MyElement");
            this.Add("MyElemen4");
            this.Add("MyElement2");
            this.RemoveLastElement();
            this.OnCollectionChanged();
        }

        public void Add(string element)
        {
            this.list.Add(element);
        }

        public void RemoveLastElement()
        {
            this.duplicateList.RemoveAt(this.duplicateList.Count - 1);
        }

        public void CopyPasteCollectionElements()
        {
            this.duplicateList.Clear();

            foreach (var element in this.list)
                this.duplicateList.Add(element);
        }

        public event MyEventDel OnCollectionChanged;

        public void OnButtonPressed(object sender, EventArgs eventArgs)
        {
            print("Button is pressed");
        }

        public void OnChange(object sender, EventArgs eventArgs)
        {
            print("Something is changed");
        }

        private void Subscribe(EventHandler<EventArgs> eventDelegate)
        {
            this.Event += eventDelegate;
        }

        private event EventHandler<EventArgs> Event;

        public delegate void MyEventDel();
        private event MyEventDel MyEvent;

        private delegate MySuperClass MyDelegate();
        private delegate void MySub1Delegate(MySubclass1 arg);

        private void DoSomething()
        {
            print("These method does something");
        }

        private void DoSomething2()
        {
            print("These method also does something");
        }

        private void ShowSum(object a, object b)
        {

            Sum sum = null;
            if (a is int && b is int)
                sum = this.sumInt;
            else if (a is double && b is double)
                sum = this.sumDouble;
            else if (a is string && b is string)
                sum = this.sumStr;

            if (sum == null)
                return;

            Console.WriteLine(sum(a, b));

        }

        private double DoDoubleAction(AddMultiply addMultiply, double a, double b)
        {
            if (addMultiply(a, b) is double)
                return (double)addMultiply(a, b);
            else
                return 0;
        }

        private void DoSomething(PrintValue printValue)
        {
            printValue("the text");
        }

    }

    class MySuperClass
    {
    }

    class MySubclass1 : MySuperClass
    {
    }

    class MySubclass2 : MySuperClass
    {
    }

    class AnotherClass
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
}
