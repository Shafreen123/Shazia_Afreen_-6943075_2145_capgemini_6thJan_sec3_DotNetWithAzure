using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        BankAccount account = new BankAccount(1000m);
        account.Deposit(500m);
        Assert.AreEqual(1500m, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        BankAccount account = new BankAccount(1000m);
        string actualMessage = "";

        try
        {
            account.Deposit(-200m);
        }
        catch (Exception ex)
        {
            actualMessage = ex.Message;
        }

        Assert.AreEqual("Deposit amount cannot be negative", actualMessage);
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        BankAccount account = new BankAccount(1000m);
        account.Withdraw(300m);
        Assert.AreEqual(700m, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        BankAccount account = new BankAccount(500m);
        string actualMessage = "";

        try
        {
            account.Withdraw(800m);
        }
        catch (Exception ex)
        {
            actualMessage = ex.Message;
        }

        Assert.AreEqual("Insufficient funds.", actualMessage);
    }
}