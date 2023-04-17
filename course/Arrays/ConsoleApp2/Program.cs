int table_size = 0, counter = 1;
string table_text = "";
bool ts = false, tt = false;

do
{
    Console.Write("Введите размерность таблицы от 1 до 6 включительно: ");
    var a = Console.ReadLine();
    if (int.TryParse(a, out int res) && Convert.ToInt32(a) <= 6 && Convert.ToInt32(a) >= 1) {
        table_size = Convert.ToInt32(a);
        ts = true;
    }
    if (ts == false) Console.Clear();
} while (ts == false);

while (tt == false)
{
    Console.Write("\nВведите произвольный текст не более 34 символов: ");
    var a = Console.ReadLine();
    if (a != null && a.Length > 0 && a.Length < 35)
    {
        table_text = Convert.ToString(a);
        tt = true;
    }
    if (tt == false) Console.Clear();
}

string space = new string(' ', table_size - 1); string space_2 = new string(' ', table_text.Length);
string floor_ceiling = new string('+', table_size * 2 + table_text.Length);
string wall = "+" + space + space_2 + space + "+";
string txt_b = "+" + space + table_text + space + "+";

bool square(string f_c, string w, string tb)
{
    for (int i = 0; i < table_size * 2 + 1; i++)
    {
        if (i == 0 || i == table_size * 2) Console.WriteLine(f_c);
        if (i == table_size) Console.WriteLine(tb);
        if (i != 0 && i != table_size * 2 && i != 1 + table_size) Console.WriteLine(w);
    }
    return (true);
}

bool chess(int t_s, string t_t)
{
    string ch = "";
    for (int i = 0; i < t_s * 2 + t_t.Length - 1; i++)
    {
        ch = i % 2 == 0 ? ch += "+" : ch += " ";
    }
    for (int i = 0; i < t_s * 2 - 1; i++)
    {
        if (i % 2 == 0) Console.WriteLine(ch);
        else Console.WriteLine(" " + ch);
    }
    return (true);
}

bool hourglass(string f_c, string s, string s_2)
{
    Console.WriteLine(f_c);
    for (int i = 1; i < table_size * 2 + table_text.Length; i++)
    {
        if (table_size * 2 + table_text.Length - 2 - i * 2 > 0) s = new string(' ', table_size * 2 + table_text.Length - 2 - i * 2);
        else break;
        s_2 = new string(' ', i);
        Console.WriteLine(s_2 + "+" + s + "+" + s_2);
    }
    for (int i = table_size * 2 + table_text.Length; i > 0; i--)
    {
        if (table_size * 2 + table_text.Length - 2 - i * 2 > 0) s = new string(' ', table_size * 2 + table_text.Length - 2 - i * 2);
        else continue;
        s_2 = new string(' ', i);
        Console.WriteLine(s_2 + "+" + s + "+" + s_2);
    }
    Console.WriteLine(f_c);
    return (true);
}

for(; ; ) {
    switch (counter)
    {
        case 1:
            if (square(floor_ceiling, wall, txt_b) == true) counter++;
            break;
        case 2:
            if (chess(table_size,table_text) == true) counter++;
            break;
        case 3:
            if (hourglass(floor_ceiling, space, space_2) == true) counter++;
            break;
        default: break;
    }
}