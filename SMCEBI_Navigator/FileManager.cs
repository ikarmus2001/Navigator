using CommunityToolkit.Maui.Storage;
using System.Text;

namespace SMCEBI_Navigator;

internal static class FileManager
{
    private static readonly IFileSaver fileSaver = new FileSaverImplementation();

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
        if (!filename.StartsWith('\\'))
            filename = '\\' + filename;

        if (!isUserChoosingLocation)
        {
            var opts = new FileStreamOptions()
            {
                Mode = FileMode.Create,
                Access = FileAccess.Write
            };
            var x = new StreamWriter(Path.Combine(initialPath + filename), opts);

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

    internal static void ReloadMaps()
    {
        MapStorage.configs = null;
        var x = Directory.GetFiles(FileSystem.AppDataDirectory);
        if (x.Length == 0)
        {
            MapStorage.configs = new();
            return;
        }

        foreach (string path in x)
        {
            string content = File.ReadAllText(path);
            MapStorage.UnparseSavedConfigs(content);
        }
    }
}