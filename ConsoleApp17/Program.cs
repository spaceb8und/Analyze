using System; 
namespace StructType
{   
    public enum AccountType : ushort {Checking, Deposit}
 
    // A structure type (or struct type) is a value type that can encapsulate data and related functionality
    public struct BancAccount
    {
        public long accNo;
        public decimal accBal;
        public AccountType accType;
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            BancAccount goldAccount;
            // We assign some values to the fields of the structure
            goldAccount.accBal = 12.5M;
            goldAccount.accNo = 1252;
            goldAccount.accType = AccountType.Checking;
            // Output the values of the structure fields to the standard stream
            Console.WriteLine($"goldAccount.accNo: {goldAccount.accNo}");
            Console.WriteLine($"goldAccount.accBal: {goldAccount.accBal}");
            Console.WriteLine($"goldAccount.accType: {goldAccount.accType}");
            Console.ReadKey();
 
        }
    }
}