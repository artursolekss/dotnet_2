using System;
using System.Reflection;
using System.IO;

namespace Demo27112021
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pers1 = new Person("Jack", "Smith", new Person.Date(12, 10, 1990), "en", "UK");
            Person pers2 = new Person("Mike", "Johnson", new Person.Date(15, 9, 1980), "en", "US");
            Console.WriteLine(pers1.GetDateOfBirth());
            Console.WriteLine(pers2.GetDateOfBirth());

            Customer cust1 = new Customer("Jack", "Smith", new Person.Date(12, 10, 1990), "en", "UK");

            Person pers = cust1;//up-casting
            DoSomething(pers);//type of the reference is Customer, but the method for the Person will be called
            DoSomething(pers1);

            //if (pers is Customer)//use the check before doing the down-
            //    DoSomething((Customer)pers);

            //Type personType = pers.GetType();
            //MethodInfo[] methods = personType.GetMethods();
            ////foreach (var method in methods)
            ////    Console.WriteLine(method);
            //MethodInfo getDateOfBirth = personType.GetMethod("GetDateOfBirth");
            //string dateResultString = (string)getDateOfBirth.Invoke(pers, new object[] { });
            //Console.WriteLine(dateResultString);

            //MyView1 myView1 = new MyView1();
            //MyView2 myView2 = new MyView2();
            //DoSomethingWithTheObject(myView1);
            //DoSomethingWithTheObject(myView2);
            string filepath = @"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\PracticalTasks\myTextFile2.txt";
            var directoryInfo =
                new DirectoryInfo(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\PracticalTasks\Demo743284732");
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            var file = new FileInfo(filepath);
            if (!file.Exists)
            {
                file.Create().Close();//you need to close the previous stream, before you create a  new one

                //FileStream fileStream = file.OpenWrite();
                //fileStream.Write(System.Text.Encoding.UTF8.GetBytes("Here is my text"));
                //fileStream.Close();

                File.AppendAllText(filepath, "Here is my text");
            }
            else
            {
                //FileStream fileStream = file.OpenRead();
                //byte[] arr = new byte[fileStream.Length];
                //fileStream.Read(arr);
                //Console.Write(System.Text.Encoding.Default.GetString(arr));
                //fileStream.Close();
                string myFileText = File.ReadAllText(filepath);
                Console.WriteLine(myFileText);
            }

        }

        static void DoSomething(Person obj)
        {
            Console.WriteLine("The method for the Person is called");
        }
        static void DoSomething(Customer obj)
        {
            Console.WriteLine("The method for the Customer is called");
        }

        static void DoSomethingWithTheObject(object obj)
        {
            Type objType = obj.GetType();
            MethodInfo doSomethingMethod = objType.GetMethod("DoSomething");
            doSomethingMethod.Invoke(obj, new object[] { });
        }
    }

    class Person
    {
        private Date dateOfBirth;
        private string name;
        private string surname;
        private string lang;
        private string country;
        public Person(string name, string surname, Date dob, string lang, string country)
        {
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dob;
            this.lang = lang;
            this.country = country;
        }

        public string GetDateOfBirth()
        {
            return this.dateOfBirth.GetDateAsString(this.lang, this.country);
        }

        public class Date
        {
            //private int Day { get; set; }
            //private int Month { get; set; }
            //private int Year { get; set; }
            DateTime date;

            public Date(int day, int month, int year)
            {
                date = new DateTime(year, month, day);
            }

            public string GetDateAsString(string lang, string country)
            {

                return this.date.ToString("d"
           , new System.Globalization.CultureInfo(lang + "-" + country));

            }
        }

    }

    class Customer : Person
    {

        public Customer(string name, string surname, Date dob, string lang, string country) :
            base(name, surname, dob, lang, country)
        {
        }

    }

    class MyView1
    {
        public void DoSomething()
        {
            Console.WriteLine("This method does something in View 1");
        }
    }

    class MyView2
    {
        public void DoSomething()
        {
            Console.WriteLine("This method does something in View 2");
        }
    }

}
