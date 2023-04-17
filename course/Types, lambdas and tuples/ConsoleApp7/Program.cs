using System.Diagnostics.Metrics;
int counter2 = 0;
int counter3 = 0;
var planetvalidator = (string planetname) =>
{
    counter2++;
    if ((counter2 % 3 == 0) && (counter2 > 0)) { return "слишком часто спрашиваете"; } else { return null; }
};
string planetvalidator2(string planetname)
{
    if (planetname == "Лимония") { return "это запретная планета"; }
    counter3++;
    if ((counter3 % 3 == 0) && (counter2 > 0)) { return "слишком часто спрашиваете"; }
    else { return null; }
}
main();
void main()
{
    var run = new anontypes();
    run.planetex();
    run = null;
    Console.Write("\n\n\n");
    var run1 = new Catalogue(); 
    Console.Write("Земля "); var tuple = run1.getplanet("Земля");
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Лимония "); tuple = run1.getplanet("Лимония");
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Марс "); tuple = run1.getplanet("Марс");
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("\n");
    run1 = null;
    var run2 = new Catalogue2();
    Console.Write("Земля "); tuple = run2.getplanet("Земля", planetvalidator);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Лимония "); tuple = run2.getplanet("Лимония", planetvalidator);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Марс "); tuple = run2.getplanet("Марс", planetvalidator);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    run2 = null;
    Console.Write("\n");
    var run3 = new Catalogue3();
    Console.Write("Земля "); tuple = run3.getplanet("Земля", planetvalidator2);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Лимония "); tuple = run3.getplanet("Лимония", planetvalidator2);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
    Console.Write("Марс "); tuple = run3.getplanet("Марс", planetvalidator2);
    if (tuple.Item3 == null) Console.WriteLine($"Порядковый номер планеты от солнца - {tuple.Item1}, а экваториальный диаметр - {tuple.Item2}");
    else { Console.WriteLine(tuple.Item3); }
}
//программа 1
class anontypes
{
    public void planetex() 
    {
        var planet1 = new
        {
            Name = "Венера",
            NumFromSun = 2,
            Eqd = 12456,
            PreviousPlanet = 0
        };
        var planet2 = new
        {
            Name = "Земля",
            NumFromSun = 3,
            Eqd = 12742,
            PreviousPlanet = planet1
        };
        var planet3 = new
        {
            Name = "Марс",
            NumFromSun = 4,
            Eqd = 6792,
            PreviousPlanet = planet2
        };
        var planet4 = planet1;
        Console.WriteLine($"Планета 1 - {planet1.Name}, её экваториальный диаметр равен - {planet1.Eqd}км, она имеет номер {planet1.NumFromSun} от солнца.");
        Console.WriteLine($"Планета 2 - {planet2.Name}, её экваториальный диаметр равен - {planet2.Eqd}км, она имеет номер {planet2.NumFromSun} от солнца ей предшествует планета {planet2.PreviousPlanet.Name}.");
        if ((planet2.Name == planet1.Name) && (planet2.NumFromSun == planet1.NumFromSun)) { Console.WriteLine("Данные этой планеты равны данным Венеры."); }
        else { Console.WriteLine("Данные этой планеты не равны данным Венеры."); }
        Console.WriteLine($"Планета 3 - {planet3.Name}, её экваториальный диаметр равен - {planet3.Eqd}км, она имеет номер {planet3.NumFromSun} от солнца ей предшествует планета {planet3.PreviousPlanet.Name}.");
        if ((planet3.Name == planet1.Name) && (planet3.NumFromSun == planet1.NumFromSun)) { Console.WriteLine("Данные этой планеты равны данным Венеры."); }
        else { Console.WriteLine("Данные этой планеты не равны данным Венеры."); }
        Console.WriteLine($"Планета 4 - {planet4.Name}, её экваториальный диаметр равен - {planet4.Eqd}км, она имеет номер {planet4.NumFromSun} от солнца.");
        if ((planet4.Name==planet1.Name) &&(planet4.NumFromSun == planet1.NumFromSun)) { Console.WriteLine("Данные этой планеты равны данным Венеры"); }
        else { Console.WriteLine("Данные этой планеты не равны данным Венеры."); }
    }
}
//программа 2
class Planet
    {
        public Planet(string name, int num, int eq, object prp)
        {
            Name = name;
            NumFromSun = num;
            EquatorDiameter = eq;
            PreviousPlanet = prp;
        }
        public string Name { get; }
        public int NumFromSun { get; }
        public int EquatorDiameter { get; }
        public object PreviousPlanet { get; }
    }
class Catalogue
{
    int counter = 0;
    Planet[] catalogue = new Planet[3];
    public Catalogue()
    {
        var planet1 = new Planet("Венера", 2, 12456, 0);
        var planet2 = new Planet("Земля", 3, 12742, planet1);
        var planet3 = new Planet("Марс", 4, 6792, planet2);
        catalogue[0] = planet1; catalogue[1] = planet2; catalogue[2] = planet3;
    }
    public (int,int,string) getplanet(string planetname)
    {
        counter++;
        if (counter % 3 == 0) { return (0,0,"Слишком часто спрашиваете"); }
        for (int i = 0; i<3;i++)
        {
           if (catalogue[i].Name == planetname)
           {
                string ret = $"Порядковый номер планеты от солнца - {catalogue[i].NumFromSun}, а экваториальный диаметр - {catalogue[i].EquatorDiameter}";
                return (catalogue[i].NumFromSun, catalogue[i].EquatorDiameter, null);
           }
        }
        return (0,0,"Такой планеты не найдено");
    }
}
//программа 3
class Planet2
{
    public Planet2(string name, int num, int eq, object prp)
    {
        Name = name;
        NumFromSun = num;
        EquatorDiameter = eq;
        PreviousPlanet = prp;
    }
    public string Name { get; }
    public int NumFromSun { get; }
    public int EquatorDiameter { get; }
    public object PreviousPlanet { get; }
}
class Catalogue2
{
    Planet[] catalogue = new Planet[3];
    public Catalogue2()
    {
        var planet1 = new Planet("Венера", 2, 12456, 0);
        var planet2 = new Planet("Земля", 3, 12742, planet1);
        var planet3 = new Planet("Марс", 4, 6792, planet2);
        catalogue[0] = planet1; catalogue[1] = planet2; catalogue[2] = planet3;
    }
    public (int,int,string) getplanet(string planetname, Func<string,string> PlanetValidator)
    {
        var placeholder = PlanetValidator(planetname);
        if ( placeholder != null ) { return (0,0,placeholder); }
        for (int i = 0; i < 3; i++)
        {
            if (catalogue[i].Name == planetname)
            {
                return (catalogue[i].NumFromSun, catalogue[i].EquatorDiameter,null);
            }
        }
        return (0,0,"Такой планеты не найдено");
    }
}
//программа *
class Planet3
{
    public Planet3(string name, int num, int eq, object prp)
    {
        Name = name;
        NumFromSun = num;
        EquatorDiameter = eq;
        PreviousPlanet = prp;
    }
    public string Name { get; }
    public int NumFromSun { get; }
    public int EquatorDiameter { get; }
    public object PreviousPlanet { get; }
}
class Catalogue3
{
    Planet[] catalogue = new Planet[3];
    public Catalogue3()
    {
        var planet1 = new Planet("Венера", 2, 12456, 0);
        var planet2 = new Planet("Земля", 3, 12742, planet1);
        var planet3 = new Planet("Марс", 4, 6792, planet2);
        catalogue[0] = planet1; catalogue[1] = planet2; catalogue[2] = planet3;
    }
    public (int,int,string) getplanet(string planetname, Func<string, string> PlanetValidator)
    {
        var placeholder = PlanetValidator(planetname);
        if (placeholder != null) { return (0,0,placeholder); }
        for (int i = 0; i < 3; i++)
        {
            if (catalogue[i].Name == planetname)
            {
                return (catalogue[i].NumFromSun,catalogue[i].EquatorDiameter,null);
            }
        }
        return (0,0,"Такой планеты не найдено");
    }
}