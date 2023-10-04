namespace SMCEBI_Navigator;

public partial class AppShell : Shell
{
	public AppShell()
	{
        AppInitialization();
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.MapDisplayPage), typeof(Views.MapDisplayPage));
        Routing.RegisterRoute(nameof(Views.MapPickerPage), typeof(Views.MapPickerPage));
        Routing.RegisterRoute(nameof(Views.MapEditorPage), typeof(Views.MapEditorPage));
        Routing.RegisterRoute(nameof(Views.FeatureEditorPage), typeof(Views.FeatureEditorPage));

    }

    private void AppInitialization()
    {
        CheckFirstRun();
        var x = Directory.GetFiles(FileSystem.AppDataDirectory);
        foreach (string path in x)
        {
            string content = File.ReadAllText(path);
            MapStorage.UnparseSavedConfigs(content);
        }
    }

    // light/dark mode, language, styles and university group settings
    private void CheckFirstRun()
    {
        if (!Preferences.ContainsKey("Configured")/*Path.Exists(prefPath)*/)
        {
            SaveDefaultMap();
            InitializePreferences();
        }

        //var settings = JsonSerializer.Deserialize<>(new StreamReader(prefPath).ReadToEnd());

    }

    private static void SaveDefaultMap()
    {
        using Stream fs = FileSystem.Current.OpenAppPackageFileAsync("defaultMap.json").Result;
        var opts = new FileStreamOptions()
        {
            Mode = FileMode.CreateNew,
            Access = FileAccess.Write
        };
        var x = new StreamWriter(Path.Combine(FileSystem.AppDataDirectory + "/defaultMap.json"), opts);

        fs.CopyTo(x.BaseStream);
        x.Close();
    }

    private void InitializePreferences()
    {
        Preferences.Set("DarkMode", (UInt16)AppTheme.Unspecified);
        Preferences.Set("Language", "pl-PL");
        Preferences.Set("ClassGroup", "W4-ISS102_gr1");
        Preferences.Set("Configured", true);
    }
}
