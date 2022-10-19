using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Threading;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        
        private static Account _account = new Account
        {

            Name = "Basic Account",
            Balance = 100.00M,
            AccountNumber = "99999",
            Type = AccountType.Basic
        };
        
        public Account LoadAccount(string AccountNumber)
        {
            
                string path = @"C:\Users\mike\source\repos\online-net-mcparlandSWG\Summatives\m4-summative\SGBank_Code_a_long\SGBank_Code_a_long\SGBank.Data\bin\Debug\Accounts.txt";

                string[] rows = File.ReadAllLines(path);
                Account txtFileAccount = new Account();

            List<string> acctMem = new List<string>();
            
            for (int i = 1; i < rows.Length; i++)
                {
                    acctMem.Add(rows[i]);
                    string[] columns = rows[i].Split(',');
                    txtFileAccount.AccountNumber = columns[0];

                    if (txtFileAccount.AccountNumber == AccountNumber)
                    {
                        txtFileAccount.AccountNumber = columns[0];
                        txtFileAccount.Name = columns[1];
                        txtFileAccount.Balance = Convert.ToDecimal(columns[2]);
                        if (columns[3] == "F")
                        {
                            txtFileAccount.Type = AccountType.Free;
                        }
                        if (columns[3] == "B")
                        {
                            txtFileAccount.Type = AccountType.Basic;
                        }
                        if (columns[3] == "P")
                        {
                            txtFileAccount.Type = AccountType.Premium;
                        }
                        break;
                    }
                    if (txtFileAccount.AccountNumber != AccountNumber)
                    {
                        continue;
                    }
                }
                //needs to match a given account number to what is in the flat file
                if (AccountNumber == txtFileAccount.AccountNumber)
                {
                    
                    return txtFileAccount;

                }
                else
                {

                    return null;
                }
            
            
        }

        public void SaveAccount(Account account)
        {
            string path = @"C:\Users\mike\source\repos\online-net-mcparlandSWG\Summatives\m4-summative\SGBank_Code_a_long\SGBank_Code_a_long\SGBank.Data\bin\Debug\Accounts.txt";
            string[] rows = File.ReadAllLines(path);
            File.WriteAllText(path, string.Empty);
            Account txtFileAccount = new Account();
            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                using (StreamWriter writer = File.AppendText(path))
                {
                    if(account.AccountNumber == columns[0])
                    {
                        columns[2] = account.Balance.ToString();
                    }
                    writer.WriteLine(columns[0]+"," + columns[1]+","+columns[2]+","+columns[3]);
                }
            }
            
        }
    }
}
