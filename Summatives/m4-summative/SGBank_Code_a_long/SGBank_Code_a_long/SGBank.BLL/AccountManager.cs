using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Responses;
using SGBank.BLL.DepositRules;
using System.Runtime.InteropServices;
using SGBank.BLL.WithdrawRules;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public AccountLookupResponse LookupAccount (string AccountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(AccountNumber);
            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountNumber} is not a valid account";
            }
            else
                response.Success = true;
            return response;

        }
        public AccountDepositResponse Deposit (string AccountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            response.Account = _accountRepository.LoadAccount(AccountNumber);
            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountNumber} is not a valid account";
                return response;    
            }
            else
                response.Success = true;

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }

            return response;
        }
        public AccountWithdrawResponse Withdraw (string AccountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            response.Account = _accountRepository.LoadAccount(AccountNumber);
            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountNumber} is not a valid account";
                return response;
            }
            else
                response.Success = true;

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);
            if(response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }
    }
}
