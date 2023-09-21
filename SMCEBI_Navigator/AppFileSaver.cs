using CommunityToolkit.Maui.Storage;

namespace SMCEBI_Navigator;

internal class AppFileSaver
{
    private static IFileSaver fileSaver;

    internal AppFileSaver(IFileSaver fs)
    {
        fileSaver = fs;
    }

    internal static async void SaveFile(Stream serializedMap, string filename)
    {
        await fileSaver.SaveAsync(filename, serializedMap, default);
    }
}