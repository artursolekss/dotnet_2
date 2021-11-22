using System;
using System.Text;
using MyAlias = System.Collections;

namespace Demo22112021
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAlias.ArrayList arr = new MyAlias.ArrayList();

            MyString str1 = new MyString("abcdde");
            MyString str2 = new MyString("testme");
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str1 + str2);
            Console.WriteLine(str1 != str2);

        }
    }

    abstract class MyClass
    {
        public abstract void MyMethod();
    }

    abstract class MySubClass : MyClass
    {
        //don't need to implement the abstract method from the superclass
        //because, this is the abstract class as well
        public override void MyMethod()
        {
            throw new NotImplementedException();
        }

        public void MyEmptyMEthod()
        {
            //empty
        }
    }

    //(2,3,4,5) + (3,4,6,3) = (2+3,3+4,4+6,5+3) = (5,7,10,8)
    //(2,3,4,5) * (3,4,6,3) = 2*3 + 3*4 + 4*6 + 5*3 = 6+12+24+15 =18+39 = 57
    class MyString
    {
        private readonly string myStr;
        public int Length { get { return this.myStr.Length; } }
        public virtual char this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this.myStr.Length))
                    throw new IndexOutOfRangeException("Invalid range");
                return this.myStr[index];
            }
        }

        public MyString(string str)
        {
            this.myStr = str;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(MyString str, object obj)
        {
            if (obj is MyString)
                return str == (MyString)obj;
            else
                return false;
        }

        public static bool operator !=(MyString str, object obj)
        {
            return !(str == obj);
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            //"abcd" + "efgh" = "aebfcgdh";
            //"abcd" + "efg" = "aebfcgh";
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                strBuilder.Append(str1[i]);
                if (str2.Length > i)
                    strBuilder.Append(str2[i]);
            }

            for (int i = str1.Length; i < str2.Length; i++)
            {
                strBuilder.Append(str2[i]);
            }

            return new MyString(strBuilder.ToString());
        }

        public static bool operator ==(MyString str1, MyString str2)
        {
            return str1.ToString().Equals(str2.ToString());
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            return !(str1 == str2);
        }

        public override string ToString()
        {
            return this.myStr;
        }


    }
}
