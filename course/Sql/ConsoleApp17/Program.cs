using System;
using _commands;

namespace programm
{
    class prog
    {
        public static void Main()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("SEARCH 1");
            Console.ResetColor();
            var list1 = commands.first_search();
            foreach(var a in list1)
            {
                Console.WriteLine(a.first_name);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SEARCH 2");
            Console.ResetColor();
            var list2 = commands.second_search();
            foreach (var a in list2)
            {
                Console.WriteLine(a.title + "-" + a.description);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SEARCH 3 \nEnter name of the film");
            Console.ResetColor();
            string arg = Console.ReadLine();
            var list3 = commands.third_search(arg);
            foreach (var a in list3)
            {
                Console.WriteLine(a.title + " - " + a.rating + " - " + a.amount);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SEARCH 4");
            Console.ResetColor();
            var list4 = commands.fourth_search();
            foreach (var a in list4)
            {
                Console.WriteLine(a.first_name + " - " + a.last_name);
            }
        }
    }
}