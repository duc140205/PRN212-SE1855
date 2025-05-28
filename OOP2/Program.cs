using System.Text;
using OOP2;

Console.OutputEncoding=Encoding.UTF8;
FulltimeEmployee obama = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Barac Obama",
    Birthday = new DateTime(1960, 11, 25)
};
Console.WriteLine("---Thông tin của OBAMA---");
Console.WriteLine($"Id={obama.Id}");
Console.WriteLine("Name = "+ obama.Name);
Console.WriteLine("IdCard = "+obama.IdCard);
Console.WriteLine("Year of birth = " + obama.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Salary = " + obama.calSalary());


PartimeEmployee trump = new PartimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Donald Trump",
    Birthday = new DateTime(1946, 6, 14),
};
trump.WorkingHour = 3;
Console.WriteLine("---Thông tin của TRUMP---");
Console.WriteLine($"Id={trump.Id}");
Console.WriteLine("Name = " + trump.Name);
Console.WriteLine("IdCard = " + trump.IdCard);
Console.WriteLine("Year of birth = " + trump.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Salary = " + trump.calSalary());

Console.WriteLine("----Sử dụng toString()----");
Console.WriteLine(obama);
Console.WriteLine(trump);
