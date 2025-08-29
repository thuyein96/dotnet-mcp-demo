#nullable enable

namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey with metadata and approximate location.
/// </summary>
public sealed class Monkey
{
    /// <summary>
    /// Common name of the monkey.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Primary region or country where the monkey is commonly found.
    /// </summary>
    public string Location { get; init; } = string.Empty;

    /// <summary>
    /// Short descriptive details about the monkey.
    /// </summary>
    public string Details { get; init; } = string.Empty;

    /// <summary>
    /// URL to an image representing the monkey.
    /// </summary>
    public string Image { get; init; } = string.Empty;

    /// <summary>
    /// Approximate population count.
    /// </summary>
    public int Population { get; init; }

    /// <summary>
    /// Latitude in decimal degrees.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Longitude in decimal degrees.
    /// </summary>
    public double Longitude { get; init; }
}
