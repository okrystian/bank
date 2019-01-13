using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AccountManager
    {
        private IList<Account> _accounts;

        public AccountManager()
        {
            _accounts = new List<Account>();
        }

        public SavingAccount CreateSavingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
            SavingAccount account = new SavingAccount(id, firstName, lastName, pesel);
            _accounts.Add(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);
            _accounts.Add(account);

            return account;
        }
        public IEnumerable<Account> GetAllAcountsFor(string firstName, string lastName, long pesel)
        {
            
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        }
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | Pesel: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
            //alternatywa niżej
            /*List<string> tmp = new List<string>();
            foreach (var item in _accounts)
            {
                string customerData = string.Format("Imię: {0} | Nazwisko: {1} | Pesel: {2}", item.FirstName, item.LastName, item.Pesel);
                if (!tmp.Contains<string>(customerData))
                {
                    tmp.Add(customerData);
                }
            }

            return tmp;
            */
        }
        
        public Account GetAccount(string accountNo)
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
        }

        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }
        public void CloseMoth()
        {
            foreach (SavingAccount account in _accounts.Where(x => x is SavingAccount))
            {
                account.AddInterest(0.04M);
            }
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }

        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }

    }
}
