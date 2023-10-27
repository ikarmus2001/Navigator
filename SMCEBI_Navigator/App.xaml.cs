using Microsoft.Maui.Controls.Handlers.Items;

namespace SMCEBI_Navigator;

public partial class App : Application
{
    internal static bool IsInitialized = false;

    public App()
    {
        CollectionView_HeaderFooterFix();
        InitializeComponent();
        
        MainPage = new MainNavigationPage();
    }

    /// <summary>
    /// Fixes a bug where CollectionView's Header and Footer are not added to the logical tree
    /// https://github.com/dotnet/maui/issues/14557
    /// https://github.com/dotnet/maui/issues/14557#issuecomment-1686149840
    /// </summary>
    private static void CollectionView_HeaderFooterFix()
    {
        CollectionViewHandler.Mapper.AppendToMapping("HeaderAndFooterFix", (_, collectionView) =>
        {
            collectionView.AddLogicalChild(collectionView.Header as Element);
            collectionView.AddLogicalChild(collectionView.Footer as Element);
        });
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
