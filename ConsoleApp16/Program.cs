using System;
 
namespace BankAccount
{
    //An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type
    enum AccountType {Сhecking, Deposit}
    class Program
    {
        static void Main(string[] args)
        {
            AccountType goldAccount = AccountType.Сhecking;
            // goldAccount has the value Checkin(1)
            AccountType platinumAccount = AccountType.Deposit;
            // platinumAccount  has the value Deposit(2)
            Console.WriteLine($"goldAccount = {goldAccount}");
            Console.WriteLine($"platinumAccount = {platinumAccount}");
            Console.ReadKey();
        }
    }
}