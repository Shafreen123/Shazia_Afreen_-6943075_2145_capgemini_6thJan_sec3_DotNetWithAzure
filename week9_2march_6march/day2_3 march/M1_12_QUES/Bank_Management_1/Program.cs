using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public interface IBankAccountOperation
{
    void Deposit(decimal d);
    void Withdraw(decimal d);
    decimal ProcessOperation(string message);
}

//Create BankOperations class by implementing IBankAccountOperation interface
class BankOperations : IBankAccountOperation
{
    decimal balance = 0;

    public void Deposit(decimal d)
    {
        balance += d;
    }

    public void Withdraw(decimal d)
    {
        if (d <= balance)
            balance -= d;
    }

    public decimal ProcessOperation(string message)
    {
        message = message.ToLower();

        //extract number from message
        decimal amount = 0;
        Match m = Regex.Match(message, @"\d+");
        if (m.Success)
        {
            amount = Convert.ToDecimal(m.Value);
        }

        //check operation
        if (message.Contains("deposit") || message.Contains("invest") || message.Contains("transfer"))
        {
            Deposit(amount);
        }
        else if (message.Contains("withdraw") || message.Contains("pull"))
        {
            Withdraw(amount);
        }
        else if (message.Contains("balance") || message.Contains("money"))
        {
            return balance;
        }

        return balance;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        List<string> inputs = new List<string>();

        for (int i = 0; i < n; i++)
        {
            inputs.Add(Console.ReadLine());
        }

        BankOperations opt = new BankOperations();

        foreach (var item in inputs)
        {
            Console.WriteLine(opt.ProcessOperation(item));
        }
    }
}