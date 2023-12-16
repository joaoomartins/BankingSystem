using System;

public class Transaction
{
    public string Type { get; }
    public double Amount { get; }
    public BankAccount Account { get; set; }

    public Transaction(string type, double amount, BankAccount account)
    {
        Type = type;
        Amount = amount;
        Account = account;
    }
 }