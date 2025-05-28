static int sum(int a, int b)
{
    return a + b;   
}

void callSum()
{
    int s = sum(5, 8); //OK
}

double average(int a, int b)
{
    return (a + b)/2;
}

//static void callAverage()
//{
//    double d = average(3, 6);
//}
