using System.Text;
using OOP2;
using OOP2_Reuse_As_Library;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee e1 = new FulltimeEmployee();
e1.Id = 1;
e1.Name = "Mon";
e1.IdCard = "123";
e1.Birthday = new DateTime(2005, 2, 14);
Console.WriteLine("------ E1 Info ---");
Console.WriteLine(e1);
Console.WriteLine("==>Age=" + e1.TinhTuoi());
