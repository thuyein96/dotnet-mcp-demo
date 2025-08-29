using MyMonkeyApp.Services;

// Simple interactive console for the Monkey app
static class Program
{
	private static void PrintBanner()
	{
		Console.WriteLine();
		Console.WriteLine("   __,=\"``\"=.__");
		Console.WriteLine("  /  _       _  \\");
		Console.WriteLine(" /  (o)     (o)  \\");
		Console.WriteLine("|      ___         |");
		Console.WriteLine("|    (____)        |  My Monkey App");
	Console.WriteLine(@" \\                /");
	Console.WriteLine(@"  `._  \___/  _.'");
		Console.WriteLine("     `-.___.-'");
		Console.WriteLine();
	}

	private static void ShowMenu()
	{
		Console.WriteLine("Select an option:");
		Console.WriteLine("1) List all monkeys");
		Console.WriteLine("2) Get details by name");
		Console.WriteLine("3) Get a random monkey");
		Console.WriteLine("4) Exit");
		Console.Write("Choice: ");
	}

	private static void ListMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine();
		Console.WriteLine($"Total monkeys: {monkeys.Count}");
		Console.WriteLine(new string('-', 80));
		Console.WriteLine("Name\t| Location\t| Population\t| AccessCount");
		Console.WriteLine(new string('-', 80));
		foreach (var m in monkeys)
		{
			var count = MonkeyHelper.GetAccessCount(m.Name);
			Console.WriteLine($"{m.Name}\t| {m.Location}\t| {m.Population}\t| {count}");
		}
		Console.WriteLine(new string('-', 80));
		Console.WriteLine();
	}

	private static void ShowMonkeyDetails(string name)
	{
		var m = MonkeyHelper.GetMonkeyByName(name);
		if (m is null)
		{
			Console.WriteLine($"No monkey found with name '{name}'.");
			return;
		}

		// ASCII monkey face
		Console.WriteLine();
	Console.WriteLine("  .-''''-. ");
	Console.WriteLine(@" /  .--.  \ ");
	Console.WriteLine(@"|  /    \  |");
	Console.WriteLine("| |  ()  | |");
	Console.WriteLine(@"|  \ -- /  |");
	Console.WriteLine(@" \\  '--'  /");
	Console.WriteLine("  `-.__.-' ");
		Console.WriteLine();

		Console.WriteLine($"Name: {m.Name}");
		Console.WriteLine($"Location: {m.Location}");
		Console.WriteLine($"Population: {m.Population}");
		Console.WriteLine($"Details: {m.Details}");
		Console.WriteLine($"Image URL: {m.Image}");
		Console.WriteLine($"Coordinates: {m.Latitude}, {m.Longitude}");
		Console.WriteLine($"Access count: {MonkeyHelper.GetAccessCount(m.Name)}");
		Console.WriteLine();
	}

	public static void Main()
	{
		PrintBanner();

		while (true)
		{
			try
			{
				ShowMenu();
				var input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("Please enter a choice.");
					continue;
				}

				switch (input.Trim())
				{
					case "1":
						ListMonkeys();
						break;
					case "2":
						Console.Write("Enter monkey name: ");
						var name = Console.ReadLine() ?? string.Empty;
						ShowMonkeyDetails(name);
						break;
					case "3":
						var random = MonkeyHelper.GetRandomMonkey();
						ShowMonkeyDetails(random.Name);
						break;
					case "4":
						Console.WriteLine("Goodbye.");
						return;
					default:
						Console.WriteLine("Unknown option.");
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}
	}
}

