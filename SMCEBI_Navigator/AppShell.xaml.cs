namespace SMCEBI_Navigator;

public partial class AppShell : Shell
{
	public AppShell()
	{
        MapStorage.UnparseSavedConfigs();
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
        Routing.RegisterRoute(nameof(Views.MapDisplayPage), typeof(Views.MapDisplayPage));
        Routing.RegisterRoute(nameof(Views.MapPickerPage), typeof(Views.MapPickerPage));

    }
}
