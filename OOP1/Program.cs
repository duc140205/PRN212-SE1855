using OOP1;
using System.Text;

Console.OutputEncoding=Encoding.UTF8;
//Tạo 1 đối tượng danh mục:
Category c1=new Category();
//Gán giá trị cho các thuộc tính:
c1.Id = 1;
c1.Name = "Nước mắm";
//gọi hàm xuất dữ liệu:
c1.PrintInfor();

//Khởi tạo 1 Nhân viên :
Employee e1=new Employee();
e1.Id = 1;//gọi setter Property Id
e1.Id_Card="00123";//gọi setter Property Id_Card
e1.Name = "Tèo";
e1.Email = "teo@gmail.com";
e1.Phone = "0912345678";
//Gọi hàm xuất thông tin:
e1.PrintInfor();
//Ta có thể truy suất theo từng Property để lấy giá trị của thuộc tính:
Console.WriteLine("---------");
Console.WriteLine("Id của e1="+e1.Id);//gọi getter Property Id
Console.WriteLine($"Name của e1={e1.Name} ");//gọi getter Property Name

//Ta cũng có thể khởi tạo đối tượng và các giá trị của thuộc tính như sau:
Employee e2 = new Employee()
{
    Id=2,
    Id_Card="0055",
    Name="Tý",
    Email="ty@gmail.com",
    Phone="0989023456"
};
Console.WriteLine("---E2---");
e2.PrintInfor();

Console.WriteLine("=======================");
Employee e3 = new Employee(3,"0088","Tám","tam@gmail.com","0988888888");
//gọi hàm xuất thông tin:
e3.PrintInfor();
//hoặc tự động gọi tostring() khi đối tượng được xuất ra màn hình:
Console.WriteLine(e3);//tự động hàm ToString()

//thử dùng Constructor mặc định (0 có đối số):
Employee e4 = new Employee();
Console.WriteLine(e4);

//Tạo đối tượng Customer:
Customer cus1 = new Customer()
{
    Id = "CUS1",
    Name = "Nguyễn Thị Lung Linh",
    Email = "lunglinh@hotmail.com",
    Phone = "0999239453",
    Address = "Số 1 Đinh Tiên Hoàng - Quận 1 - HCM"
};
cus1.PrintInfor();
cus1.Address = "Số 2 Đinh Bộ Lĩnh - Bình Thạnh - HCM";
cus1.Phone = "023534546";
Console.WriteLine("Thông tin Customer sau khi chỉnh sửa:");
cus1.PrintInfor();