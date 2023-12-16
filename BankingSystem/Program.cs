using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            List<BankAccount> accounts = new List<BankAccount>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Menu do Banco:");
                Console.WriteLine("1. Criar Conta");
                Console.WriteLine("2. Depósitos");
                Console.WriteLine("3. Levantamentos");
                Console.WriteLine("4. Ver Contas");
                Console.WriteLine("5. Ver Transações");
                Console.WriteLine("6. Sair");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Insira o nome do titular da conta:");
                        string accountName = Console.ReadLine();
                        Console.WriteLine("Insira o montante inicial:");
                        double balance = double.Parse(Console.ReadLine());

                        BankAccount newAccount = new BankAccount(accounts.Count + 1, accountName, balance);
                        accounts.Add(newAccount);
                        bank.AddAccount(newAccount);

                        Console.WriteLine($"Conta nº {newAccount.AccountNumber} de {newAccount.AccountName} criada com sucesso!");
                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Introduza o número da conta:");
                        int depositAccountNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduza o montante a depositar:");
                        double depositAmount = double.Parse(Console.ReadLine());

                        BankAccount depositAccount = accounts.FirstOrDefault(account => account.AccountNumber == depositAccountNumber);

                        if (depositAccount != null)
                        {
                            bool depositStatus = bank.transactionStatus(depositAccount, depositAmount, true);

                            if (depositStatus)
                            {
                                Console.WriteLine("Depósito Confirmado!");
                            }
                            else
                            {
                                Console.WriteLine("Falha ao realizar o depósito. Verifique o nº de conta ou o montante!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;



                    case 3:
                        Console.WriteLine("Introduza o número da conta:");
                        int withdrawAccountNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduza o montante a levantar:");
                        double withdrawAmount = double.Parse(Console.ReadLine());

                        BankAccount withdrawAccount = accounts.Find(account => account.AccountNumber == withdrawAccountNumber);

                        if (withdrawAccount != null)
                        {
                            bool withdrawStatus = bank.transactionStatus(withdrawAccount, withdrawAmount, false);

                            if (withdrawStatus)
                            {
                                Console.WriteLine($"Levantamento confirmado!");
                            }
                            else
                            {
                                Console.WriteLine("Falha ao realizar o levantamento. Verifique o nº de conta ou o montante!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;


                    case 4:
                        Console.WriteLine("Contas disponíveis:");

                        foreach (var account in accounts)
                        {
                            Console.WriteLine($"Número da Conta: {account.AccountNumber}");
                            Console.WriteLine($"Nome do Titular: {account.AccountName}");
                            Console.WriteLine($"Saldo: {account.Balance}");
                            Console.WriteLine();
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Transações efetuadas:");
                        Console.WriteLine("Introduza o nº da conta:");
                        int accountNumberSearch = int.Parse(Console.ReadLine());

                        BankAccount selectedAccount = accounts.FirstOrDefault(account => account.AccountNumber == accountNumberSearch);

                        if (selectedAccount != null)
                        {
                            Console.WriteLine($"Transações da conta nº {selectedAccount.AccountNumber} de {selectedAccount.AccountName}:");
                            Console.WriteLine("");

                            foreach (var transaction in bank.transactions)
                            {
                                if (transaction.Account == selectedAccount)
                                {
                                    Console.WriteLine($"Tipo de transação: {transaction.Type}");
                                    Console.WriteLine($"Montante: {transaction.Amount}");
                                    Console.WriteLine();
                                }
                            }

                            if (!bank.transactions.Any(transaction => transaction.Account == selectedAccount))
                            {
                                Console.WriteLine("Nenhuma transação efetuada nesta conta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }

                        Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;


                    case 6:
                        Console.WriteLine("A sair...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine() ;
                        break;
                        return;
                }
                if (option == 6)
                {
                    break;
                }
            }
        }
    }
}
