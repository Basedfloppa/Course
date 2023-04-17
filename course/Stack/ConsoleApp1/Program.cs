main();
static void main()
{
    var s = new Stack("a", "b", "c");
    // size = 3, Top = 'c'
    Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
    var deleted = s.Pop();
    // Извлек верхний элемент 'c' Size = 2
    Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
    s.Add("d");
    // size = 3, Top = 'd'
    Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
    s.Pop();
    s.Pop();
    s.Pop();
    // size = 0, Top = null
    Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
    s.Pop();
    s.Merge(new Stack("1", "2", "3"));
    Console.WriteLine(s.Size + "\n");
    s.Concat(s, new Stack("1", "2", "3"), new Stack("a", "b", "c"));
    Console.WriteLine(s.Size + " " + s.Top);

}
public class Stack
{
    public List<string> Holder = new List<string> { };
    public Stack(params string[] args)
    {
        foreach (var a in args)
        {
            Holder.Add(a);
        }
    }
    public void Add(string arg)
    {
        Holder.Add((string)arg);
    }
    public string Pop()
    {
        string Placeholder = " ";
        try
        {
            if (Holder == null) { throw new Exception("Стек пустой"); }
            Placeholder = Holder.Last();
            Holder.Remove(Holder.Last());
        }
        catch (Exception)
        {
            Console.WriteLine("Стек пустой");
            return null;
        }
        return Placeholder;
    }
    public int Size
    {
        get { return Holder.Count; }

    }
    public string Top
    {
        get
        {
            if (Holder.Count == 0) { return null; }
            else { return Holder.Last(); }
        }
    }
    public Stack Concat(Stack ar, params Stack[] args)
    {
        Stack obj = null;
        foreach (Stack a in args)
        {
            obj = a;
            this.Merge(obj);
        }
        return this;
    }
}
public static class StackExtention
{
    public static void Merge(this Stack stack, Stack arg)
    {
        string Placeholder = "";
        if (arg != null)
        {
            for (int i = arg.Size; i != 0; i--)
            {
                Placeholder = arg.Pop();
                stack.Add(Placeholder);
            }
        }
    }
}