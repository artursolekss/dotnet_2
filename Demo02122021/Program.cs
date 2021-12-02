using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo02122021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, PersonalData> persons = new Dictionary<int, PersonalData>();
            PersonalData pers1 = new PersonalData();
            pers1.Name = "Jack";
            pers1.Surname = "Smith";
            //persons.Add(11, pers1);

            PersonalData pers2 = new PersonalData();
            pers2.Name = "John";
            pers2.Surname = "Smith";
            //persons.Add(22, pers2);
            //foreach (var element in persons)
            //    Console.WriteLine(element.Key + " : " + element.Value);
            SortedSet<string> sortSet = new SortedSet<string>();
            sortSet.Add("ABaa");
            sortSet.Add("AAaaa");
            sortSet.Add("Zzzz");
            sortSet.Add("Zzzz");//it will not trigger the exception, but the duplicated element will not be added
            sortSet.Add("ZAzz");
            foreach (var element in sortSet)
                Console.WriteLine(element);

            SortedSet<PersonalData> sortSetPersData = new SortedSet<PersonalData>();
            sortSetPersData.Add(pers1);
            sortSetPersData.Add(pers2);//if I add more than one element to the sorted set
            //it will trigger the exception, if the elements do not implement IComparable
        }

        struct PersonalData
        {
            public string Name { get; set; }
            public string Surname { get; set; }

            public override string ToString()
            {
                return this.Name + " " + this.Surname;
            }
        }

    }
}
