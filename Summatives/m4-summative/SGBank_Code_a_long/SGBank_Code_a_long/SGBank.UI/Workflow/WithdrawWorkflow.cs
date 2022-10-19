﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflow
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber,amount);

            if(response.Success)
            {
                Console.WriteLine("Withdrawal completed!");
                Console.WriteLine($"Account Number: { response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: { response.OldBalance:c}");
                Console.WriteLine($"Amount Withdrawn: { amount:c}");
                Console.WriteLine($"New Balance: { response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(response.Message);
                
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
