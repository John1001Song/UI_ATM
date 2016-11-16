using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public enum AccountType { CHEQUING, SAVING }

    public enum LogType { DEPOSIT, WITHDRAWAL}

    class LogEntry
    {
        public DateTime date { get; }
        public double amount { get; }
        public LogType logType { get; }
        public LogEntry(DateTime date, double amount, LogType logtype)
        {
            this.date = date;
            this.amount = amount;
            this.logType = logtype;
        }

        public override string ToString()
        {
            return String.Format("log: {0}${1} on date: {2}({3})\n",
                                 amount < 0 ? "-" : "",
                                 Math.Abs(amount).ToString(),
                                 this.date.ToString(),
                                 this.logType.ToString());
        }
    }

    class Account
    {

        public int accountNumber { get; set; }
        public int pin { get; }
        public double balance { get; set; }
        public AccountType type { get; private set; }
        public List<LogEntry> logs { get; private set; }
        public string name { get; }

        public Account(int number, int pin, string name, AccountType type)
        {
            this.accountNumber = number;
            this.type = type;
            balance = 0;
            this.pin = pin;
            this.name = name;
            this.logs = new List<LogEntry>();
        }

        public void deposit(double number, DateTime date)
        {
            double newBalance = this.balance + number;
            LogEntry newLog = new LogEntry(date, number, LogType.DEPOSIT);
            this.balance = newBalance;
            this.logs.Add(newLog);
        }

        public void deposit(double number)
        {
            deposit(number, DateTime.Now);
        }
    
        public void withdraw(double number, DateTime date)
        {
            double newBalance = this.balance - number;

            LogEntry newLog = new LogEntry(date, number, LogType.WITHDRAWAL);
            this.balance = newBalance;
            this.logs.Add(newLog);
        }

        public void withdraw(double number)
        {
            withdraw(number, DateTime.Now);
        }

        public void transfer(double number, Account toAccount, DateTime date)
        {
            this.withdraw(number, date);
            toAccount.deposit(number, date);
        }

        public void transfer(double number, Account toAccount)
        {
            transfer(number, toAccount, DateTime.Now);
        }

    }

}
