using System;
using System.Collections.Generic;
using System.IO;
namespace CSharp.Activity.Collections
{
    public class CustomerInfo
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public CustomerInfo(int id, string name, string address, string email)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }

        public override string ToString()
        {
            return "ID = " + this.ID + ";Name = " + this.Name + "; Address = " + this.Address + "; EMail = " + this.Email;
        }

    }

    public class CustomerInfoCollection
    {
        private List<CustomerInfo> customerInfos = new List<CustomerInfo>();
        public int Add(CustomerInfo customerInfo)
        {
            if (customerInfo == null)
                throw new ArgumentNullException();

            if (this.customerInfos.Contains(customerInfo))
                return -1;

            this.customerInfos.Add(customerInfo);
            return this.customerInfos.Count - 1;
        }
        public void Insert(int position, CustomerInfo customerInfo)
        {
            if (customerInfo == null)
                throw new ArgumentNullException();

            if (position < 0)
                throw new ArgumentOutOfRangeException();
            if (this.customerInfos.Contains(customerInfo))
                return;//do nothing

            this.customerInfos.Insert(position, customerInfo);
        }

        public void Remove(CustomerInfo customerInfo)
        {
            if (customerInfo == null)
                throw new ArgumentNullException();

            this.customerInfos.Remove(customerInfo);
        }
        public bool Contains(CustomerInfo customerInfo)
        {
            if (customerInfo == null)
                throw new ArgumentNullException();

            return this.customerInfos.Contains(customerInfo);
        }

        public int IndexOf(CustomerInfo customerInfo)
        {
            if (customerInfo == null)
                throw new ArgumentNullException();
            return this.customerInfos.IndexOf(customerInfo);
        }

        public CustomerInfo this[int index]
        {
            get { return this.customerInfos[index]; }
            set { this.Insert(index, value); }
        }
        public override string ToString()
        {
            System.Text.StringBuilder strBuild = new System.Text.StringBuilder();
            foreach (var element in this.customerInfos)
                strBuild.Append(element + System.Environment.NewLine);
            return strBuild.ToString();
        }

    }

}
namespace CSharp.Activity.CoreUtilities
{
    public class FileHandling
    {
        private string filePath;
        public FileHandling(string filepath)
        {
            this.filePath = filepath;
        }
        public void WriteToDisk(string content)
        {
            File.WriteAllText(this.filePath, content);
        }

        public string ReadFromDisk()
        {
            return File.ReadAllText(filePath);
        }

    }
}