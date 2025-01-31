//Account Management
//Create a new bank account(Name, Account Number, Initial Balance)
//View all bank accounts
//Search accounts by name
//Sort accounts by balance (Ascending/Descending)

//Transactions
//Deposit money into an account
//Withdraw money from an account (with minimum balance check)
//View transaction history of an account

//Bank Summary
//View details of a specific account (Account Number, Name, Balance)
//Get total bank balance (Sum of all account balances)


using System;
using System.Collections.Generic;
using System.Linq;

public class BankAccount
{
    public string Name;
    public int AccountNumber;
    public int Balance;
    public List<string> transcaction = new List<string>();

    public BankAccount(string name, int accountNumber, int initialBalance, String intialDeposit)
    {
        Name = name;
        AccountNumber = accountNumber;
        Balance = initialBalance;
        transcaction.Add(intialDeposit);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Account Number: {AccountNumber}, Balance: {Balance}";
    }
}

class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nBank Account Management System");
            Console.WriteLine("1. Create a new bank account");
            Console.WriteLine("2. View all bank accounts");
            Console.WriteLine("3. Search accounts by name");
            Console.WriteLine("4. Sort accounts by balance");
            Console.WriteLine("5. Deposit Money");
            Console.WriteLine("6. Withdraw Money");
            Console.WriteLine("7. View All Transaction");
            Console.WriteLine("8. View Account");
            Console.WriteLine("9. View Bank Balance");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        ViewAllAccounts();
                        break;
                    case 3:
                        SearchAccountsByName();
                        break;
                    case 4:
                        SortAccountsByBalance();
                        break;
                    case 5:
                        Deposit();
                        break;
                    case 6:
                        Withdraw();
                        break;
                    case 7:
                        ViewAllTransaction();
                        break;
                    case 8:
                        ViewAccount();
                        break;
                    case 9:
                        getTotalBankBalance();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter account number: ");
        int accountNumber = Int32.Parse(Console.ReadLine());

        Console.Write("Enter initial balance: ");
        int initialBalance = Int32.Parse(Console.ReadLine());

        accounts.Add(new BankAccount(name, accountNumber, initialBalance, $"Intial Deposit of {initialBalance}"));
    }

    static void ViewAllAccounts()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }

        foreach (var account in accounts)
        {
            Console.WriteLine(account);
        }
    }

    static void SearchAccountsByName()
    {
        Console.WriteLine("Enter the name to search:");
        string name = Console.ReadLine();

        List<BankAccount> searchResult = accounts.FindAll(a => a.Name.Contains(name));

        if (searchResult.Count > 0)
        {
            Console.WriteLine("Matching Accounts:");
            foreach (var account in searchResult)
            {
                Console.WriteLine($"Name: {account.Name}, Account Number: {account.AccountNumber}");
            }
        }
        else
        {
            Console.WriteLine("No accounts found.");
        }
    }


    static void SortAccountsByBalance()
    {
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");

        List<BankAccount> sortedAccounts = null;
        switch (Int32.Parse(Console.ReadLine()))
        {
            case 1:
                sortedAccounts = accounts.OrderBy(a => a.Balance).ToList();
                break;
            case 2:
                sortedAccounts = accounts.OrderByDescending(a => a.Balance).ToList();
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        Console.WriteLine("Sorted accounts:");
        foreach (var account in sortedAccounts)
        {
            Console.WriteLine(account);
        }
    }

    static void Deposit()
    {
        Console.Write("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter account number: ");
        int accountNumber = Int32.Parse(Console.ReadLine());
        try
        {
            BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber && a.Name == name);

            Console.Write("Enter amount to deposit: ");
            int depositAmount = Int32.Parse(Console.ReadLine());
            account.Balance += depositAmount;

            account.transcaction.Add($"{depositAmount} Deposited");

            Console.WriteLine($"Name: {account.Name}, Account Number: {account.AccountNumber}, Balance: {account.Balance}");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Following Account Does not exist\n");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter account number: ");
        int accountNumber = Int32.Parse(Console.ReadLine());
        try
        {
            BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber && a.Name == name);

            Console.Write("Enter amount to Withdraw: ");
            int withdrawAmount = Int32.Parse(Console.ReadLine());
            if ((account.Balance - withdrawAmount) > 1000)
            {
                account.Balance -= withdrawAmount;
                Console.WriteLine("Amount Withdrawn");
                account.transcaction.Add($"{withdrawAmount} Withdrawn");
            }
            else 
            {
                Console.WriteLine("You can only withdraw {0} to keep min balance", account.Balance - 1000);
            }

            Console.WriteLine($"Name: {account.Name}, Account Number: {account.AccountNumber}, Balance: {account.Balance}");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Following Account Does not exist\n");
        }
    }

    static void ViewAllTransaction()
    {
        Console.Write("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter account number: ");
        int accountNumber = Int32.Parse(Console.ReadLine());
        try
        {
            BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber && a.Name == name);
            if (account.transcaction.Count == 0)
            {
                Console.WriteLine("No transaction found.");
                return;
            }
            foreach (var t in account.transcaction)
            {
                Console.WriteLine(t);
            }
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Following Account Does not exist\n");
        }
    }

    static void ViewAccount()
    {
        Console.Write("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter account number: ");
        int accountNumber = Int32.Parse(Console.ReadLine());
        try
        {
            BankAccount account = accounts.Find(a => a.AccountNumber == accountNumber && a.Name == name);
            Console.WriteLine($"Name: {account.Name}, Account Number: {account.AccountNumber}, Balance: {account.Balance}");

        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Following Account Does not exist\n");
        }
    }

    static void getTotalBankBalance()
    {
        int totalBankBalance = 0;
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }

        foreach (var account in accounts)
        {
            totalBankBalance += account.Balance;
        }
        Console.WriteLine(totalBankBalance);
    }
}
