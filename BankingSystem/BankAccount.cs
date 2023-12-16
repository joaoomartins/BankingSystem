using System;

//Propriedades
public class BankAccount
{
    public int AccountNumber { get; }
    public string AccountName { get; }
    public double Balance { get; private set; }

    public BankAccount(int accountnumber, string accountName, double balance)
    {
        AccountNumber = accountnumber;
        AccountName = accountName;
        Balance = balance;
    }

    //Métodos

    public void Deposit(double total)
    {
        if (total > 0)
        {
            Balance += total;

            Console.WriteLine($"Depositou {total} na conta nº {AccountNumber} de {AccountName}");
        }
        else
        {
            Console.WriteLine("Valor inválido!");
        }
    }

    public void WithDraw(double total)
    {
        if (total > 0 && total <= Balance)
        {
            Balance -= total;
            Console.WriteLine($"Foi retirado {total} da conta nº {AccountNumber} de {AccountName}. Novo saldo: {Balance}");
        }
        else
        {
            Console.WriteLine("Saldo indesponível/ou valor inválido!");
        }
    }

}