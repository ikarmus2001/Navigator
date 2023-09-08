using SMCEBI_Navigator.Models;
using System.Text;
using System.Text.Json;

namespace SMCEBI_Navigator;

/// <summary>
/// Thread-safe singleton for storing building structure
/// </summary>
internal sealed class MapConfig
{
    private static MapConfig _instance = new();
    private static readonly object _lock = new();

    savedMaps

    private MapConfig()  { }

    /// <summary>
    /// Gets singleton instance.
    /// 
    /// See more at <see href="https://refactoring.guru/design-patterns/singleton/csharp/example#example-1">Refactoring.Guru</see>
    /// </summary>
    internal static MapConfig GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new MapConfig();
                }
            }
        }
        return _instance;
    }

    internal static Building building { get; set; }

    internal static async Task<bool> UnparseJsonAsync(string inputJson)
    {
        if (inputJson == null || inputJson.Length < 1)
            throw new ArgumentException("Json can't be empty");

        Stream jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(inputJson));

        try
        {
            MapConfig deserialization = await JsonSerializer.DeserializeAsync<MapConfig>(jsonStream);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
        
    }

    
}