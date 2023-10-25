using SMCEBI_Navigator.Views;

namespace SMCEBI_Navigator;

public partial class MainNavigationPage : NavigationPage
{
	public MapDisplayPage mapDisplay;
    private readonly Page newPage;

	public MainNavigationPage()
	{
		mapDisplay = new();
		InitializeComponent();
        Appearing += MainNavigationPage_Appearing;
        newPage = new MapPickerPage();
    }

    public MainNavigationPage(Page page)
    {
        mapDisplay = new();
        InitializeComponent();
        newPage = page;

        Appearing += MainNavigationPage_Appearing;
    }

    internal async void ShowEditor(Dictionary<string, object> query)
    {
        await Navigation.PushAsync(new FeatureEditorPage(query));
    }

    internal async void ShowMap()
    {
        await Navigation.PushAsync(mapDisplay);
    }

    private async void MainNavigationPage_Appearing(object sender, EventArgs e)
    {
        if (!App.IsInitialized)
            await App.Initialization();

        await mapDisplay.UpdateDisplay();
        await Navigation.PushAsync(newPage);
    }
}