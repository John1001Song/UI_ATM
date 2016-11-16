using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Database
    {

        public static List<Account> accounts = new List<Account>();

        public Database ()
        {
            Account acc1 = new Account(1234, 5678, "Jack", AccountType.CHEQUING);
            Account acc2 = new Account(5678, 1234, "John", AccountType.SAVING);

            accounts.Add(acc1);
            accounts.Add(acc2);

            acc1.deposit(100);
            acc1.deposit(200);
            acc1.withdraw(50.50);
        }

        public static bool contains(int input)
        {
            foreach (Account acc in accounts)
            {
                if (acc.accountNumber == input)
                {
                    return true;
                }
            }
            return false;
        }

        public static Account ValidateAccout(int account_num)
        {
            foreach (Account acc in Database.accounts)
            {
                if (acc.accountNumber == account_num)
                {
                    return acc;
                }
            }

            return null;
        }


    }
}
