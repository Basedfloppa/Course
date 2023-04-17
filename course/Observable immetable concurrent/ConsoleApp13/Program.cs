using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

var shop = new Shop();
shop.main();
var biblio = new Biblio();
biblio.main();
var poem = new Poem();
poem.main();

// первое задание, observable (к сожалению я так и не понял почему оно вызывает событие 2 раза, если не трудно пожалуйста объясните)
public class Shop
{
    static List<Customer> customers = new List<Customer>() { };
    public static ObservableCollection<Item> _item = new ObservableCollection<Item> { };
    public class Item
    {
        public int id;
        public string name;
        public Item(int i, string s)
        {
            id = i;
            name = s;
        }
    }
    public Shop()
    {
        _item.CollectionChanged += ItemChange;
    }
    public void CustomerAdd(int _id)
    {
        customers.Add(new Customer { customerid = _id});
    }
    public void Add(int id)
    {
        _item.Add(new Item(id, DateTime.Now.ToString()));
    }
    public void Remove(int id)
    {
        for (int i = 0; i < _item.Count; i++)
        {
            if (_item[i].id == id) { _item.RemoveAt(i); }
            else { Console.WriteLine("Такой товар не найден"); }
        }
    }
    public void ItemChange(object? sender, NotifyCollectionChangedEventArgs e)
    {
        foreach(var a in customers)
        {
            var id = a.customerid;
            a.OnItemChange(sender, e, id);
        }
    }
    internal class Customer
    {
        public int customerid;
        public void OnItemChange(object? sender, NotifyCollectionChangedEventArgs e, int id)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Item newItem)
                        Console.WriteLine($"Добавлен новый объект: {newItem.id} - {newItem.name}, получающий уведомление - {id}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Item oldItem)
                        Console.WriteLine($"Удален объект: {oldItem.id} - {oldItem.name}, получающий уведомление - {id}");
                    break;
            }
        }
    }
    public void main()
    {
        bool exit = false;
        int placeholder;
        this.CustomerAdd(1);
        Console.WriteLine("Нажмите A,затем введите id товара, чтобы добавить товар в магазин\nНажмите D,затем введите id товара, чтобы удалить товар\nНажмите X, чтобы перейти в след программу");
        for(; ; )
        {
            var a = Console.ReadKey();
            switch (a.Key)
            {
                case ConsoleKey.A: 
                    placeholder = Convert.ToInt32(Console.ReadLine()); 
                    this.Add(placeholder);
                    break;
                case ConsoleKey.D: placeholder = Convert.ToInt32(Console.ReadLine()); this.Remove(placeholder); break;
                case ConsoleKey.X: exit = true; break;
                default: break;
            }
            if (exit) break;
        }
    }
}

// второе задание, concurent
public class Biblio
{
    ConcurrentDictionary<string, int> books = new ConcurrentDictionary<string,int> { };
    void unread()
    {
        foreach(var a in books)
        {
            Console.WriteLine($"\n{a.Key} - {a.Value}%");
        }
    }
    void increment()
    {
        Thread.Sleep(100);
        foreach(var a in books)
        {
            if (a.Value < 100) {var k_a = a.Key; var v_a = a.Value; 
                                books.TryRemove(a); 
                                v_a = v_a + 1;
                                books.TryAdd(k_a, v_a);
            }
            else { books.TryRemove(a); }
        }
    }
    void addbook()
    {
        books.TryAdd(Console.ReadLine(), 0);
    }
    public void main()
    {
        Shop _shop = new Shop();
        bool exit = false;
        string placeholder;
        Console.WriteLine("\nНажмите 1, затем введите название книги, чтобы добавить её в список\nНажмите 2, чтобы посмотреть список непрочитанного\nНажмите 3, чтобы перейти в след программу");
        var thread1 = new Thread(() =>
        {
            for (; ; )
            {
                var a = Console.ReadKey();
                switch (a.Key)
                {
                    case ConsoleKey.D1: addbook(); break;
                    case ConsoleKey.D2: unread(); break;
                    case ConsoleKey.D3: exit = true; break;
                    case ConsoleKey.NoName: break;
                }
            }
        });
        var thread2 = new Thread(() =>
        {
            for (; ; )
            {
                increment();
            }
        });
        thread1.Start();
        thread2.Start();
        while (exit == false) {}
    }
}

// третье задание, immutable
public class Poem
{
    public ImmutableList<string> _Poem = ImmutableList<string>.Empty;
    public class Part1 
    {
        List<string> poem = new List<string> {  "Вот дом,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part2 
    {
        List<string> poem = new List<string> {  "А это пшеница,",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part3
    {
        List<string> poem = new List<string> {  "А это веселая птица-синица,",
                                                "Которая часто ворует пшеницу,",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part4 
    {
        List<string> poem = new List<string> {  "Вот кот,",
                                                "Который пугает и ловит синицу,",
                                                "Которая часто ворует пшеницу,",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part5 
    {
        List<string> poem = new List<string> {  "Вот пес без хвоста,",
                                                "Который за шиворот треплет кота,",
                                                "Который пугает и ловит синицу,",
                                                "Которая часто ворует пшеницу,",
                                                "Которая в темном чулане хранится","В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part6
    {
        List<string> poem = new List<string> { "А это корова безрогая,",
                                               "Лягнувшая старого пса без хвоста,", 
                                               "Который за шиворот треплет кота,",
                                               "Который пугает и ловит синицу,", 
                                               "Которая часто ворует пшеницу,",
                                               "Которая в темном чулане хранится",
                                               "В доме,", 
                                               "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part7
    {
        List<string> poem = new List<string> {  "А это старушка, седая и строгая,",
                                                "Которая доит корову безрогую,",
                                                "Лягнувшую старого пса без хвоста,",
                                                "Который за шиворот треплет кота,",
                                                "Который пугает и ловит синицу,",
                                                "Которая часто ворует пшеницу",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part8 
    {
        List<string> poem = new List<string> {  "А это ленивый и толстый пастух,",
                                                "Который бранится с коровницей строгою,",
                                                "Которая доит корову безрогую,",
                                                "Лягнувшую старого пса без хвоста,",
                                                "Который за шиворот треплет кота,",
                                                "Который пугает и ловит синицу,",
                                                "Которая часто ворует пшеницу,",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек."};
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public class Part9 
    {
        public List<string> poem = new List<string> { "Вот два петуха,",
                                                "Которые будят того пастуха,",
                                                "Который бранится с коровницей строгою,",
                                                "Которая доит корову безрогую,",
                                                "Лягнувшую старого пса без хвоста,",
                                                "Который за шиворот треплет кота,",
                                                "Который пугает и ловит синицу,",
                                                "Которая часто ворует пшеницу,",
                                                "Которая в темном чулане хранится",
                                                "В доме,",
                                                "Который построил Джек." };
        public ImmutableList<string> AddPart(ImmutableList<string> a)
        {
            var _a = a.AddRange(poem);
            return _a;
        }
    }
    public void main()
    {
        
        Part1 p1 = new Part1();Part2 p2 = new Part2();Part3 p3 = new Part3();
        Part4 p4 = new Part4();Part5 p5 = new Part5();Part6 p6 = new Part6();
        Part7 p7 = new Part7();Part8 p8 = new Part8();Part9 p9 = new Part9();
        var a = p9.AddPart(p8.AddPart(p7.AddPart(p6.AddPart(p5.AddPart(p4.AddPart(p3.AddPart(p2.AddPart(p1.AddPart(_Poem)))))))));
        Console.WriteLine("\n"+string.Join("\n", a)); // its empty
    }

}
