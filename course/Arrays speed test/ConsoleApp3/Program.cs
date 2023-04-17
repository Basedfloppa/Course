using System.Collections;
using System.Diagnostics;

var l_arr = new List<int>();
var l_l_arr = new LinkedList<int>();
var l_a_arr = new ArrayList();

var s_l_arr = new Stopwatch();
var s_a_arr = new Stopwatch();
var s_ll_arr = new Stopwatch();

s_l_arr.Start();
for(int i = 0; i < 1000000; i++)
{
    l_arr.Add(i);
}
s_l_arr.Stop();
Console.WriteLine(s_l_arr.ElapsedMilliseconds + " милисекунд на заполнение листа \n");

s_l_arr.Start();
for (int i = 0; i < 1000000; i++)
{
    l_l_arr.AddLast(i);
}
s_ll_arr.Stop();
Console.WriteLine(s_ll_arr.ElapsedMilliseconds + " милисекунд на заполнение листа с ссылками \n");

s_a_arr.Start();
for (int i = 0; i < 1000000; i++)
{
    l_a_arr.Add(i);
}
s_a_arr.Stop();
Console.WriteLine(s_l_arr.ElapsedMilliseconds + " милисекунд на заполнение листа массивов \n");

s_l_arr.Reset();
s_ll_arr.Reset();
s_a_arr.Reset();

s_l_arr.Start();
Console.WriteLine(l_arr[496753]);
s_l_arr.Stop();
Console.WriteLine(s_l_arr.ElapsedMilliseconds + " милисекунд на поиск в листе \n");

s_ll_arr.Start();
int j = 0; var itm = l_l_arr.First;
while( j < 496754)
{
    if (j == 496753) Console.WriteLine(itm.Value);
    itm = itm.Next;
    j++;
}
s_ll_arr.Stop();
Console.WriteLine(s_ll_arr.ElapsedMilliseconds + " милисекунд на поиск в листе с ссылками \n");

s_a_arr.Start();
Console.WriteLine(l_a_arr[496753]);
s_a_arr.Stop();
Console.WriteLine(s_a_arr.ElapsedMilliseconds + " милисекунд на поиск в листе массивов \n");

s_l_arr.Reset();
s_ll_arr.Reset();
s_a_arr.Reset();

s_l_arr.Start();
for (int i = 777; i < 1289 * 777; i += 777)
{
    if (l_arr.Contains(i)) Console.Write(i + " "); 
}
Console.WriteLine();
s_l_arr.Stop();
Console.WriteLine( s_l_arr.ElapsedMilliseconds + " милисекунд на поиск всех чисел делящихся на 777 без остатка в листе \n");

s_a_arr.Start();
for (int i = 777; i < 1289 * 777; i += 777)
{
    if (l_a_arr.Contains(i)) Console.Write(i + " ");
}
Console.WriteLine();
s_a_arr.Stop();
Console.WriteLine( s_a_arr.ElapsedMilliseconds + " милисекунд на поиск всех чисел делящихся на 777 без остатка в листе массивов \n");

s_ll_arr.Start();
for (int i = 777; i < 1289 * 777; i += 777)
{
    if (l_l_arr.Contains(i)) Console.Write(i + " ");
}
Console.WriteLine();
s_ll_arr.Stop();
Console.WriteLine(s_ll_arr.ElapsedMilliseconds + " милисекунд на поиск всех чисел делящихся на 777 без остатка в листе массивов \n");