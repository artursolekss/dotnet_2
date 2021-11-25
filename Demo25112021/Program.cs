using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo25112021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(12);
            list.Add(20);
            list.Add(7);
            list.Add(8);
            list.Add(2);

            if (list.All(x => x % 2 == 0))//check all elements are even
                Console.WriteLine("All the collection elements are even");
            else if (list.All(x => x % 2 == 1))//check all elements are even
                Console.WriteLine("All the collection elements are odd");

            if (list.Any(x => x % 2 == 0))//check some elements are even
                Console.WriteLine("There are some even");
            if (list.Any(x => x! % 2 == 0))//check some elements odd elements
                Console.WriteLine("There are some odd");


            int size = 100;
            Lazy<string[]> orders = new Lazy<string[]>(() => { size++; return new string[size]; });

            Console.WriteLine(orders.IsValueCreated);
            orders.Value[0] = "Element";
            Console.WriteLine(orders.IsValueCreated);
            //Console.WriteLine(System.Globalization.CultureInfo.GetCultureInfo("es-ES", false));

            decimal cost = 1234434343256m;
            Console.WriteLine(cost.ToString("C"
                , new System.Globalization.CultureInfo("kr-KR")));

            Console.WriteLine(DateTime.Now.ToString("d"
       , new System.Globalization.CultureInfo("se-SE")));




        }
    }

}
