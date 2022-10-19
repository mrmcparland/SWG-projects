using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("54321","Premium Account",100,AccountType.Free,250,false)]
        [TestCase("54321", "Premium Account",100,AccountType.Premium,-100,false)]
        [TestCase("54321", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber,string name, decimal balance
            ,AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit testDeposit = new NoLimitDepositRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Balance = balance;
            testAccount.Name = name;
            testAccount.Type = accountType;

            AccountDepositResponse response = testDeposit.Deposit(testAccount, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
        [TestCase("54321","Premium Account",1500,AccountType.Premium,-1000,1500,true)]
        [TestCase("54321","Premium Account",100,AccountType.Free,-100,100,false)]
        [TestCase("54321","Premium Account",100,AccountType.Premium,100,100,false)]
        [TestCase("54321","Premium Account",150,AccountType.Premium,-50,100,true)]
        [TestCase("54321","Premium Account",150, AccountType.Premium,-150,-60,true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance
            ,AccountType accountType, decimal amount, decimal newBalance,bool expectedResult)
        {
            IWithdraw testWithdraw = new PremiumAccountWithdrawRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Balance = balance;
            testAccount.Name = name;
            testAccount.Type = accountType;

            AccountWithdrawResponse response = testWithdraw.Withdraw(testAccount, amount);
            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, response.OldBalance);
            }
        }
    }
}
