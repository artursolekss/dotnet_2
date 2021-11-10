using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {



            //int a = 34;
            //int b = 21;
            int a = 0;
            int b = 0;
            int result;
            //try
            //{
            try
            {
                Console.WriteLine("Provide a");
                a = Int32.Parse(Console.ReadLine());
                if (a == 3)
                    throw new CustomException("I don't want to deal with the value 3");

                Console.WriteLine("Provide b");
                b = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Division result is " + (Program.Division(a, b)));
            }
            //catch(Exception e)
            catch (FormatException ex)
            {
                //if (!(e is DivideByZeroException || e is FormatException))
                //{
                //    throw;//pass this exception to other catch
                //}


                //result = a / b;
                //Console.WriteLine("Something went wrong...");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Here we have the format exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("This is exception handles everything");
            }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            Console.WriteLine("Execution of the program is finished");
            //Program.MakeAdjustments(ref a, ref b, out c);
            //Console.WriteLine(Program.Sum(ref a, b));
            //Console.WriteLine("a = " + a);
            //Console.WriteLine("b = " + b);
            //Program.Add(ref a, b);
            ////Console.WriteLine("a = " + a);
            //string textNumber = Console.ReadLine();
            //int number;
            //if (!Int32.TryParse(textNumber, out number))//if parsing is not sucessfull;
            //    Console.WriteLine("Parsing is not sucessfull");
            //else
            //    Console.WriteLine("Parsing result is " + number);
        }

        public static double Division(int a, int b)
        {
            return a / b;
        }

        public static int Sum(ref int a, int b)
        {
            int sum = a + b;
            a = 90;
            b = 20;
            return sum;
        }

        public static void Add(ref int a, int b)
        {
            a += b;
        }

        public static void MakeAdjustments(ref int a, ref int b, out int c)
        {
            a = (int)Math.Sqrt(a);
            b = (int)Math.Sqrt(b);
            c = a + b;
        }


    }

    class Program2
    {

        public static int Sum(int a, int b)
        {
            return a + b;
        }

    }

    class CustomException : Exception
    {
        private string myText;

        public CustomException(string myText)
        {
            this.myText = myText;
        }

        public override string ToString()
        {
            return this.myText;
        }
    }
}
