using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    interface AccountDao
    {
        void AddAnAccount(Bank_Account Account);
        void Withdraw(int AccountNumber, double Amount);
        double CheckBalance();
        void ChangePassword(int AccountNumber, String OldPassword, String NewPassword);
        List<Bank_Account> ViewAllAccounts();
        void GetAccountDetails(int accountNumber);
    }
    class InMemoryAccountDaoImpl : AccountDao
    {
        List<Bank_Account> account = new List<Bank_Account>();
        public string BankName { get; set; }
        public double AccountBalance { get; set; }
        void AccountDao.AddAnAccount(Bank_Account Account)
        {
            this.AccountBalance = Account.AccountBalance;
            this.BankName = Account.BankName;
            account.Add(new Bank_Account(Account.AccountNo, Account.AccountBalance, Account.AccountPassword));
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", Account.BankName, Account.AccountNo, Account.AccountBalance, Account.AccountPassword);
        }
        void AccountDao.Withdraw(int AccountNumber, double Amount)
        {
            foreach (var a in account)
            {
                if(a.AccountNo == AccountNumber)
                {
                    this.AccountBalance = AccountBalance - Amount;
                    a.AccountBalance = AccountBalance;
                    Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2}", BankName, AccountNumber, AccountBalance);
                    break;
                }
            }
        }
        double AccountDao.CheckBalance()
        {
            return AccountBalance;
        }
        void AccountDao.ChangePassword(int AccountNumber, String OldPassword, String NewPassword)
        {
            Console.WriteLine("Bank Name: {0} || Account No: {1} || Old Password: {2} || New Password: {3}", BankName, AccountNumber, OldPassword, NewPassword);
            foreach (var a in account)
            {
                if(a.AccountNo == AccountNumber)
                {
                    if(a.AccountPassword == OldPassword)
                    {
                        a.AccountPassword = NewPassword;
                    }
                    else
                    {
                        Console.WriteLine("Old password is wrong");
                    }
                }
            }
        }
        List<Bank_Account> AccountDao.ViewAllAccounts()
        {
            return account;
        }
        void AccountDao.GetAccountDetails(int AccountNumber)
        {
            foreach (var a in account)
            {
                if(a.AccountNo == AccountNumber)
                {
                    Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", BankName, a.AccountNo, a.AccountBalance, a.AccountPassword);
                }
            }
        }
    }
    class Collection_Database
    {
        static void Main()
        {
            bool i = true;
            AccountDao accdao = new InMemoryAccountDaoImpl();

            while (i)
            {
                Console.WriteLine("\nSelect from the options:\n" +
                "1. Add an account\n" +
                "2. Withdraw money\n" +
                "3. Check Balance\n" +
                "4. Change Password\n" +
                "5. View all accounts\n" +
                "6. Get your account details\n" +
                "7. Exit\n");
                int response = Convert.ToInt32(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter Account number, balance and password");
                        int AccountNo = Convert.ToInt32(Console.ReadLine());
                        double AccountBalance = Convert.ToDouble(Console.ReadLine());
                        string AccountPassword = Console.ReadLine();
                        accdao.AddAnAccount(new Bank_Account(AccountNo, AccountBalance, AccountPassword));
                        break;
                    case 2:
                        Console.WriteLine("Enter Account number and amount");
                        int AccountNoW = Convert.ToInt32(Console.ReadLine());
                        double Amount = Convert.ToDouble(Console.ReadLine());
                        accdao.Withdraw(AccountNoW, Amount);
                        break;
                    case 3:
                        accdao.CheckBalance();
                        break;
                    case 4:
                        Console.WriteLine("Enter account number, old password and new password");
                        int AccountNo1 = Convert.ToInt32(Console.ReadLine());
                        string OldPassword = Console.ReadLine();
                        string NewPassword = Console.ReadLine();
                        accdao.ChangePassword(AccountNo1, OldPassword, NewPassword);
                        break;
                    case 5:
                        foreach( var acc in accdao.ViewAllAccounts())
                        {
                            Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", acc.BankName, acc.AccountNo, acc.AccountBalance, acc.AccountPassword);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter Account number");
                        int AccountNo2 = Convert.ToInt32(Console.ReadLine());
                        accdao.GetAccountDetails(AccountNo2);
                        break;
                    case 7:
                        i = false;
                        break;
                    default:
                        Console.WriteLine("Choose a valid option");
                        break;
                }
            }
        }
    }
}
