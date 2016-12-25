using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "A valid account repository must be supplied.");
            _repository = repository;
        }

        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = _repository.GetByName(uniqueAccountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);
                }
                catch (DomainException domainException)
                {
                    // exception class declare constractor as (string, exception)
                    throw new ServiceException("An exception was thrown by a domain object", domainException);
                }
                
            }
                
        }
    }
}
