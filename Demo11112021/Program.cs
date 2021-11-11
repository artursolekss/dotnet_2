using System;

namespace Demo11112021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Person pers = null;
            ////= new Person();
            //Person.GetInstnace(ref pers);
            //pers.Name = "Jack";
            //pers.Age = 21;
            //Console.WriteLine(pers);

            ArrayBase<string> ab = new ArrayBase<string>(10);
            ab[5] = "Text";
            ab[2] = "Text more";
            ab.PrintMe();

        }
    }

    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name.ToUpper();
            }
            set
            {
                this.name = value + "(added from the setter)";
            }
        }
        public int Age { get { return this.age; } set { this.age = value; } }

        private Person() { }

        public static void GetInstnace(ref Person per)//Factory method
        {
            per = new Person();
        }

        public override string ToString()//describe the object as the text
        {
            return "Name: " + this.Name + "\n Age : " + this.Age;
        }

        //public Person(string name, int age)
        //{
        //    Name = name;
        //    Age = age;
        //}

        //public Person(Person copy)
        //{
        //    Name = copy.Name;
        //    Age = copy.Age;
        //}

    }

    class CustomerString
    {
        private char[] myChar;
        private int capacity;
        public virtual char this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.capacity))
                    throw new IndexOutOfRangeException("Invalid Index");

                return myChar[index];
            }
        }
    }

    class ArrayBase<T>
    {
        private T[] storeArray;
        private int currentCount = 0;
        public int Capacity => storeArray.Length;

        public virtual T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.Capacity))
                    throw new IndexOutOfRangeException("Invalid Index");

                return storeArray[index];
            }
            set
            {
                storeArray[index] = value;
            }
        }

        public ArrayBase (int len)
        {
            this.storeArray = new T[len];
        }

        public void PrintMe()
        {
            for (int i = 0; i < this.Capacity; i++)
                Console.WriteLine(this[i]);
        }
    }


}


