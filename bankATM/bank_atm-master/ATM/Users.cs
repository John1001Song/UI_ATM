using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    // person.cs
    class Users
    {
        public string name
        {
            get;
            private set;
        }

        public string accountNumber
        {
            get;
            private set;
        }

        public string pinNumber
        {
            get; set;
        }

        public List<Account> accounts
        {
            get;
            private set;
        }

        public int numAttempts
        {
            get;
            private set;
        }

        public static int maxNumberAttempt = 3;

        public bool verifyPinNumber(string input)
        {
            if (input != pinNumber)
            {
                numAttempts++;
                return false;
            }

            return true;
        }

        public Users(string name, string accountNumber, string pinNumber)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.pinNumber = pinNumber;
            accounts = new List<Account>();
            numAttempts = 0;
        }

        public void addNewAccount(Account acc)
        {
            this.accounts.Add(acc);
        }

        
        public void withdrawFromAccount(float number, int accountNumber, DateTime date)
        {

        }



    }
}
