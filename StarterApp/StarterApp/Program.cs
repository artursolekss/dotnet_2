using System;

namespace StarterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the text");
            var text = Console.ReadLine();
            foreach (char ch in text)
            {
                Console.WriteLine(ch);
            }
        }
    }
}
