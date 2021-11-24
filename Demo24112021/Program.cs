using System;
using System.Collections.Generic;

namespace Demo24112021
{
    class Program
    {
        static void Main(string[] args)
        {
            //MySub myobj = new MySub(5);
            //myobj.DoMyMethod();
            //Console.WriteLine(myobj[0]);
            //Console.WriteLine(myobj[1]);
            Console.WriteLine("Please, provide the separator");
            char separator = Console.ReadLine()[0];
            try
            {
                Console.WriteLine("Please, provide the vector 1");
                Vector vect1 = Vector.GetVectorFromString(Console.ReadLine(), separator);

                Console.WriteLine("Please, provide the vector 2");
                Vector vect2 = Vector.GetVectorFromString(Console.ReadLine(), separator);

                double multiplication = vect1 * vect2;
                Console.WriteLine(vect1 + " * " + vect2 + " = " + multiplication);
                Vector vectSum = vect1 + vect2;
                Console.WriteLine(vect1 + " + " + vect2 + " = " + vectSum);
                Vector vectSubtr = vect1 - vect2;
                Console.WriteLine(vect1 + " - " + vect2 + " = " + vectSubtr);

                Vector multiplyBy3 = vect1 * 3;
                Console.WriteLine(vect1 + " * 3 = " + multiplyBy3);

            }
            catch (FormatException)
            {
                Console.WriteLine("Vector has incorrect format");
                return;
            }
            catch (VectorSizeNotMatch)
            {
                Console.WriteLine("Vector size do not match");
            }


        }
    }




    class MySub : MyPar
    {

        public MySub(int size) : base(size)
        {
            //
        }

        public void DoMyMethod()
        {
            this[0] = "MyFirstString";
            this[1] = "MySecondStrin";
        }

    }


    abstract class MyPar
    {
        private string[] arr;

        public MyPar(int size)
        {
            this.arr = new string[size];
        }

        public string this[int index]
        {
            get
            {
                return this.arr[index];
            }
            protected set
            {
                this.arr[index] = value;
            }

        }

    }

}
