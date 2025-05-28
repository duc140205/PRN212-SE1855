using System.Text;
Console.OutputEncoding = Encoding.UTF8;
string ho = "Nguyễn";
string tenlot = "Thị";
String ten = "Tèo";
string fullname = ho + " " + tenlot + " " + ten;
Console.WriteLine(fullname);

StringBuilder sb = new StringBuilder();
sb.Append(ho);
sb.Append(" ");
sb.Append(tenlot);  
sb.Append(" ");
sb.Append(ten);
Console.WriteLine(sb.ToString());