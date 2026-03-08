using System;

class BankAccount
{
    protected double balance;
    public int AccountNumber { get; private set; }

    public BankAccount(int accNo, double initialBalance)
    {
        AccountNumber = accNo;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        balance -= amount;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Account: {AccountNumber}, Balance: {balance}");
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(int accNo, double bal) : base(accNo, bal) { }

    public void CalculateInterest()
    {
        balance += balance * 0.04;
    }
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(int accNo, double bal) : base(accNo, bal) { }
}
class Program
{
    static void Main(string[] args)
    {
        SavingsAccount sa = new SavingsAccount(101, 5000);
        sa.Deposit(2000);
        sa.CalculateInterest();
        sa.Display();

        CheckingAccount ca = new CheckingAccount(102, 3000);
        ca.Withdraw(500);
        ca.Display();
    }
}