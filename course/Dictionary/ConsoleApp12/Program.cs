using System.Runtime.CompilerServices;

class OtusDictionary
{
    internal string[] dictionary;
    internal int[] dictionary_k;
    public OtusDictionary()
    {
        dictionary_k = new int[32];
        dictionary = new string[32];
    }
    public void Add(int key, string value)
    {
        try
        {
            if (value == null) { throw new Exception(); }
            if (dictionary[key % dictionary.Length] != null) { Expand(); Add(key, value); }
            else { dictionary[key % dictionary.Length] = value; dictionary_k[key % dictionary.Length] = key; }
        }
        catch (Exception)
        {
            Console.WriteLine("Error");
        }
    }
    public string this[int i]
    {
        get { return dictionary[i % dictionary.Length]; }
    } // get but cooler
    internal void Expand()
    {
        int[] _dictionary_k = new int[dictionary.Length * 2];
        string[] _dictionary = new string[dictionary.Length * 2];
        for (int i = 0; i < dictionary.Length; i++)
        {
            if (dictionary[i] != null)
            {
                int _key = dictionary_k[i] % (dictionary.Length * 2);
                _dictionary[_key] = dictionary[i];
                _dictionary_k[_key] = dictionary_k[i];
            }
        }
        dictionary = _dictionary;
        dictionary_k = _dictionary_k;
    }
    public string Get(int key)
    {
        if (dictionary[key % dictionary.Length] != null) { return dictionary[key % dictionary.Length]; }
        Console.WriteLine("Error");
        return "";
    }
    public static void Main()
    {
        OtusDictionary dictionary = new OtusDictionary();
        dictionary.Add(1, "v1");
        Console.WriteLine(dictionary.Get(1)); // v1
        Console.WriteLine(dictionary.Get(12)); // error
        dictionary.Add(33, "v33"); // collision
        Console.WriteLine(dictionary.Get(1)); // v1
        Console.WriteLine(dictionary.Get(33)); // v33
        Console.WriteLine(dictionary[33]); // v33 index
        Console.WriteLine(dictionary[1]); // v1 index

    }
}

