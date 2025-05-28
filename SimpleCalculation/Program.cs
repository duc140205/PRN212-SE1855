using System.Text;

void do_calculate(double a, double b, String op)
{
    switch (op)
    {
        case "+":
            Console.WriteLine("{0}+{1}+{2}", a, b, a + b);
            break;
        case "-":
            Console.WriteLine("{0}-{1}={2}", a, b, a - b);
            break;
        case "*":
            Console.WriteLine("{0}*{1}={2}", a, b, a * b);
            break;
        case "/":   
            Console.WriteLine("{0}/{1}={2}", a, b, a / b);
            break;
        default:
            Console.WriteLine("Nhập lụi hả bạn!!!");
            break;
    }
}
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("SIMPLE CALCULATION!!!");
Console.WriteLine("Nhập số a:");
double a = Double.Parse(Console.ReadLine());
Console.WriteLine("Nhập số b:");
double b = Double.Parse(Console.ReadLine());
Console.WriteLine("Nhập phép toán(+,-,*,/)");
string op = Console.ReadLine();
do_calculate(a, b, op);
Console.ReadLine();