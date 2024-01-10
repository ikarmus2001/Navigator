using CommunityToolkit.Maui.Storage;
using System.Text;
using System.Text.Json;

namespace SMCEBI_Navigator;

internal static class FileManager
{
    private static readonly IFileSaver fileSaver = new FileSaverImplementation();

    private static JsonSerializerOptions s_writeOptions = new()
    {
        IncludeFields = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new PointConverter() }
    };

    /// <summary>
    /// Transforms string to stream and saves it to file
    /// </summary>
    /// <param name="content"></param>
    /// <param name="filename"></param>
    /// <param name="isUserChoosingLocation"></param>
    /// <param name="initialPath">AppData directory by default</param>
    /// <returns>true if save is successful, otherwise false</returns>
    internal static async Task<bool> SaveFileAsync(string content, string filename, bool isUserChoosingLocation = false, string initialPath = null) =>
        await SaveFileAsync(new MemoryStream(Encoding.UTF8.GetBytes(content)), filename, isUserChoosingLocation, initialPath);

    /// <summary>
    /// Saves stream to file
    /// </summary>
    /// <param name="content"></param>
    /// <param name="filename"></param>
    /// <param name="isUserChoosingLocation"></param>
    /// <param name="initialPath">AppData directory by default</param>
    /// <returns>true if save is successful, otherwise false</returns>
    internal static async Task<bool> SaveFileAsync(Stream content, string filename, bool isUserChoosingLocation = false, string initialPath = null)
    {
        initialPath ??= FileSystem.AppDataDirectory;

        //if (!filename.StartsWith('\\'))
        //    filename = '\\' + filename;

        if (!isUserChoosingLocation)
        {
            var opts = new FileStreamOptions()
            {
                Mode = FileMode.Create,
                Access = FileAccess.Write
            };
            string combinedPath = Path.Combine(initialPath, filename);
            var x = new StreamWriter(combinedPath, opts);

            await content.CopyToAsync(x.BaseStream);
            x.Close();
            return true;
        }

#pragma warning disable CA1416 // Validate platform compatibility (Android >= 26)
        var saveResult = await fileSaver.SaveAsync(FileSystem.AppDataDirectory, filename, content, default);
        return saveResult.IsSuccessful;
#pragma warning restore CA1416 // Validate platform compatibility
    }

    /// <summary>
    /// Retrieves stream to app bundled file
    /// </summary>
    /// <param name="filename">Name of file within app bundle</param>
    /// <returns></returns>
    internal static async Task<Stream> OpenAppBundledFileAsync(string filename)
    {
        return await FileSystem.Current.OpenAppPackageFileAsync(filename);
    }

    internal static async Task UnpackSampleMaps()
    {
        var samples = new string[] { "Dom_sample.json", "SMCEBI_sample.json" };

        foreach (string name in samples)
        {
            Stream sampleMapContent = await OpenAppBundledFileAsync(name);
            await SaveFileAsync(sampleMapContent, name);
        }
    }

    internal static void ReloadMaps()
    {
        MapStorage.configs = new();
        var x = Directory.GetFiles(FileSystem.AppDataDirectory);

        foreach (string path in x)
        {
            string content = File.ReadAllText(path);
            try { MapStorage.UnparseSavedConfigs(content); } catch (ArgumentException) { /* skip loading */ }
        }
    }

    internal static async Task SaveMap(MapConfig editedMap, string pathOverride = null)
    {
        //HtmlChangeId++;
        //ObjChangeId++;
        MemoryStream s = new();
        await JsonSerializer.SerializeAsync(s, editedMap, s_writeOptions);
        // nie dodało piętra do obiektu fml
        var x = JsonSerializer.Serialize<MapConfig>(editedMap);

        s.Seek(0, SeekOrigin.Begin);
        _ = await SaveFileAsync(s, editedMap.Building.Name + ".json", initialPath: pathOverride);
    }
}