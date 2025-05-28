(int, double) sumAndAverage(params int[]arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
        sum += arr[i];
    double avg = sum / arr.Length;
    return (sum, avg);
}
int[] arr = { 1, 2, 3, 4, 5, 100, 30, 17 };
(int s, double v) =sumAndAverage(arr);
Console.WriteLine($"SUM={s}");
Console.WriteLine($"AVERAGE={v}");