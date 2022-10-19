using SGBank.UI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("SG Banking Application");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Lookup an account.");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");

                Console.WriteLine("\nQ to quit");
                Console.Write("\n Enter selection: ");

                string userinput = Console.ReadLine();

                switch(userinput)
                {
                    case "1":
                        AccountLookupWorkFlow lookupWorkFlow = new AccountLookupWorkFlow();
                        lookupWorkFlow.Execute();
                        break;
                    case "2":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }
            }
        }
    }
}
