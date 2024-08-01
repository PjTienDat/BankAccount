using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Text;

using AccountBank;

Console.OutputEncoding = Encoding.UTF8;
var account = new BankAccount("Nguyễn Tiến Đạt",20000);
Console.WriteLine($"Tài khoản {account.Number} được tạo cho {account.Owner} với số dư là: {account.Balance}$");

account.MakeWithdrawal(300m, DateTime.Now, "Tiền thức ăn");
account.MakeDeposit(100m, DateTime.Now, "Tiền công");
Console.WriteLine(account.GetAccountHistory());
Console.WriteLine("Số dư là: {0}", account.Balance);
try
{
    var invalidAccount = new BankAccount("Không hợp lệ", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Ngoại lệ bị bắt khi tạo tài khoản có số dư âm");
    Console.WriteLine(e.ToString());
}
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Rút tiền quá mức");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Ngoại lệ bị bắt khi cố gắng rút tiền");
    Console.WriteLine(e.ToString());
}
Console.ReadKey();

Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("Thẻ quà tặng");
        var giftCard = new GiftCardAccount("thẻ tặng quà", 200, 80);
        giftCard.MakeWithdrawal(20, DateTime.Now, "mua cà phê đắt tiền");
        giftCard.MakeWithdrawal(50, DateTime.Now, "mua đồ tạp hóa");
        giftCard.PerformMonthEndTransactions();
        giftCard.MakeDeposit(27.50m, DateTime.Now, "thêm một số tiền chi tiêu bổ sung");
        Console.WriteLine(giftCard.GetAccountHistory());
        Console.WriteLine("Số dư là: {0}$", giftCard.Balance);
        Console.ReadKey();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("Tiền tiết kiệm");
        var savings = new InterestEarningAccount("Tài khoản tiết kiệm", 10000);
        savings.MakeDeposit(750, DateTime.Now, "Tiết kiệm tiền");
        savings.MakeDeposit(1250, DateTime.Now, "Thêm nhiều khoản tiết kiệm");
        savings.MakeWithdrawal(250, DateTime.Now, "Cần thanh toán hóa đơn hàng tháng");
        savings.PerformMonthEndTransactions();
        Console.WriteLine(savings.GetAccountHistory());
        Console.WriteLine("Số dư là: {0}$", savings.Balance);
        Console.ReadKey();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("Tiền tín dụng");
        var lineOfCredit = new LineOfCreditAccount("Hạn mức tín dụng", 0, 2000);
        lineOfCredit.MakeWithdrawal(1000, DateTime.Now, "Đề nghị lấy trước hàng tháng");
        lineOfCredit.MakeDeposit(50, DateTime.Now, "Hoàn lại ít tiền");
        lineOfCredit.MakeWithdrawal(500, DateTime.Now, "Quỹ khẩn cấp để sửa chữa");
        lineOfCredit.MakeDeposit(150, DateTime.Now, "Phục hồi sau sửa chữa");
        lineOfCredit.PerformMonthEndTransactions();
        Console.WriteLine(lineOfCredit.GetAccountHistory());
        Console.WriteLine("Số dư là: {0}$", lineOfCredit.Balance);
        Console.ReadKey();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine($"Tổng số tiền hiện có trong tài khoản: {lineOfCredit.Balance + giftCard.Balance + savings.Balance + account.Balance}$");
        Console.ReadKey();
