using System.Net.WebSockets;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = { 20, 11, 30, 15, 40, 45, 73, 19, 50 };

/* Câu 1: Lọc ra các số chẵn
 */
// Cách 1: Dùng Extension Method - Method Syntax
var ar_chan = arr.Where(x => x % 2 == 0);
Console.WriteLine("Các số chẵn - Method Syntax:");
ar_chan.ToList().ForEach(x => Console.WriteLine(x));

//Cách 2: Dùng Query Syntax
var ar_chan2 = from x in ar_chan
               where x % 2 == 0
               select x;
Console.WriteLine("Các số chẵn - Query Syntax:");
ar_chan2.ToList().ForEach(x => Console.WriteLine(x));
/*
 * Câu 2: Tăng các phần tử odd và tăng lên 2 đơn vị
 */
var arr2 = arr.Where(x => x % 2 != 0)
               .Select(x => x + 2);
Console.WriteLine("\nDữ liệu gốc:");
foreach (var x in arr)
    Console.WriteLine(x+"\t");
Console.WriteLine("\nDữ liệu sau khi tăng số lẻ:");
foreach(var x in arr2)  
    Console.WriteLine(x+"\t");

/* Cau 3:sap xep cac phan tu tang dan
 */
var arr4 = arr.OrderBy(x => x);
var arr5 = from x in arr
           orderby x 
           select x;
Console.WriteLine("\nSau khi tăng dần:");
foreach(var item in arr5)
    Console.WriteLine(item + "\t");

/* Cay 4: sap xep giam dan
 */

var arr6 = arr.OrderByDescending(x => x);
var arr7 = from x in arr
           orderby x descending
           select x;
Console.WriteLine("\nSau khi tăng dần:");
foreach (var item in arr7)
    Console.WriteLine(item + "\t");

/* Cau 5: Dem cac phan tu le
 */
Console.WriteLine("Số lẻ là = " + arr.Where(x => x % 2 != 0).Count());
int sole = (from x in arr
           where x % 2 != 0
           select x).Count();
Console.WriteLine("Số lẻ = " + sole);
