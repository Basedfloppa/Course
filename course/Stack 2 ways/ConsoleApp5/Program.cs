main();
static void main()
{
    var s = new Stack("1", "2", "3");
    Console.WriteLine(s.Last);
    Console.WriteLine(s.Size + "\n");
    s.Pop();
    Console.WriteLine(s.Last);
    Console.WriteLine(s.Size + "\n");
    s.Add("a");
    Console.WriteLine(s.Last);
    Console.WriteLine(s.Size + "\n");
    s.Merge(new Stack("1", "2", "3"));
    Console.WriteLine(s.Last);
    Console.WriteLine(s.Size + "\n");
    s.Concat(s,new Stack("1", "2", "3"), new Stack("a", "b", "c"));
    Console.WriteLine(s.Last);
    Console.WriteLine(s.Size + "\n");
}
public class Stack
{
    StackItem item = new StackItem { value = "", next = null };
    int counter = 0;
    public Stack (params string[] args)
    {
        item.value = args[0];
        for(int i = 1; i < args.Length; i++)
        {
            Add_S(item,args[i]);
        }
    }
    public int Size
    {
        get { return this.Size_S(item); }
    }
    public int Size_S(StackItem item)
    {
        int j = 1;
        if (item.next != null) { j = j + Size_S(item.next); }
        else { return j; }
        return j;
    }
    public string Last
    {
        get { return Last_S(item); }
    }
    public string Last_S(StackItem item)
    {
        string s;
        if (item.next != null) { s = Last_S(item.next); }
        else { return item.value; }
        return s;
    }
    public string Pop()
    {
        return Pop_S(item);
    }
    public string Pop_S(StackItem item)
    {
        string s = " ";
        if (item.next != null) { s = Last_S(item.next); }
        if (item.next == null) { s = item.value; item = null; return s; }
        return s;
    }
    public Stack Concat(Stack ar,params Stack[] args)
    {
        Stack obj = null;
        foreach (Stack a in args)
        {
            obj = a;
            this.Merge(obj);
        }
        return this;
    }
    public void Add(string arg)
    {
        Add_S(item, arg);
    }
    public void Add_S(StackItem item,string arg)
    {
        if ((item != null) && (item.next != null)) { Add_S(item.next, arg); }
        else { item.next = new StackItem { value = arg, next = null }; }
    }
    public class StackItem
    {
        public string value { get; set; }
        public StackItem next { get; set; }
    }
}
public static class StackExtention
{
    public static void Merge(this Stack stack, Stack arg)
    {
        string Placeholder = "";
        if (arg != null)
        {
            for (int k = arg.Size; k != 0; k--)
            {
                Placeholder = arg.Pop();
                stack.Add(Placeholder);
            }
        }
    }
}