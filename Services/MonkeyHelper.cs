#nullable enable

using System.Collections.Concurrent;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Services;

/// <summary>
/// Static helper to manage an in-memory collection of monkeys and track access counts.
/// </summary>
public static class MonkeyHelper
{
    private static readonly IReadOnlyList<Monkey> _monkeys;
    private static readonly ConcurrentDictionary<string, int> _accessCounts = new();
    private static readonly Random _random = Random.Shared;

    static MonkeyHelper()
    {
        var list = new List<Monkey>
        {
            new Monkey
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
                Population = 10000,
                Latitude = -8.783195,
                Longitude = 34.508523
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
                Population = 23000,
                Latitude = 12.769013,
                Longitude = -85.602364
            },
            new Monkey
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
                Population = 12000,
                Latitude = 1.957709,
                Longitude = 37.297204
            },
            new Monkey
            {
                Name = "Squirrel Monkey",
                Location = "Central & South America",
                Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg",
                Population = 11000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil",
                Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg",
                Population = 19000,
                Latitude = -14.235004,
                Longitude = -51.92528
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "South America",
                Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg",
                Population = 8000,
                Latitude = -8.783195,
                Longitude = -55.491477
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan",
                Details = "The Japanese macaque is a terrestrial Old World monkey species native to Japan.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
                Population = 1000,
                Latitude = 36.204824,
                Longitude = 138.252924
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Southern Cameroon, Gabon, and Congo",
                Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and drills.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg",
                Population = 17000,
                Latitude = 7.369722,
                Longitude = 12.354722
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo",
                Details = "The proboscis monkey or long-nosed monkey is endemic to the south-east Asian island of Borneo.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg",
                Population = 15000,
                Latitude = 0.961883,
                Longitude = 114.55485
            },
            new Monkey
            {
                Name = "Sebastian",
                Location = "Seattle",
                Details = "A little trouble maker who loves traveling and tweeting @MotzMonkeys.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg",
                Population = 1,
                Latitude = 47.606209,
                Longitude = -122.332071
            },
            new Monkey
            {
                Name = "Henry",
                Location = "Phoenix",
                Details = "An adorable monkey traveling the world with Heather and live tweets his adventures @MotzMonkeys.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg",
                Population = 1,
                Latitude = 33.448377,
                Longitude = -112.074037
            },
            new Monkey
            {
                Name = "Red-shanked douc",
                Location = "Vietnam",
                Details = "The red-shanked douc is among the most colourful of all primates.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg",
                Population = 1300,
                Latitude = 16.111648,
                Longitude = 108.262122
            },
            new Monkey
            {
                Name = "Mooch",
                Location = "Seattle",
                Details = "An adorable monkey traveling with Heather and live tweeting @MotzMonkeys.",
                Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG",
                Population = 1,
                Latitude = 47.608013,
                Longitude = -122.335167
            }
        };

        _monkeys = list.AsReadOnly();
    }

    /// <summary>
    /// Returns all monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => _monkeys;

    /// <summary>
    /// Gets a single random monkey. Throws <see cref="InvalidOperationException"/> if no monkeys exist.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        if (_monkeys.Count == 0)
        {
            throw new InvalidOperationException("No monkeys are available.");
        }

        var index = _random.Next(0, _monkeys.Count);
        var monkey = _monkeys[index];
        _accessCounts.AddOrUpdate(monkey.Name, 1, (_, prev) => prev + 1);
        return monkey;
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive). Returns null when not found.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        var trimmed = name.Trim();
        var monkey = _monkeys.FirstOrDefault(m => string.Equals(m.Name, trimmed, StringComparison.OrdinalIgnoreCase));
        if (monkey is not null)
        {
            _accessCounts.AddOrUpdate(monkey.Name, 1, (_, prev) => prev + 1);
        }

        return monkey;
    }

    /// <summary>
    /// Gets the access count for a given monkey name. Returns 0 if the monkey has not been accessed or does not exist.
    /// </summary>
    public static int GetAccessCount(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return 0;
        }

        return _accessCounts.TryGetValue(name.Trim(), out var count) ? count : 0;
    }

    /// <summary>
    /// Returns a snapshot of all access counts.
    /// </summary>
    public static IReadOnlyDictionary<string, int> GetAccessCounts() => new Dictionary<string, int>(_accessCounts);
}
