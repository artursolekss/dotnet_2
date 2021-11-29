using System;
using System.Collections;
using System.Collections.Generic;
namespace Demo29112021
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<string> obj = new MyClass<string>(10);
            obj.myMethod();//this should not raise any excpetion
            MyClass<int> objI = new MyClass<int>(5);//for objI T type is int
            objI.myMethod();
            objI.myMemeber = 2121;
            //objI.myMemeber = "test";//not possible
            obj.myMemeber = "MyStr";//setter is called
            //obj.myMemeber = 121;///Not possible, since T type for obj var is string
            string myStr = obj.myMemeber; //getter is called
            //int myInt = obj.myMemeber;//not possible

            obj[0] = "Element1";
            obj[1] = "Element2";
            obj[2] = "Eleemnt3";
            obj[3] = "Eleemnt4";

            foreach (var myElement in obj)
                Console.WriteLine(myElement);

            ArrayList myArrayList = new ArrayList();//does not use generics, any type can be added
            myArrayList.Add("MyStr");
            myArrayList.Add(343);

            LinkedList<string> lnkList = new LinkedList<string>();//lnkList will only store the strings
            lnkList.AddLast("Str");
            //lnkList.AddLast(3232);
            LinkedList<int> lnkListI = new LinkedList<int>();
            lnkListI.AddLast(32);
            //lnkListI.AddLast("Str");
        }
    }

    class MyClass<T> : IEnumerable where T : IComparable<T>
    {
        public T myMemeber { get; set; }
        private T[] myArray;

        public MyClass(int size)
        {
            this.myArray = new T[size];
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in this.myArray)
                yield return element;
            yield break;
        }

        public T this[int index]
        {
            get
            {
                return this.myArray[index];
            }
            set
            {
                this.myArray[index] = value;
            }
        }

        public void myMethod()
        {

            //This is the trick, how you can try to assign any value to 
            //the variable defined as T

            if (this.myMemeber is string)
            {
                object obj = "myString";
                this.myMemeber = (T)obj;
            }
        }

        public int CompareTwo(T arg1, T arg2)
        {
            return arg1.CompareTo(arg2);
        }
    }
}
