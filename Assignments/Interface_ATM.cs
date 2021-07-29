using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments
{
    class InvalidAmountException : ApplicationException
    {
        internal InvalidAmountException(string Message) : base(Message)
        {

        }
    }
    class InsufficientFundException : ApplicationException
    {
        internal InsufficientFundException(string Message) : base(Message)
        {

        }
    }
    interface ATM
    {
        void Withdraw(int AccountNumber, double Amount);
        void ChangePassword(int AccountNumber, String OldPassword, String NewPassword);
        void CheckBalance();
    }
    class SbiAtm : ATM
    {
        public double Balance = 10000;
        public double Amount { get; set; }
        void ATM.Withdraw(int AccountNumber, double Amount)
        {
            if (Amount > Balance) throw new InsufficientFundException("Insufficient Funds");
            else
            {
                Console.WriteLine("Account Number: {0} || Amount: {1}", AccountNumber, Amount);
                this.Balance = Balance - Amount;
            }
        }
        void ATM.ChangePassword(int AccountNumber, String OldPassword, String NewPassword)
        {
            Console.WriteLine("Account Number: {0} || Old Password: {1 } || New Password: {2}", AccountNumber, OldPassword, NewPassword);
        }
        void ATM.CheckBalance()
        {
            Console.WriteLine("Balance: {0}",Balance);
        }
    }
    class IciciAtm : ATM
    {
        public double Balance = 20000;
        public double Amount { get; set; }
        void ATM.Withdraw(int AccountNumber, double Amount)
        {
            if (Amount > Balance) throw new InsufficientFundException("Insufficient Funds");
            else
            {
                Console.WriteLine("Account Number: {0} || Amount: {1}", AccountNumber, Amount);
                this.Balance = Balance - Amount;
            }
        }
        void ATM.ChangePassword(int AccountNumber, String OldPassword, String NewPassword)
        {
            Console.WriteLine("Account Number: {0} || Old Password: {1 } || New Password: {2}", AccountNumber, OldPassword, NewPassword);
        }
        void ATM.CheckBalance()
        {
            Console.WriteLine("Balance: {0}", Balance);
        }
    }
    class Interface_ATM
    {
        static void Main()
        {
            ATM atm = new SbiAtm();
            ATM atm1 = new IciciAtm();

            Console.WriteLine("\nChoose a bank:\n" +
                "1. SBI Bank\n" +
                "2. ICICI Bank\n");
            int response = Convert.ToInt32(Console.ReadLine());

            switch (response)
            {
                case 1:
                    Console.WriteLine("\nChoose action:\n" +
                    "1. Withdraw\n" +
                    "2. Change Password\n" +
                    "3. Check Balance");
                    int response1 = Convert.ToInt32(Console.ReadLine());
                    switch (response1)
                    {
                        case 1:
                            Console.WriteLine("Enter account number and amount");
                            int AccountNo = Convert.ToInt32(Console.ReadLine());
                            double Amount = Convert.ToDouble(Console.ReadLine());
                            if(Amount < 0) throw new InvalidAmountException("Amount cannot be negative");
                            else atm.Withdraw(AccountNo, Amount);
                            break;
                        case 2:
                            Console.WriteLine("Enter account number, old password and new password");
                            int AccountNo1 = Convert.ToInt32(Console.ReadLine());
                            string OldPassword = Console.ReadLine();
                            string NewPassword = Console.ReadLine();
                            atm.ChangePassword(AccountNo1, OldPassword, NewPassword);
                            break;
                        case 3:
                            atm.CheckBalance();
                            break;
                        default:
                            Console.WriteLine("Enter from above options");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("\nChoose action:\n" +
                    "1. Withdraw\n" +
                    "2. Change Password\n" +
                    "3. Check Balance");
                    int response2 = Convert.ToInt32(Console.ReadLine());
                    switch (response2)
                    {
                        case 1:
                            Console.WriteLine("Enter account number and amount");
                            int AccountNo = Convert.ToInt32(Console.ReadLine());
                            double Amount = Convert.ToDouble(Console.ReadLine());
                            if (Amount < 0) throw new InvalidAmountException("Amount cannot be negative");
                            else atm1.Withdraw(AccountNo, Amount);
                            break;
                        case 2:
                            Console.WriteLine("Enter account number, old password and new password");
                            int AccountNo1 = Convert.ToInt32(Console.ReadLine());
                            string OldPassword = Console.ReadLine();
                            string NewPassword = Console.ReadLine();
                            atm1.ChangePassword(AccountNo1, OldPassword, NewPassword);
                            break;
                        case 3:
                            atm1.CheckBalance();
                            break;
                        default:
                            Console.WriteLine("Enter from above options");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Enter from above options");
                    break;
            }
        }
    }
}
