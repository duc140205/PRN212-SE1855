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