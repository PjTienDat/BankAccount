using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBank
{

   public class BankAccount
    {
        public string Number { get; }

        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            } 

        }
        
        private static int s_accountNumberSeed = 11052003;
        private readonly decimal _minimumBalance;
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            Owner = name;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Số dư ban đầu");
        }

        private readonly List<Transaction> _allTransactions = new List<Transaction>(); 
      

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Bạn phải có số dư dương trong tài khoản");
            }

            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit); 
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Số tiền rút phải dương");
            }
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction? withdrawal = new(-amount, date, note);
            _allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                _allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Không đủ tiền cho lần rút tiền này");
                
            }
            else
            {
                return default;
            }
        }
        
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Thời gian\tTổng    \tMục chi tiêu     \t");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t{item.Notes}");
            }
            return report.ToString();
        } 
        public virtual void PerformMonthEndTransactions() { }
        
       
       
        }
}