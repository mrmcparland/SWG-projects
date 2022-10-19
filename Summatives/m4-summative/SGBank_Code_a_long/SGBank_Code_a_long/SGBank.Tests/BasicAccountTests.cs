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
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account",100, AccountType.Free,250,false)]
        [TestCase("33333","Basic Account", 100, AccountType.Basic,-100,false)]
        [TestCase("33333","Basic Account",100, AccountType.Basic,250,true)]
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType,
            decimal amount, bool expectedResult)
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
        [TestCase("33333","Basic Account",1500,AccountType.Basic,-1000,1500,false)]
        [TestCase("33333","Basic Account",100,AccountType.Free,-100,100,false)]
        [TestCase("33333","Basic Account",100,AccountType.Basic,100,100,false)]
        [TestCase("33333","Basic Account",150,AccountType.Basic,-50,100,true)]
        [TestCase("33333","Basic Account",100,AccountType.Basic,-150,-60,true)]
        public void BasicAccountWithdrawRule(string accountNumber, string name, decimal balance, AccountType accountType,
            decimal amount,decimal newBalance, bool expectedResult)
        {
            IWithdraw testWithdraw = new BasicAccountWithdrawRule();
            Account testAccount = new Account();

            testAccount.AccountNumber = accountNumber;
            testAccount.Balance = balance;
            testAccount.Name = name;
            testAccount.Type = accountType;

            AccountWithdrawResponse response = testWithdraw.Withdraw(testAccount,amount);
            Assert.AreEqual(expectedResult, response.Success);

            if(response.Success == true)
            {
                Assert.AreEqual(newBalance, response.OldBalance);
            }
        }
    }
}
