using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBank;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }
    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Tính lãi hàng tháng ");
        }
    }
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn? new Transaction(-20, DateTime.Now, "Áp dụng phí thấu chi") : default;
}

