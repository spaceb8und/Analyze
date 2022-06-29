



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
/// <summary>
///    Test harness.
/// </summary>
 
// insert testing code here
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
 
    private static long nextNumber = 123;
 
    public void Populate(decimal balance)
    {
        accNo = NextNumber();
        accBal = balance;
        accType = AccountType.Checking;
    }
 
    public bool Withdraw(decimal amount)
    {
        bool sufficientFunds = accBal >= amount;
        if (sufficientFunds)
        {
            accBal -= amount;
        }
        return sufficientFunds;
    }
 
    public decimal Deposit(decimal amount)
    {
        accBal += amount;
        return accBal;
    }
 
    public long Number()
    {
        return accNo;
    }
 
    public decimal Balance()
    {
        return accBal;
    }
 
    public AccountType Type()
    {
        return accType;
    }
 
    private static long NextNumber()
    {
        return nextNumber++;
    }
 
    public void TransferFrom(BankAccount accForm, decimal amount)
    {
        if (accForm.Withdraw(amount))
        {
            Deposit(amount);
        }
    }
}
namespace Bank
{
    class Test
    {
        static void Main()
        {
            // insert testing code here
            decimal balance = 100m; // On each account for$100
 
            // Init b1, b2
            BankAccount b1 = new BankAccount();
            BankAccount b2 = new BankAccount();
            b1.Populate(balance);
            b2.Populate(balance);
 
            // Write on console 
            Write(b1);
            Write(b2);
 
            // Debiting$ 10 from the second account to the first one
            decimal amount = 10m;
            b1.TransferFrom(b2, amount);
 
            // Write on console after transfer
            Console.WriteLine("After Transfer:");
            Write(b1);
            Write(b2);
 
            Console.ReadKey();
        }
 
        static void Write(BankAccount toWrite) // method for displaying the values 
                                               // of all fields of the BankAccount class to the console
        {
            Console.WriteLine("Account number is {0}", toWrite.Number());
            Console.WriteLine("Account balance is {0}", toWrite.Balance());
            Console.WriteLine("Account type is {0}", toWrite.Type());
            Console.WriteLine(" ");
        }
 
    }
}

