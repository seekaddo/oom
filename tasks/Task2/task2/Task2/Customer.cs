using System;
using System.Collections.Generic;

namespace Task2
{
    public class Customer
    {

        private string customerName;
        private double balance;
        private string accountType;


        public Customer(string name)
        {
            if (name == null) throw new ArgumentException("You can not create a ghost account!!!");

            customerName = name;
            this.balance = 10D;
        }

        public Customer(string customerName, string accountNo) : this(customerName)
        {
            this.AccountNo = accountNo;
            this.balance = 10D;
        }

        public Customer(string customerName, string accountNo, double balance) : this(customerName, accountNo)
        {
            this.balance = balance + 10D;
        }

        public string BankName { get; set; }
        public string AccountNo { get; set; }



        public string AccountType
        {
            get { return accountType; }
            set
            {
                if (value ==null)throw new ArgumentException("Account Name can not be empty!");
                accountType = value;
            }
        }


        public void UpdateBalce(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (balance < 0) throw new ArgumentException("Sorry you cannn't make any withdrawals at the moment: Empty balance");
            balance -= amount;
        }

        public override string ToString()
        {
            var details = $"Customer Name     :{customerName}" + Environment.NewLine +
                          $"Bank              :{BankName}" + Environment.NewLine +
                          $"Account           :{accountType}" + Environment.NewLine +
                          $"Account No.       :{AccountNo}" + Environment.NewLine +
                          $"Current Balance   :${balance}" + (balance < 0 ? "Acht: Negative Balance" : "") +
                          Environment.NewLine;

            return details;
        }


        public static void Main(string[] args)
        {

            Customer custm1 = new Customer("James");

            custm1.AccountNo = "bcl2001";
            custm1.balance = 0.40D;
            custm1.BankName = "Barcleys Bann";
            custm1.accountType = "Savings";
            custm1.UpdateBalce(9000.34);

            Console.WriteLine(custm1);
            Console.WriteLine();

            Customer custm2 = new Customer("Griggor","Kds45889",0.20D);
            custm2.BankName = "London Kings Bank";
            custm2.AccountType = "Checking";
            custm1.Withdraw(200);
            custm2.UpdateBalce(700000.234);


            Console.WriteLine(custm2);
            Console.WriteLine("Customer1 after withdrawal!!!");
            Console.WriteLine(custm1);




        }
    }
}