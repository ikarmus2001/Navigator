using Microsoft.Maui.Controls.Handlers.Items;

namespace SMCEBI_Navigator;

public partial class App : Application
{
    internal static bool IsInitialized = false;

    public App()
    {
        InitializeComponent();
        
        MainPage = new MainNavigationPage();
    }

    internal static async Task Initialization()
    {
//#if DEBUG
//        Preferences.Clear();
//#endif
        await CheckFirstRun();
        FileManager.ReloadMaps();
        IsInitialized = true;
    }

    private static async Task CheckFirstRun()
    {
        if (!Preferences.ContainsKey("Configured"))
        {
            await FileManager.UnpackSampleMaps();
            InitializePreferences();
        }
    }

    private static void InitializePreferences()
    {
        Preferences.Set("DarkMode", (UInt16)AppTheme.Unspecified);
        Preferences.Set("Language", "pl-PL");
        Preferences.Set("ClassGroup", "W4-ISS102_gr1");
        Preferences.Set("Configured", true);
    }
}
