/*Đề tài:
 * Nhập vào 1 số >=0, nếu nhập sai quy tắc
 * thì yêu cầu nhập lại khi nào đúng mới dừng
 * Nếu nhập đúng thì tính giai thừa của số này
 */
using System.Text;

Console.OutputEncoding=Encoding.UTF8;
int n = -1; // pretend to input wrong
while (n < 0) // bat nhap lai cho toi khi nao dung
{
    Console.WriteLine("Nhập n>= 0");
    string input = Console.ReadLine();
    if (int.TryParse(input, out n) == true)
    {// khi vào đây thì n là số, nhưng có thể <0
        if (n >= 0)// correct input
            break;//không bắt nhập nữa
        else
            Console.WriteLine("Tui đã nói là nhập >=0 mà");
    }
    else
    {
        Console.WriteLine("Lựu đạn quá cha, nhập số mà");
    }
        
}

int gt = 1;
for(int i =1;  i <= n; i++)
    gt = gt * i;
Console.WriteLine($"{n}! = {gt}");