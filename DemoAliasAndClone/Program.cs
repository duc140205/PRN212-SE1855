using System.Text;
using DemoAliasAndClone;

Console.OutputEncoding=Encoding.UTF8;

Student s1 = new Student();
s1.Id = 1;
s1.Name = "Mon";


Student s2 = new Student();
s2.Id = 2;
s2.Name = "Hehe";

//Lúc này trên thanh RAM sẽ cấp phát 2 ô nhớ
// cho s1 và s2 quản lý
//==> s1 đổi giá trị ko liên quan gì tới s2 vì
// s1 và s2 đang quản lý 2 ô nhớ khác nhau
s1 = s2;
//ta viết lệnh: s1=s2
//Tuy nhiên về bản chất nó hoạt động như sau:
//s1 trỏ tới vùng nhớ mà s2 đang quản lý
// chứ không phải s1 bằng s2
//có 2 tình huống xảy ra:
//(1) ô nhớ bên s2 giờ có thêm s1 quản lý ==> alias (>=2 đối tượng quản lý)
//      chỉ cần 1 đối tượng đổi thì các đối tượng khác đều bị đổi
s2.Name = "Hoho";
Console.WriteLine("s2 đổi tên, vậy s1 có tên là gì?");
Console.WriteLine(s1.Name);

//(2) ô nhớ bên s1 giờ không còn ai quản lý nữa
// thì lúc này HĐH tự động thu hồi ô nhớ: Automatic Garbage Collection
// tức là ta ko thể truy xuất để lấy lại giá trị của s1 có id = 1, name= "Mon"



Product p1 = new Product()
{
    Id = 1, Name = "P1", Quantity = 10, Price = 20
};

Product p2 = new Product()
{
    Id = 2, Name = "P2", Quantity = 20, Price = 15
};

p1 = p2;

p2.Name = "Thuốc trị hôi cánh";
p2.Price = 80;

Console.WriteLine("Thông tin của P1:");
Console.WriteLine(p1);


Product p3 = new Product() { Id = 3, Name = "P3", Quantity = 30, Price = 50 };

Product p4 = new Product() { Id = 4, Name = "P4", Quantity = 40, Price = 90 };

Product p5 = p3;
p3 = p4;
//Hỏi ô nhớ cấp phát cho p3 có bị thu hồi không
// Hem, vì p5 vẫn đang quản lý ô nhớ đó

Product p6 = p4.clone();
//sao chép toàn bộ dữ liệu trong ô nhớ mà p4 đang quản lý
// sang ô nhớ mới và giao cho p6 quản lý
//lúc này không phải là ALIAS vì p6 và p4 đang quản lý 2 ô nhớ khác nhau
Console.WriteLine("Data of Product 6:");
Console.WriteLine(p6);
Console.WriteLine("Data of Product 4:");
Console.WriteLine(p4);
p4.Name = "Lando NoWin";
Console.WriteLine("Data of Product 6:");
Console.WriteLine(p6);
Console.WriteLine("Data of Product 4:");
Console.WriteLine(p4);

