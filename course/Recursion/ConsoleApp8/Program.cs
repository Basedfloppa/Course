using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static System.Diagnostics.Stopwatch;
main();
void main()
{
    var watch = new Stopwatch();
    int n;
    watch.Start();
    Console.WriteLine(Fibonachi_rec(5));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 5 рекурсией занял {n} тиков");
    watch.Reset();

    watch.Start();
    Console.WriteLine(Fibonachi_rec(10));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 10 рекурсией занял {n} тиков");
    watch.Reset();

    watch.Start();
    Console.WriteLine(Fibonachi_rec(20));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 20 рекурсией занял {n} тиков");
    watch.Reset();

    watch.Start();
    Console.WriteLine(Fibonachi_cyc(5));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 5 циклом занял {n} тиков");
    watch.Reset();

    watch.Start();
    Console.WriteLine(Fibonachi_cyc(10));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 10 циклом занял {n} тиков");
    watch.Reset();

    watch.Start();
    Console.WriteLine(Fibonachi_cyc(20));
    watch.Stop();
    n = (int)watch.ElapsedTicks;
    Console.WriteLine($"Поиск числа 20 циклом занял {n} тиков");
    watch.Reset();

} // задание 3
int Fibonachi_rec(int number)
{
    if (number == 0) { return number; }
    if (number == 1) { return number; }
    return Fibonachi_rec(number - 1) + Fibonachi_rec(number - 2);
} // задание 1
int Fibonachi_cyc(int number)
{
    int counter, counter1, counter2;
    counter = 0; counter1 = 0; counter2 = 1;
    for(int i = 1; i <= number; i++)
    {
        counter = counter1 + counter2;
        counter2 = counter1;
        counter1 = counter;
    }
    return counter;
} // задание 2