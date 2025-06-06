
using System.Net.Mime;
using System.Text;
using DemoLINQ2SQL;

Console.OutputEncoding=Encoding.UTF8;
string connectionString = @"server=LEGION5-2023\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345;";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
// Câu 1: Truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("Danh sach danh muc:");
dsdm.ForEach(x => Console.WriteLine(x.CategoryID+"\t"+x.CategoryName));
// Caau 2: Dùng query syntax để lọc ra toàn bộ sp
var dsp = from p in context.Products
          select p;
Console.WriteLine("--Danh sách sản phẩm---");
foreach (var p in dsp)
{
    Console.WriteLine(p.ProductID+"\t"+p.ProductName);  
}

// Câu 3: Tìm danh mục khi biết mã danh mục
int dmd = 3;
Category cate = context.Categories.FirstOrDefault(x => x.CategoryID == dmd); // Lấy danh mục có mã là 3
if (cate ==null)
{
    Console.WriteLine("Không tìm thấy danh mục có mã: " + dmd);
}
else
{
    Console.WriteLine("Đã tìm thấy danh mục có mã = " + dmd);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}
//Câu 4: Lọc ra top 3 sản phẩm có giá lớn nhất
var dssptop3 = context.Products.OrderByDescending(p => p.UnitPrice)
    .Take(3);


//var dssptop3 = from p in context.Products
//               orderby p.UnitPrice descending
//               select 
Console.WriteLine("--Danh sách 3 sản phẩm đắt nhất---");
foreach (var p in dssptop3) Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);

// Câu 5: Thêm mới một danh mục
//Category c1 = new Category();
//c1.CategoryName = "Hàng điện tử hahahahahahahah";
//context.Categories.InsertOnSubmit(c1);
//context.SubmitChanges();

//Câu 6: Sửa tên danh mục
// Bước 1: tìm danh mục
// Bước 2: tìm thấy thì sửa
//Category c10 = context.Categories.FirstOrDefault(x => x.CategoryID == 10);
//if (c10 != null)
//{
//    c10.CategoryName = "Hàng gia dụng ";
//    context.SubmitChanges();
//}

//Câu 7: Xóa danh mục khi biết mã danh mục:
//Category c10 = context.Categories.FirstOrDefault(x => x.CategoryID == 10);
//if (c10 != null)
//{
//    context.Categories.DeleteOnSubmit(c10);
//    context.SubmitChanges();
//}


// Câu 8: Xóa tất cả danh mục chưa có bất kỳ sản phẩm nào
//var dssp_empty_product = context.Categories
//                            .Where(c => c.Products.Count() == 0)
//                            .ToList();
//context.Categories.DeleteAllOnSubmit(dssp_empty_product);
//context.SubmitChanges();


//Câu 9: Thêm nhiều danh mục cùng 1 lúc
//List<Category> dsdm_new = new List<Category>();
//dsdm_new.Add(new Category() { CategoryName = "Hàng thể thao" });
//dsdm_new.Add(new Category() { CategoryName = "Hàng thời trang" });
//dsdm_new.Add(new Category() { CategoryName = "Hàng công nghệ" });
//context.Categories.InsertAllOnSubmit(dsdm_new);
//context.SubmitChanges();
