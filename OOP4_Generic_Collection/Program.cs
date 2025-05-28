using System.Text;
using OOP2;

Console.OutputEncoding=Encoding.UTF8;
/*
 * Sử dụng Generic List để quản lý nhân sự
 * thực hiện đầy đủ tính năng CRUD
 * C-Create --> thêm mới nhân sự
 * R->Read/Retrieve --> Đọc: Truy vấn, tìm kiếm, sắp xếp,...
 * U->Update --> Chỉnh sửa dữ liệu
 * D->Delete --> xóa dữ liệu
 */

//Câu 1 - C (Create)
// Dùng List để tạo 5 Employees, trong đó 4 Employee là chính thức 
// Và 1 Employee là thời vụ
List<Employee> employees =  new List<Employee>();
FulltimeEmployee e1 = new FulltimeEmployee();
e1.Id = 1;
e1.Name = "Name 1";
e1.IdCard = "Card 1";
e1.Birthday = new DateTime(1990, 1, 1);
employees.Add(e1);

FulltimeEmployee e2 = new FulltimeEmployee();
e2.Id = 2;
e2.Name = "Name 2";
e2.IdCard = "Card 2";
e2.Birthday = new DateTime(1991, 2, 2);
employees.Add(e2);

FulltimeEmployee e3 = new FulltimeEmployee();
e3.Id = 3;
e3.Name = "Name 3";
e3.IdCard = "Card 3";
e3.Birthday = new DateTime(1992, 3, 3);
employees.Add(e3);

FulltimeEmployee e4 = new FulltimeEmployee();
e4.Id = 4;
e4.Name = "Name 4";
e4.IdCard = "Card 4";
e4.Birthday = new DateTime(1993, 4, 4);
employees.Add(e4);

PartimeEmployee e5 = new PartimeEmployee();
e5.Id = 5;
e5.Name = "Name 5";
e5.IdCard = "Card 5";
e5.WorkingHour = 2;
e5.Birthday = new DateTime(1994, 5, 5);
employees.Add(e5);



//Câu 2: R -> Xuất toàn bộ nhân sự:
//cách xuất 1:
Console.WriteLine("----Danh sách nhân sự - Cách 1----");
employees.ForEach(e => Console.WriteLine(e) );  
Console.WriteLine("----Danh sách nhân sự - Cách 2----");
foreach (var e in employees)
    Console.WriteLine(e);

//Câu 3: R -> Lọc ra nhân sự chính thức và tính tổng lương
//Cach 1 Dung cac extension method cua he thong
List<FulltimeEmployee> fe_list =  employees.OfType<FulltimeEmployee>().ToList(); 

// Sử dụng phương thức OfType<T>() để lọc ra tất cả các phần tử trong danh sách employees
// có kiểu FulltimeEmployee. Kết quả trả về là một IEnumerable<FulltimeEmployee>,
// sau đó chuyển thành List<FulltimeEmployee> bằng phương thức ToList().
// Điều này giúp dễ dàng lấy danh sách các nhân sự chính thức từ danh sách tổng hợp nhiều loại nhân sự.

Console.WriteLine("----Danh sách nhân sự chính thức----");
fe_list.ForEach(e => Console.WriteLine(e));

//Cach 2: dung cac thong thuong
List<FulltimeEmployee> fe_list2 = new List<FulltimeEmployee>(); 
foreach(var e in employees)
{
    if (e is FulltimeEmployee)
    {
        fe_list2.Add(e as FulltimeEmployee);
    }
}
Console.WriteLine("----Danh sách nhân sự chính thức----");
fe_list.ForEach(e => Console.WriteLine(e));

//Tính tổng lương
double sum_salary = fe_list2.Sum(e => e.calSalary());
Console.WriteLine("Tổng lương = " + sum_salary);


//Cau 4: R-> Sap xep danh sach nhan su theo ngay thang nam sinh
for(int i = 0; i < employees.Count; i++)
{
    for(int j = i+1; j < employees.Count; j++)
    {
        Employee ei = employees[i];
        Employee ej = employees[j];
        if(ei.Birthday > ej.Birthday)
        {
            employees[i] = ej;
            employees[j] = ei;
        }
    }
}

Console.WriteLine("----Danh sách nhân sự sau khi sắp xếp theo ngày tháng năm sinh----");
employees.ForEach(e => Console.WriteLine(e));


// Câu 5: U -> Cập nhật thông tin nhân sự
Console.WriteLine("----Cập nhật thông tin nhân sự----");
Console.WriteLine("Nhập Id nhân sự cần cập nhật:");
int idToUpdate = int.Parse(Console.ReadLine());
foreach (var emp in employees)
{
    if(emp.Id == idToUpdate)
    {
        Console.WriteLine("Profile:" + emp);
        // Update thông tin
        Console.WriteLine("Nhập tên mới:");
        emp.Name = Console.ReadLine();

        Console.WriteLine("Nhập IdCard mới:");
        emp.IdCard = Console.ReadLine();

        Console.WriteLine("Nhập ngày sinh mới (yyyy/MM/dd):");
        string dateInput = Console.ReadLine();
        if(!string.IsNullOrEmpty(dateInput)) {
            try
            {
                emp.Birthday = DateTime.Parse(dateInput);
            }
            catch
            {
                Console.WriteLine("Ngày sinh không hợp lệ, giữ nguyên ngày sinh cũ.");
            }
        }
        Console.WriteLine("Cập nhật thành công!");
        Console.WriteLine("Thông tin sau khi cập nhật: " + emp);
        break;
    }
}

// Hiển thị lại danh sách nhân sự sau khi cập nhật
Console.WriteLine("----Danh sách nhân sự sau khi cập nhật----");
employees.ForEach(e => Console.WriteLine(e));


