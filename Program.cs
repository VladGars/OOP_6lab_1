using System;
using System.Collections.Generic;
using System.Linq;

public class CollectionType
{
    public string Name { get; set; }
    public Dictionary<int, double> Elements { get; set; }

    public CollectionType(string name)
    {
        Name = name;
        Elements = new Dictionary<int, double>();
    }

    public override string ToString()
    {
        string elementsString = string.Join(", ", Elements.Select(kv => $"{{{kv.Key}:{kv.Value}}}"));
        return $"Назва: '{Name}', Кількість: {Elements.Count}, Елементи: [{elementsString}]";
    }
}

public class Program
{
    public static void Main()
    {
        var collections = new[]
        {
            new CollectionType("Колекція A") { Elements = { {1, 15.5}, {2, -5.0}, {3, 100.0} } },
            new CollectionType("Колекція B") { Elements = { {1, 88.0}, {2, 12.1}, {3, 200.0}, {4, 50.0} } },
            new CollectionType("Колекція C") { Elements = { {1, 10.0}, {2, 20.0} } },
            new CollectionType("Колекція D") { Elements = { {1, 1.0}, {2, -99.0} } },
            new CollectionType("Колекція E") { Elements = { {1, 0.5}, {2, 12.1} } }
        };

        Console.WriteLine("--- 1. Колекції з негативними елементами ---");
        var collectionsWithNegatives = collections.Where(c => c.Elements.Values.Any(val => val < 0));
        foreach (var collection in collectionsWithNegatives)
        {
            Console.WriteLine(collection);
        }

        Console.WriteLine("\n--- 2. Мін/макс колекції з елементом 12.1 ---");
        double specifiedElement = 12.1;
        var collectionsWithElement = collections.Where(c => c.Elements.Values.Contains(specifiedElement)).ToList();

        if (collectionsWithElement.Any())
        {
            var minCollection = collectionsWithElement.MinBy(c => c.Elements.Count);
            var maxCollection = collectionsWithElement.MaxBy(c => c.Elements.Count);

            Console.WriteLine("Мін: " + minCollection);
            Console.WriteLine("Макс: " + maxCollection);
        }
        else
        {
            Console.WriteLine("Колекції із зазначеним елементом не знайдено.");
        }
    }
}
