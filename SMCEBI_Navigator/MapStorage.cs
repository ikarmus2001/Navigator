using System.Text.Json;

namespace SMCEBI_Navigator;

internal static class MapStorage
{
    /// <summary>
    /// Stores the index of currently selected (for viewing purpose) MapBuilder object in mapBuilders
    /// </summary>
    private static int _selectedMapId { get; set; } = 0;

    internal static List<MapConfig> configs { get; set; }

    internal static MapConfig Current
    {
        get
        {
            if (configs.Count == 0)
                return null;
            return configs[_selectedMapId];
        }
    }

    internal static void UnparseSavedConfigs(string json)
    {
        var deserialized = JsonSerializer.Deserialize<List<MapConfig>>(json, new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            Converters = { new PointConverter() }
        });

        if (deserialized == null)
            throw new ArgumentException("Can't deserialize saved maps");

        if (configs != null)
            configs.AddRange(deserialized);
        else
            configs = deserialized;
    }

    internal static async Task<Stream> ExportJsonMapByName(string mapName)
    {
        Stream exportStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(exportStream, configs.Find(x => x.Building.Name == mapName));
        return exportStream;
    }

    internal static bool IsSelected(MapConfig mapConfig) => configs[_selectedMapId] == mapConfig;

    internal static void SelectMap(MapConfig mapConfig) => _selectedMapId = configs.FindIndex(x => x == mapConfig);
}
