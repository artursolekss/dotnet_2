using System;
using System.Collections;
namespace Demo20112021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Animal animal;
            //Bulldog bulldog = new Bulldog();
            //Animal animalReal = new Animal();
            //try
            //{
            //    animal = bulldog;/////Up-casting <---- cast the object from the source variable which has more specific type than the target variable
            //    if (animal is Bulldog)//Check if animal is Bulldog (or any subclass of Bulldog class)
            //        bulldog = (Bulldog)animal;////Down-casting <---- cast the object from the source variable which has more general type than the target variable

            //    //NOT CORRECT, because the object reference stored under animalReal is not and instance of Bulldog class
            //    if (animalReal is Bulldog)
            //        bulldog = (Bulldog)animalReal;
            //}
            //catch (InvalidCastException)
            //{
            //    Animal anim = animalReal;//at this point we know that the cast was unsecussful, so we try another option

            //}

            Product prd = new Computer();

            BankOperations bankOp = new Savings();//Polymorphism and Up-Casting is used here

            Savings sav;
            if (bankOp is Savings)//All the rules for the interfaces are the same as for the usual classes
                sav = (Savings)bankOp;

        }
    }

    class ATM : BankOperations
    {
        public void Withdraw(double amount)
        {
            //
        }
        public void Deposit(double amount)
        {

        }
        public double BalanceInquiry()
        {
            return 112;
        }
    }

    class Shop
    {
        private ArrayList productCatalog;
        private ArrayList basketProducts;
        private double totalPrice;

        public void AddProductToBasket(Product product)//UpCasting will already be used here
        {
            this.totalPrice += product.Quantity * product.Price;
            if (product is Computer)
            {
                Computer comp = (Computer)product;
                if (comp.AdditionalWarranty)
                    this.totalPrice += comp.ExtWarrantyPrice;
            }

            if (product is GroupA)
                Console.WriteLine("The product " + product + " is in Group A");

            if (product is GroupB)
                Console.WriteLine("The product " + product + " is in Group B");

            this.basketProducts.Add(product);
        }

        public void AddProductToCatalog(Product product)
        {
            this.productCatalog.Add(product);
        }

    }

    //Marker interface
    interface GroupA
    {
    }

    //Marker interface
    interface GroupB
    {
    }

    abstract class Product
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public abstract string GetMyDescription();//All abstract methods are virtual

        public void MyUsualMeth()
        {

        }
    }

    class Water : Product, GroupA
    {
        public int Volume { get; set; }
        public override string GetMyDescription()
        {
            throw new NotImplementedException();
        }

    }

    class Computer : Product, GroupB
    {
        public int Warranty { get; set; }
        public bool AdditionalWarranty { get; set; }
        public double ExtWarrantyPrice { get; set; }

        public override string GetMyDescription()
        {
            throw new NotImplementedException();
        }

    }


    class Animal
    {

    }

    class Dog : Animal
    {

    }

    class Bulldog : Dog
    {

    }

    public abstract class AccountInfo
    {
        public double Balance { get; set; }
        public abstract void PrintAccountInfo();
    }

    public interface BankOperations
    {
        void Withdraw(double amount);
        void Deposit(double amount);
        double BalanceInquiry();

    }

    public interface CreditCard
    {
        void Deposit(double amount);
    }

    public class Savings : AccountInfo, BankOperations, CreditCard
    {
        public void Withdraw(double amount)
        {
            Balance = Balance - amount;
        }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
        }

        public double BalanceInquiry()
        { return Balance; }
        public override void PrintAccountInfo()//All abstract methods must be implemented and you must use "override" keyword
        {
            Console.WriteLine("Account Balance: " + Balance);
        }
    }


}
