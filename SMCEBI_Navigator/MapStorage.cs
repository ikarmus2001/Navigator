using System.Text.Json;

namespace SMCEBI_Navigator;

internal static class MapStorage
{
    /// <summary>
    /// Stores the index of currently selected (for viewing purpose) MapBuilder object in mapBuilders
    /// </summary>
    private static int _selectedMapId { get; set; }

    internal static List<MapConfig> configs { get; set; }

    internal static MapConfig Current
    {
        get
        {
            return configs[_selectedMapId];
        }
    }

    internal static async void UnparseSavedConfigs(string filename = "savedMaps.json")
    {
        Stream saveFileStream;
        try
        {
            saveFileStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);
        }
        catch (FileNotFoundException)
        {
            // TODO: Handle the case when file is not found
            return;
        }
        using StreamReader reader = new StreamReader(saveFileStream);
        string json = await reader.ReadToEndAsync();
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
}
