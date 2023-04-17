List<int> list = new List<int> { 1, 5, 9, -12, 5, 0, 7, 15, 4, 10 };
var a = list.MyTop(30);
Console.WriteLine(string.Join(",",a));
a = list.MyTop(30,x => -x);
Console.WriteLine(string.Join(",", a));
Console.Read();

public static class LinqExtention
{
    public static IEnumerable<T> MyTop<T>(this IEnumerable<T> collection, int _percentage)
    {
        double percentage = Convert.ToDouble(_percentage);
        if (percentage < 1 || percentage > 100) { throw new ArgumentException(); }
        double count = collection.Count() * (percentage/100);
        collection = collection.OrderBy(x => x).ToArray();
        for (int i = (int)Math.Ceiling(count), index = 1; i > 0; i--, index++)
        {
            yield return collection.ElementAt(^index);
        }
    }
    public static IEnumerable<T> MyTop<T>(this IEnumerable<T> collection, int _percentage, Func<T,int> predicate)
    {
        double percentage = Convert.ToDouble(_percentage);
        if (percentage < 1 || percentage > 100) { throw new ArgumentException(); }
        double count = collection.Count() * (percentage / 100);
        collection = collection.OrderBy(x => predicate(x)).ToArray();
        for (int i = (int)Math.Ceiling(count),index = 1; i > 0; i--, index++)
        {
            yield return collection.ElementAt(^index);
        }
    }

}