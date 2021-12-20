using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Demo11122021
{

    class MyDouble
    {
        public double Number { get; set; }
        public MyDouble(double val)
        {
            this.Number = val;
        }
    }

    class Program
    {

        static MyDouble number = new MyDouble(2);
        static void Main()
        {
            ThreadStart task1 = new ThreadStart(ProcessTask1);
            ThreadStart task2 = new ThreadStart(ProcessTask2);
            Thread t1 = new Thread(task1);
            Thread t2 = new Thread(task2);
            t1.Start();
            t2.Start();

            Console.WriteLine(number.Number);
            Console.ReadLine();

        }
        static void ProcessTask1()
        {
            for (int i = 0; i < 5; i++)
            {
                number.Number++;
                Console.WriteLine(number.Number);
                Thread.Sleep(5);
            }
        }
        static void ProcessTask2()
        {
            lock (number)
            {
                for (int i = 0; i < 5; i++)
                {
                    number.Number *= 3;
                    Console.WriteLine(number.Number);
                    Thread.Sleep(10);
                }
            }
        }

    }
}
