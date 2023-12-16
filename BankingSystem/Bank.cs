using System;
using System.Transactions;

public class Bank
{
    //lista (BankAccount)
    public List<BankAccount> accounts = new List<BankAccount>();

    //lista (transaction)
    public List<Transaction> transactions = new List<Transaction>();

    public void AddAccount(BankAccount account)
    {
        accounts.Add(account);
    }

    public bool transactionStatus(BankAccount account, double amount, bool transactionType)
    {
        if (accounts.Contains(account))
        {
            if (transactionType) // true = deposito ; false = levantamento
            {
                if (amount > 0)
                {
                    account.Deposit(amount);
                    transactions.Add(new Transaction("Depositou", amount, account));
                    return true; // deposito validado
                }
                else
                {
                    Console.WriteLine("Valor de depósito inválido");
                }
            }
            else // levantamento
            {
                if (amount > 0 && amount <= account.Balance)
                {
                    account.WithDraw(amount);
                    transactions.Add(new Transaction("Levantou", amount, account));
                    return true; // levantamento validado
                }
                else
                {
                    Console.WriteLine("Valor inválido ou saldo insuficiente!");
                }
            }
        }
        else
        {
            Console.WriteLine("Conta não encontrada!");
        }

        return false; // transação falhou
    }
}