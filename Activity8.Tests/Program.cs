using System;
using System.Collections.Generic;
using System.IO;
using CSharp.Activity.Collections;
using CSharp.Activity.CoreUtilities;

namespace Activity8
{
    class Program
    {
        public static void Main()
        {
            CustomerInfo customer1 = new CustomerInfo(1, "Jack", "New Avenue 1", "test1@gmail.com");
            CustomerInfo customer2 = new CustomerInfo(2, "James", "New Avenue 2", "test2@gmail.com");
            CustomerInfo customer3 = new CustomerInfo(3, "Jimmy", "New Avenue 3", "test3@gmail.com");
            CustomerInfo customer4 = new CustomerInfo(4, "John", "New Avenue 4", "test4@gmail.com");
            CustomerInfoCollection customerInfoCollection = new CustomerInfoCollection();
            customerInfoCollection[0] = customer1;
            customerInfoCollection[1] = customer2;
            customerInfoCollection[2] = customer3;
            customerInfoCollection[3] = customer4;
            FileHandling fileHandling = new FileHandling(@"C:\Users\Arturs Olekss\Documents\NET_lessons\NET_80\MyCustomers.txt");
            fileHandling.WriteToDisk(customerInfoCollection.ToString());
        }
    }
}
