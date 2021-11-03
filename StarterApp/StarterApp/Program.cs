using System;
using System.Collections.Generic;

namespace StarterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<char> brackets = new LinkedList<char>();
            Console.WriteLine("Please, enter the text");
            var text = Console.ReadLine();
            foreach (char ch in text)
            {
                if (IsLeftBracket(ch))
                    brackets.AddLast(ch);
                else if (IsRightBracket(ch))
                {
                    Console.WriteLine(brackets.Last.Value);
                    if (GetRightBracket(brackets.Last.Value) != ch)
                    {
                        Console.WriteLine("The brackets are positioned incorrectly");
                        return;///exit the program
                    }
                    else
                        brackets.RemoveLast();
                }
            }
            Console.WriteLine("Brackets are positioned correctly");
        }

        static bool IsLeftBracket(char ch)
        {
            return ch == '{' || ch == '['
                    || ch == '(';
        }

        static bool IsRightBracket(char ch)
        {
            return ch == '}' || ch == ']'
                    || ch == ')';
        }

        static char GetRightBracket(char bracket)
        {
            if (bracket == '{')
                return '}';
            else if (bracket == '[')
                return ']';
            else if (bracket == '(')
                return ')';
            else
                return ' ';
        }


    }
}
