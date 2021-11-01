using System;

namespace StarterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int leftBrackets = 0;
            int leftBraces = 0;
            int leftParentheses = 0;

            int rightBrackets = 0;
            int rightBraces = 0;
            int rightParentheses = 0;

            Console.WriteLine("Please, enter the text");
            var text = Console.ReadLine();
            foreach (char ch in text)
            {
                if (ch == '{')
                    leftBraces++;
                else if (ch == '[')
                    leftBrackets++;
                else if (ch == '(')
                    leftParentheses++;
                else if (ch == '}')
                    rightBraces++;
                else if (ch == ']')
                    rightBrackets++;
                else if (ch == ')')
                    rightParentheses++;
            }

            if(leftBraces == rightBraces &&
                leftBrackets == rightBrackets &&
                leftParentheses == rightParentheses)
            Console.WriteLine("Brackets are correct");
            else
                Console.WriteLine("Brackets are not correct");
        }
    }
}
