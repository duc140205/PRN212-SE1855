using System.Security.Cryptography;
using System.Text;
using OOP5_Dictionary;

Console.OutputEncoding=Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Energy Drink";

Product p1 = new Product();
p1.Id = 1;
p1.Name = "Coca";
p1.Quantity = 10;
p1.Price = 15;
c1.AddProduct(p1);


Product p2 = new Product();
p2.Id = 2;
p2.Name = "Pepsi";
p2.Quantity = 30;
p2.Price = 15;
c1.AddProduct(p2);


Product p3 = new Product();
p3.Id = 3;
p3.Name = "Sting";
p3.Quantity = 7;
p3.Price = 20;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "RedBull";
p4.Quantity = 5;
p4.Price = 18;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "Sprite";
p5.Quantity = 8;
p5.Price = 20;
c1.AddProduct(p5);


//Xuat toan bo san pham cua danh muc
Console.WriteLine("---All products of Energy Drink---");
c1.PrintAllProduct();

Dictionary<int, Product> filters =
    c1.FilterProductByPrice(10, 15);
Console.WriteLine("---Products from 10->25---");
foreach(KeyValuePair<int, Product> kvp in filters)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sort_result = c1.SortProductByPrice();

Console.WriteLine("---Products after sort");
foreach(KeyValuePair<int, Product> kvp in sort_result)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}


/* 
 * Hay sap xep san pham theo don gia tang dan
 * neu don gia trung nhau thi sap xep theo so luong giam dan 
 */

Dictionary<int, Product>sort_results2 = c1.ComplexSort();
Console.WriteLine("--Product after sort");
foreach(KeyValuePair<int, Product> kvp in sort_results2)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p1.Name = "Xá xị";
p1.Quantity = 30;
p1.Price = 28;
c1.UpdateProduct(p1);
Console.WriteLine("---Product after update---");
c1.PrintAllProduct();


int id = 3;
bool ret = c1.RemoveProduct(id);
if (ret)
{
    Console.WriteLine($"Đã xóa sản phẩm có mã {id} thành công");
    Console.WriteLine("---Products after delete---");
    c1.PrintAllProduct();
} else
{
    Console.WriteLine($"KO tìm thấy sản phẩm có mã {id} để xóa");
}

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia";
c2.AddProduct(new Product() { Id = 6, Name = "Sài Gòn", Quantity = 10, Price = 300 });
c2.AddProduct(new Product() { Id = 7, Name = "333", Quantity = 15, Price = 200 });
c2.AddProduct(new Product() { Id = 8, Name = "Ken Ken", Quantity = 7, Price = 400 });

LinkedList<Category> ss = new LinkedList<Category>();
ss.AddLast(c1);
ss.AddLast(c2);
Console.WriteLine("---toàn bộ dữ liệu theo danh mục---");
foreach(Category c in ss)
{
    Console.WriteLine($"--{c.Name}--");
    Console.WriteLine("************************");
    c.PrintAllProduct();
    Console.WriteLine("************************");
}