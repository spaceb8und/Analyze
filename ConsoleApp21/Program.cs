
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace FileDetails
{
    enum AccountType
    {
        Checking,
        Deposit
    }



    class BankAccount
    {
        private long accNo;
        private decimal accBal;
        private AccountType accType;
        private static long nextAccNo  = 123;
 
        /// Init accNo, accBal, accType 
        public void Populate(decimal balance)
        {
            this.accNo = NextNumber();
            this.accBal = balance;
            this.accType = AccountType.Checking;
        }
 
        // Method of adding money to the account
        public decimal Deposit(decimal amount)
        {
            accBal += amount;
            return accBal;
        }
 
        // Method of withdrawing money from the account
        public bool Withdraw(decimal amount)
        {
            if(accBal < amount)
            {
                return false;
            }
            else
            {
                accBal -= amount;
                return true;
            }
        }
 
        /// return accNo
        public long GetAccNo()
        {
            return accNo;
        }
 
        // return accBal
        public decimal GetAccBal()
        {
            return accBal;
        }
        // return accType
        public AccountType GetAccType() 
        {
            return accType;
        }
 
 
        // retrun next num accNo
        private static long NextNumber()
        {
            return nextAccNo++;
        }
    }
    class CreateAccount
    {
        static void Main()
        {
            // Creating  first account
            BankAccount berts = NewBankAccount();
            Write(berts); // Output of bank account values
 
            // Creating second account
            BankAccount freds = NewBankAccount();
            Write(freds); // Output of bank account values
 
            // Test block
 
            /// Balance replenishment test
            TestDeposit(berts); 
            Console.WriteLine("Update berts: ");
            Write(berts);
 
            TestDeposit(freds);
            Console.WriteLine("Update freds: ");
            Write(freds);
            /// 
 
            /// Test of withdrawing an amount from the balance
            TestWithdraw(berts);
            Console.WriteLine("Update berts: ");
            Write(berts);
 
            TestWithdraw(freds);
            Console.WriteLine("Update freds: ");
            Write(freds);
            /// 
 
            // end test block
 
            Console.ReadKey();
        }
 
 
        /// Init BankAccount
        static BankAccount NewBankAccount()
        {
            BankAccount created = new BankAccount();
 
            // Console.Write("Enter the account number: ");
            // long number = long.Parse(Console.ReadLine());
            // long number = BankAccount.NextNumber();
            Console.Write("Enter the account balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
 
            // created.accNo = number;
            // created.accBal = balance;
            // created.accType = AccountType.Checking;
 
            created.Populate(balance);
 
            return created;
        }
 
 
 
        static void Write(BankAccount toWrite)
        {
            Console.WriteLine("Account number is {0}", toWrite.GetAccNo());
            Console.WriteLine("Account balance is {0}", toWrite.GetAccBal());
            Console.WriteLine("Account type is {0}", toWrite.GetAccType());
        }
 
        /// Test methods
        public static void TestDeposit(BankAccount acc)
        {
            Console.WriteLine("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            acc.Deposit(amount);
        }
 
        public static void TestWithdraw(BankAccount acc)
        {
            Console.WriteLine("Enter amount to Withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (!acc.Withdraw(amount))
            {
                Console.WriteLine("You can't withdraw this amount from your account");
            }
        }
        ///
    }
}
