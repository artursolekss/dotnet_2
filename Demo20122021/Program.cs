using System.Text;
using System.Collections.Generic;

namespace Demo20122021
{

    class Program
    {

        static void Main()
        {

            StringBuilder srBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
                srBuilder.Append(i);
            Console.WriteLine(srBuilder.ToString());

            Dictionary<string,string> myDict = new Dictionary<string, string>();
            myDict.Add("FirstElement", "MyValue");
            MyDelegate myDel = MyCal;
            myDel(32);

        }

        static void MyCal(int myp)
        {
        }

        private delegate void MyDelegate(int par);
    }
}