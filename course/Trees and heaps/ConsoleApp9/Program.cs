main();
void main()
{
    start:
    Node root = null;
    Console.WriteLine("Ведите имя и зарплату работника на след строке, используйте пустую строку для окончания:");
    for (; ; )
    {
        string s = Console.ReadLine(); s.Trim();
        if (s.Length == 0) { break; }
        string ds = Console.ReadLine();
        if (ds == null) { break; }
        int d = Convert.ToInt32(ds);
        if (root == null)
        {
            root = new Node 
            {
                Value = d,
                Name = s
            };
        }
        else
        {
            Addition(root, new Node
            {
                Value = d,
                Name = s
            });
        }
    }
    Console.WriteLine("Список работников и их зп:");
    SymmetricSort(root);
    search:
    Console.WriteLine("Введите размер зп сотрудника которого желаете найти, используйте пустую строку для окончания:");
    for (; ; )
    {
        string s = Console.ReadLine();
        if (s.Length == 0) { break; }
        int d = Convert.ToInt32(s);
        Console.WriteLine(Search(root, d));
    }
    Console.WriteLine("Если хотите повторить программу сначала, введите 0, если хотите повторить поиск зарплат введите 1");
    var a = Console.ReadLine();
    if (a == "1") { goto search; }
    if (a == "0") { goto start; }
}
string Search(Node root,int value)
{
    string error = "Такой работник не найдет";
    if(root.Value > value)
    {
        if (root.Left != null)
        {
            return Search(root.Left, value);
        }
        return error;
    }
    if(root.Value < value)
    {
        if(root.Right != null)
        {
            return Search(root.Right, value);
        }
        return error;
    }
    return $"Имя сотрудника с данной зп: {root.Name}";
}
void Addition(Node root, Node additive)
{
    if (additive.Value < root.Value)
    {
        // Работники с большей зарплатой идут в лево
        if (root.Left != null)
        {
            Addition(root.Left, additive);
        }
        else
        {
            root.Left = additive;
        }
    }
    else
    {
        if (root.Right != null)
        {
            Addition(root.Right, additive);
        }
        else
        {
            root.Right = additive;
        }
    }
}
void SymmetricSort(Node root)
{
    if(root.Left != null)
    {
        SymmetricSort(root.Left);
    }
    Console.WriteLine($"{root.Name} - {root.Value}рублей");
    if(root.Right != null)
    {
        SymmetricSort(root.Right);
    }
}
class Node
{
    public string Name { get; set; }
    public int Value { get; set; }
    public Node Right { get; set; }
    public Node Left { get; set; }
}
