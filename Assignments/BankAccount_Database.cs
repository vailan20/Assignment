using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Assignments
{
    interface AccountDao_Database
    {
        void AddAnAccount(Bank_Account Account);
        void Withdraw(int AccountNumber, double Amount);
        double CheckBalance();
        void ChangePassword(int AccountNumber, String OldPassword, String NewPassword);
        List<Bank_Account> ViewAllAccounts();
        void GetAccountDetails(int accountNumber);
    }
    class InMemoryAccountDaoImpl_Database : AccountDao_Database
    {
        List<Bank_Account> account = new List<Bank_Account>();
        public string BankName = "ABC Bank";
        public double AccountBalance { get; set; }
        SqlConnection con = null;
        SqlCommand cmd = null;
        internal SqlConnection GetConnection()
        {
            con = new SqlConnection("Data Source = VAILANTINA; Initial Catalog = db_bankaccount; Integrated Security = true");
            con.Open();
            return con;
        }
        void AccountDao_Database.AddAnAccount(Bank_Account Account)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("CreateNewAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", Account.AccountNo);
                cmd.Parameters.AddWithValue("@AccountBalance", Account.AccountBalance);
                cmd.Parameters.AddWithValue("@AccountPassword", Account.AccountPassword);
                cmd.Parameters.AddWithValue("@BankName", BankName);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Affected: {0}", i);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        void AccountDao_Database.Withdraw(int AccountNumber, double Amount)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("WithdrawMoney", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Affected: {0}", i);
                Console.WriteLine("Here is your Rs {0}/- cash.",Amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        double AccountDao_Database.CheckBalance()
        {
            return AccountBalance;
        }
        void AccountDao_Database.ChangePassword(int AccountNumber, String OldPassword, String NewPassword)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                cmd.Parameters.AddWithValue("@OldPassword", OldPassword);
                cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of Rows Affected: {0}", i);
                if(i <= 0)
                {
                    Console.WriteLine("Wrong password !!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        List<Bank_Account> AccountDao_Database.ViewAllAccounts()
        {
            con = GetConnection();
            cmd = new SqlCommand("ViewAllDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                account.Add(new Bank_Account((int)dr[1], (double)dr[2], (string)dr[3]));
            }
            return account;
        }
        void AccountDao_Database.GetAccountDetails(int AccountNumber)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("ViewCustomerDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Bank Name: {0} || Account No: {1} || Account Balance: {2} || Account Password: {3}", dr[4],dr[1],dr[2],dr[3]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }
    class BankAccount_Database
    {
        static void Main()
        {
            bool i = true;
            AccountDao_Database accdao = new InMemoryAccountDaoImpl_Database();

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
                        foreach (var acc in accdao.ViewAllAccounts())
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
