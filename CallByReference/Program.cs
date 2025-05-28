using System.Text;

void ham1(int n) // not changing the value of n when out
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
Console.OutputEncoding = Encoding.UTF8;
int n = 5;
Console.WriteLine($"n trước khi vào hàm = {n}");
ham1(n);
Console.WriteLine($"n sau khi vào hàm = {n}");

void ham2(ref int n)   // change the value of n when out
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
Console.WriteLine("----------REF----------");
n = 5;
Console.WriteLine($"n trước khi vào hàm = {n}");
ham2(ref n);
Console.WriteLine($"n sau khi vào hàm = {n}");
//ref: must declare the value for the variable before call
//int m;
//ham2(ref m); //error 'cause line 24 doesn't have value for m 

void ham3(out int n)
{
    n = 8;
}