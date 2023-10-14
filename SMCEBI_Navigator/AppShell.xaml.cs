namespace SMCEBI_Navigator;

public partial class AppShell : Shell
{
	public AppShell()
	{
        //AppInitialization();
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.MapDisplayPage), typeof(Views.MapDisplayPage));
        Routing.RegisterRoute(nameof(Views.MapPickerPage), typeof(Views.MapPickerPage));
        Routing.RegisterRoute(nameof(Views.MapEditorPage), typeof(Views.MapEditorPage));
        Routing.RegisterRoute(nameof(Views.FeatureEditorPage), typeof(Views.FeatureEditorPage));
    }
}
