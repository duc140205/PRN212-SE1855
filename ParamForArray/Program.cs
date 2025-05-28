int sum(params int[] arr)
{
    int s = 0;
    foreach (int x in arr) // duyệt từng phần tử cho array
        s = s + x;
    return s;
}
Console.WriteLine(sum());
Console.WriteLine(sum(1,4,9));
Console.WriteLine(sum(1,4,6,1,2,3,10,112,10));