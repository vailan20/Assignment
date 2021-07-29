using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    abstract class Abstract_BankAccount
    {
        protected int AccountNo { get; set; }
        protected double AccountBalance { get; set; }
        protected string AccountPassword { get; set; }
        public string BankName = "ABC Bank";
        internal Abstract_BankAccount(int AccountNo, double AccountBalance, string AccountPassword)
        {
            this.AccountNo = AccountNo;
            this.AccountBalance = AccountBalance;
            this.AccountPassword = AccountPassword;
        }
        internal virtual void DisplayAccount()
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", BankName, AccountNo, AccountBalance, AccountPassword);
        }
        abstract internal void Withdraw(double Amount);
    }
    class Abstract_SavingsAccount : Abstract_BankAccount
    {
        private int minimumBalance { get; set; }
        internal Abstract_SavingsAccount(int AccountNo, double AccountBalance, string AccountPassword) : base(AccountNo, AccountBalance, AccountPassword)
        {
            this.minimumBalance = 1000;
        }
        internal override void DisplayAccount()
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3} || Minimum Balance: {4}", BankName, AccountNo, AccountBalance, AccountPassword, minimumBalance);
        }
        internal override void Withdraw(double Amount)
        {
            double FinalBalance = AccountBalance - Amount;
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Minimum Balance: {3}", BankName, AccountNo, FinalBalance, minimumBalance);
        }
    }
    class Abstract_CurrentAccount : Abstract_BankAccount
    {
        private double overdraftLimitAmount { get; set; }
        internal Abstract_CurrentAccount(int AccountNo, double AccountBalance, string AccountPassword) : base(AccountNo, AccountBalance, AccountPassword)
        {
            this.overdraftLimitAmount = 100000.00;
        }
        internal override void DisplayAccount()
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3} || Overdraft Limit Amount: {4}", BankName, AccountNo, AccountBalance, AccountPassword, overdraftLimitAmount);
        }
        internal override void Withdraw(double Amount)
        {
            double Overdraftlimitleft = overdraftLimitAmount - Amount;
            double FinalBalance = AccountBalance - Amount;
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Overdraft Limit Amount: {3}", BankName, AccountNo, FinalBalance, Overdraftlimitleft);
        }
    }
    class Abstract_Account
    {
        static void Main()
        {
            int AccountNo;
            double AccountBalance;
            string AccountPassword;
            bool i = true;

            while (i)
            {
                Console.WriteLine("\nSelect from the options:\n" +
                "1. Savings Account\n" +
                "2. Current Account\n" +
                "3. Withdraw from Savings Account\n" +
                "4. Withdraw from Current Account\n" +
                "5. Exit\n");
                int response = Convert.ToInt32(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Abstract_BankAccount bacc1 = new Abstract_SavingsAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc1.DisplayAccount();
                        break;
                    case 2:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Abstract_BankAccount bacc2 = new Abstract_CurrentAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc2.DisplayAccount();
                        break;
                    case 3:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Console.WriteLine("Enter withdrawal amount");
                        double AmountS = Convert.ToDouble(Console.ReadLine());
                        Abstract_BankAccount bacc3 = new Abstract_SavingsAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc3.Withdraw(AmountS);
                        break;
                    case 4:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Console.WriteLine("Enter withdrawal amount");
                        double AmountC = Convert.ToDouble(Console.ReadLine());
                        Abstract_BankAccount bacc4 = new Abstract_CurrentAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc4.Withdraw(AmountC);
                        break;
                    case 5:
                        i = false;
                        break;
                    default:
                        Console.WriteLine("Please enter number from above options");
                        break;
                }
            }
        }
    }
}
