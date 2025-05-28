using System.Text;

void first_degree_solution(double a, double b)
{
    if (a == 0 && b == 0)
        Console.WriteLine("Vô số nghiệm");
    else if (a == 0 && b != 0)
        Console.WriteLine("Vô nghiệm");
    else
        Console.WriteLine("X={0}", -b / a);
}

void quadratic_equation_solution(double a, double b, double c)
{
    if(a == 0)
        first_degree_solution(b, c);
    else
    {
        var delta = Math.Pow(a, 2) - 4 * a * c;
        if (delta < 0)
        {
            Console.WriteLine("Vô nghiệm");
        }
        else if (delta == 0)
        {
            Console.WriteLine("X1=X2={0}", -b/(2*a));
        }
        else
        {
             var x1 = (-b - Math.Sqrt(delta))/(2*a);
             var x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine("X1={0}\nX2={1}", x1, x2);    
        }
    }
}

Console.OutputEncoding=Encoding.UTF8;
Console.WriteLine("Phương trình bậc 2: ax^2+bx+c=0");
Console.WriteLine("Hệ số a:");
var a = double.Parse(Console.ReadLine());
Console.WriteLine("Hệ số b:");
var b = double.Parse(Console.ReadLine());
Console.WriteLine("Hệ số c:");
var c = double.Parse(Console.ReadLine());
quadratic_equation_solution(a, b, c);
Console.ReadLine();