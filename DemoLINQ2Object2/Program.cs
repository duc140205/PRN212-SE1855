using System.Text;
using DemoLINQ2Object2;

Console.OutputEncoding=Encoding.UTF8;
ListProduct lp = new ListProduct();
lp.gen_products();
// Câu 1:lọc ra các sản phẩm có giá từ a tới b
// sử dụng method syntax và query syntax
var result1 = lp.FilterProductsByPrice(200, 300);
Console.WriteLine("Danh sách sản phẩm có giá từ 200 đến 300:");
result1.ForEach(p => Console.WriteLine(p));

// Câu 2: sắp xếp các sản phẩm theo đơn giá giảm dần
var result2 = lp.SortProductsByPriceDescending2();
Console.WriteLine("Danh sách sản phẩm theo đơn giá giảm dần:");
result2.ForEach(p => Console.WriteLine(p));

// Câu 3: Tính tổng giá trị sản phầm trong kho hàng
double totalValue = lp.TotalValueOfProducts();
Console.WriteLine($"Tổng giá trị sản phẩm trong kho hàng: {totalValue}");
