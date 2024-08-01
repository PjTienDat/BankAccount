using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBank;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }
    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.Now, "Áp dụng lãi xuất hàng tháng");
        }
    }
}   
