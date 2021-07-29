using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    class Bank_Account
    {
        internal int AccountNo { get; set; }
        internal double AccountBalance { get; set; }
        internal string AccountPassword { get; set; }
        public string BankName { get; set; }
        internal Bank_Account()
        {
            this.BankName = "ABC Bank";
        }
        internal Bank_Account(int AccountNo, double AccountBalance, string AccountPassword)
        {
            this.AccountNo = AccountNo;
            this.AccountBalance = AccountBalance;
            this.AccountPassword = AccountPassword;
        }
        internal virtual void DisplayAccount(Bank_Account bacc)
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", bacc.BankName, AccountNo, AccountBalance, AccountPassword);
        }
    }
    class SavingsAccount : Bank_Account
    {
        private int minimumBalance { get; set; }
        internal SavingsAccount(int AccountNo, double AccountBalance, string AccountPassword) : base(AccountNo, AccountBalance, AccountPassword)
        {
            this.minimumBalance = 1000;
        }
        internal override void DisplayAccount(Bank_Account bacc)
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3} || Minimum Balance: {4}", bacc.BankName, AccountNo, AccountBalance, AccountPassword, minimumBalance);
        }
    }
    class CurrentAccount : Bank_Account
    {
        private double overdraftLimitAmount { get; set; }
        internal CurrentAccount(int AccountNo, double AccountBalance, string AccountPassword) : base(AccountNo, AccountBalance, AccountPassword)
        {
            this.overdraftLimitAmount = 100000.00;
        }
        internal override void DisplayAccount(Bank_Account bacc)
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3} || Overdraft Limit Amount: {4}", bacc.BankName, AccountNo, AccountBalance, AccountPassword, overdraftLimitAmount);
        }
    }
    class Account
    {
        static void Main()
        {
            int AccountNo;
            double AccountBalance;
            string AccountPassword;
            bool i = true;
            Bank_Account bacc = new Bank_Account();

            while (i)
            {
                Console.WriteLine("\nSelect from the options:\n" +
                "1. Savings Account\n" +
                "2. Current Account\n" +
                "3. Exit\n");
                int response = Convert.ToInt32(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Bank_Account bacc1 = new SavingsAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc1.DisplayAccount(bacc);
                        break;
                    case 2:
                        Console.WriteLine("Enter Bank Account No, Account Balance and Account Password");
                        AccountNo = Convert.ToInt32(Console.ReadLine());
                        AccountBalance = Convert.ToDouble(Console.ReadLine());
                        AccountPassword = Console.ReadLine();
                        Bank_Account bacc2 = new CurrentAccount(AccountNo, AccountBalance, AccountPassword);
                        bacc2.DisplayAccount(bacc);
                        break;
                    case 3:
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
