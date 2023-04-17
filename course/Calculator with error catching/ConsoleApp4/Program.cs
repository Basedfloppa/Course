
static void main()
{
    Calculate();
}

static void Calculate()
{
    char[] AllOperands = { '+', '-', '*', '/', '%', '^', '!', '=', '#', '$', '@', '<', '>', '"' };
    char[] PossibleOperands = { '+', '-', '*', '/' };
    string read1,e;
    long x = 0, y = 0;
    int counter;
    char b = ' ';
    for (; ; )
    {
        Console.Write("Введите выражение формата число оператор число: ");
        read1 = input();
        if (read1 == "стоп") { break; } if (read1 == "ошибка") { continue; }
        read1.Trim();
        counter = read1.IndexOfAny(AllOperands);
        e = conversion();
        long p = 0;
        if (e == "ошибка") { continue; }
        try
        {
            switch (b)
            {
                case '+':
                    try { p = checked(x + y); e = Sum(x, y); }
                    catch (OverflowException) { e = "OverflowEx"; }
                    catch (Exception) { e = "UnknownEx"; }
                    break;
                case '-':
                    try { p = checked(x - y); e = Sub(x, y); }
                    catch (OverflowException) { e = "OverflowEx"; }
                    catch (Exception) { e = "UnknownEx"; }
                    break;
                case '*':
                    try { p = checked(x * y); e = Mul(x, y); }
                    catch (OverflowException) { e = "OverflowEx"; }
                    catch (Exception) { e = "UnknownEx"; }
                    break;
                case '/':
                    try { e = Div(x, y); if (y != 0) { p = checked(x / y); } }
                    catch (OverflowException) { e = "OverflowEx"; }
                    catch (Exception) { e = "UnknownEx"; }
                    break;
                default: continue;
            }
            switch (e)
            {
                case "13E": throw new ThirteenException("вы получили ответ 13!");
                case "UnknownEx": throw new UnknownException("Я не смог обработать ошибку");
                case "DivByZEx": throw new DivideByZero("нельзя делить на ноль");
                case "OverflowEx": throw new Overflow("операция вызвала переполнение");
            } 
        }
        catch (DivideByZero)
        { }
        catch (ThirteenException)
        { }
        catch (UnknownException)
        { }
        catch (OverflowException) 
        { }
    }

    static string Sum(long x, long y)
    {
        Console.WriteLine("Ответ:" + (x + y));
        if (x + y == 13) { return ("13E"); }
        return (" ");
    }
    static string Sub(long x, long y)
    {
        Console.WriteLine("Ответ:" + (x - y));
        if (x - y == 13) { return ("13E"); }
        return (" ");
    }
    static string Mul(long x, long y)
    {
        Console.WriteLine("Ответ:" + (x * y));
        if (x * y == 13) { return ("13E"); }
        return (" ");
    }
    static string Div(long x, long y)
    {
        if (y == 0) { return ("DivByZEx"); }
        Console.WriteLine("Ответ:" + (int)(x / y));
        if (x / y == 13) { return ("13E"); }
        return (" ");
    }
    string input()
    {
        try
        {
            string InputInf = Console.ReadLine(); InputInf = InputInf.Trim(); InputInf += " ";
            List<string> a = new List<string>();
            string b = InputInf;
            while (b.Contains(' '))
            {
                a.Add(b.Remove(b.IndexOf(' ') + 1));
                b = b.Substring(b.IndexOf(' ')+1);
            }
            if (a.Count < 3 && InputInf.IndexOfAny(PossibleOperands) == -1) { throw new NoOperand("Укажите в выражении оператор: +, -, *, /"); }
            InputInf = InputInf.Trim();
            if (InputInf.Replace(" ", "").Length != InputInf.Length - 2)
            { throw new FormatException("Выражение некорректное, попробуйте написать в формате\na + b\na * b\na - b\na / b"); }
            return (InputInf);
        }
        catch (NoOperand)
        {
            return ("ошибка");
        }
        catch (FormatException)
        {
            return ("ошибка");
        }
        catch (Exception) { throw new UnknownException("я не смог обработать ошибку"); }
    }
    string conversion()
    {
        try
        {
            string xs, ys;
            try { x = Convert.ToInt64(read1.Remove(counter)); }
            catch
            {
                xs = read1.Remove(counter); b = ' ';
                throw new OperandNotNumber($"Операнд {xs} не является целым числом");
            }
            try
            {
                b = Convert.ToChar(read1.Substring(counter).Remove(1));
                if (b.ToString().IndexOfAny(PossibleOperands) == -1) { throw new UnknownOperand($"Я пока не умею работать с оператором {b}"); }
            }
            catch (UnknownOperand)
            {
                b = ' '; return ("");
            }
            try { y = Convert.ToInt64(read1.Substring(counter + 1)); }
            catch
            {
                ys = read1.Remove(counter); b = ' ';
                throw new OperandNotNumber($"Операнд {ys} не является целым числом");
            }
            
        }
        catch (OperandNotNumber) { }
        catch (Exception) { throw new UnknownException("я не смог обработать ошибку"); }
        return ("");
    }
}

main();

class NoOperand : ArgumentException
{
    public NoOperand(string message)
    : base(message) 
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
} // case 1
class UnknownOperand : ArgumentException
{
    public char message;
    public UnknownOperand(string message)
    : base(message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
} // case 2
class FormatException : ArgumentException
{
    public FormatException(string message)
    : base(message)
    { 
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
} // case 3
class OperandNotNumber : Exception
{
    public string message;
    public OperandNotNumber(string message)
    : base(message) 
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
} // case 4
class DivideByZero : Exception
{
    public string message;
    public DivideByZero(string message)
    : base(message) 
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();
    }
} // case 5
class ThirteenException : Exception
{
    public string message;
    public ThirteenException(string message)
    : base(message) 
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ResetColor();  
    }
} // case 6
class UnknownException : Exception
{
    public string message;
    public UnknownException(string message)
    : base(message) 
    {
        Console.WriteLine(message);
        Environment.Exit(0);
    }
}
class Overflow : OverflowException
{
    public string message;
    public Overflow(string message)
        :base(message)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
        Environment.Exit(0);
    }
}