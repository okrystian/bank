using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Dane konta: {0}", account.AccountNumber);
            Console.WriteLine("Saldo: {0}", account.Balance);
            Console.WriteLine("Imię wlaściciela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine("Pesel właściciela: {0}", account.Pesel);
            Console.WriteLine();

        }
    }
}
