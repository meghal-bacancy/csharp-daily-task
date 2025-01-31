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

    public BankAccount(string name, int accountNumber, int initialBalance)
    {
        Name = name;
        AccountNumber = accountNumber;
        Balance = initialBalance;
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

        int accountNumber;
        Console.Write("Enter account number: ");
        accountNumber = Int32.Parse(Console.ReadLine());

        int initialBalance;
        Console.Write("Enter initial balance: ");
        initialBalance = Int32.Parse(Console.ReadLine());

        accounts.Add(new BankAccount(name, accountNumber, initialBalance));
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

    static void SortAccountsByBalance()
    {
        Console.WriteLine("Sort by:");
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
}